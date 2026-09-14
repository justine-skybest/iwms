#!/usr/bin/env bun
/// <reference types="bun-types" />

import { readdir } from "fs/promises";
import { join, relative } from "path";

// Align this with the "output" path set in ng-openapi-gen.json
const GENERATED_DIR = "src/app/api/generated";

const RUNTIME_IMPORTS = new Set([
  "Injectable",
  "HttpClient",
  "HttpContext",
  "HttpResponse",
  "HttpParams",
  "HttpHeaders",
  "HttpRequest",
  "Observable",
  "filter",
  "map",
  "firstValueFrom",
  "RequestBuilder",
  "ApiConfiguration",
]);

const SKIP_FILES = new Set(["strict-http-response.ts"]);

async function getTypeScriptFiles(dir: string): Promise<string[]> {
  const files: string[] = [];
  const entries = await readdir(dir, { withFileTypes: true });

  for (const entry of entries) {
    const fullPath = join(dir, entry.name);
    if (entry.isDirectory()) {
      files.push(...(await getTypeScriptFiles(fullPath)));
    } else if (entry.name.endsWith(".ts")) {
      files.push(fullPath);
    }
  }

  return files;
}

function isTypeOnlyImport(
  importName: string,
  fileContent: string,
  importStatement: string
): boolean {
  if (RUNTIME_IMPORTS.has(importName)) {
    return false;
  }

  const contentWithoutImport = fileContent.replace(importStatement, "");

  const runtimePatterns = [
    new RegExp(`instanceof\\s+${importName}\\b`),
    new RegExp(`\\b${importName}\\s*\\(`),
    new RegExp(`new\\s+${importName}\\b`),
    new RegExp(`\\b${importName}\\.`),
    new RegExp(`=\\s*${importName}\\b(?!\\s*[<>])`),
  ];

  for (const pattern of runtimePatterns) {
    if (pattern.test(contentWithoutImport)) {
      return false;
    }
  }

  return true;
}

function fixAcronymCasing(content: string): string {
  return content.replace(/Ai(?=[A-Z])/g, "AI");
}

async function processFile(filePath: string): Promise<boolean> {
  const file = Bun.file(filePath);
  const original = await file.text();

  const content = fixAcronymCasing(original);
  const importRegex = /^import\s+\{([^}]+)\}\s+from\s+['"]([^'"]+)['"];?$/gm;

  let modified = content;
  let hasChanges = content !== original;

  const imports = [...content.matchAll(importRegex)];

  for (const match of imports) {
    const [fullMatch, importList, importPath] = match;

    if (fullMatch.includes("import type")) {
      continue;
    }

    const importNames = importList.split(",").map((name) => name.trim());
    const typeOnlyImports: string[] = [];
    const runtimeImports: string[] = [];

    for (const name of importNames) {
      const baseName = name.includes(" as ") ? name.split(" as ")[0].trim() : name;

      if (isTypeOnlyImport(baseName, content, fullMatch)) {
        typeOnlyImports.push(name);
      } else {
        runtimeImports.push(name);
      }
    }

    if (typeOnlyImports.length > 0 && runtimeImports.length === 0) {
      const newImport = `import type { ${typeOnlyImports.join(", ")} } from '${importPath}';`;
      modified = modified.replace(fullMatch, newImport);
      hasChanges = true;
    } else if (typeOnlyImports.length > 0 && runtimeImports.length > 0) {
      const typeImport = `import type { ${typeOnlyImports.join(", ")} } from '${importPath}';`;
      const runtimeImport = `import { ${runtimeImports.join(", ")} } from '${importPath}';`;
      modified = modified.replace(fullMatch, `${runtimeImport}\n${typeImport}`);
      hasChanges = true;
    }
  }

  if (hasChanges) {
    await Bun.write(filePath, modified);
    return true;
  }

  return false;
}

async function main(): Promise<void> {
  console.log("Fixing generated output (import type, AI acronym casing)...\n");

  const files = await getTypeScriptFiles(GENERATED_DIR);
  let fixedCount = 0;

  for (const file of files) {
    const fileName = file.split(/[/\\]/).pop();

    if (fileName && SKIP_FILES.has(fileName)) {
      continue;
    }

    try {
      const wasFixed = await processFile(file);
      if (wasFixed) {
        console.log(`  Fixed: ${relative(GENERATED_DIR, file)}`);
        fixedCount++;
      }
    } catch (error) {
      console.error(`  Error processing ${file}:`, error instanceof Error ? error.message : error);
    }
  }

  console.log(`\nDone! Fixed ${fixedCount} file(s).`);
}

main().catch(console.error);