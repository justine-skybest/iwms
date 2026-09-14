/** Dev environment for every app; production builds swap in `app-env.prod.ts` via `fileReplacements`. */
export const environment = {
  production: false,
  apiUrl: "http://localhost:8805",
  identityServerUrl: "http://localhost:7001",
};