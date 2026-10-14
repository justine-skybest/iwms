export function toDateOnly(value: any): string | null {
  if (!value) return null;

  if (typeof value === 'string') {
    const trimmed = value.trim();
    if (!trimmed) return null;
    // Already in YYYY-MM-DD format
    if (/^\d{4}-\d{2}-\d{2}$/.test(trimmed)) return trimmed;
    // Full ISO string like "2026-10-13T00:00:00" -> extract date part
    if (/^\d{4}-\d{2}-\d{2}T/.test(trimmed)) return trimmed.split('T')[0];
  }

  const d = new Date(value);
  if (isNaN(d.getTime())) return null;

  // Format as YYYY-MM-DD using local time
  const year = d.getFullYear();
  const month = String(d.getMonth() + 1).padStart(2, '0');
  const day = String(d.getDate()).padStart(2, '0');
  return `${year}-${month}-${day}`;
}