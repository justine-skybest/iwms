/**
 * Converts UTC Date, ISO string, or Timestamp to Philippine Standard Time (Asia/Manila, UTC+8)
 */
export function formatPhilippineTime(
  value: Date | string | number | null | undefined,
  includeTime: boolean = true
): string {
  if (!value) return '—';

  // Ensure missing 'Z' suffix on ISO strings is handled as UTC
  let dateObj: Date;
  if (typeof value === 'string') {
    const trimmed = value.trim();
    const hasTimezone = trimmed.endsWith('Z') || /[+-]\d{2}:\d{2}$/.test(trimmed);
    dateObj = new Date(hasTimezone ? trimmed : `${trimmed}Z`);
  } else {
    dateObj = new Date(value);
  }

  if (isNaN(dateObj.getTime())) return '—';

  const options: Intl.DateTimeFormatOptions = {
    timeZone: 'Asia/Manila',
    year: 'numeric',
    month: 'short',
    day: '2-digit',
    ...(includeTime
      ? {
          hour: '2-digit',
          minute: '2-digit',
          hour12: true
        }
      : {})
  };

  return new Intl.DateTimeFormat('en-PH', options).format(dateObj);
}