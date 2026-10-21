/**
 * Formats a UTC ISO string, Date object, or MySQL TIME string into "HH:mm" 
 * for HTML <input type="time"> in Philippine Standard Time (UTC+8).
 */
export function formatPhilippineTimeToInput(
  value: Date | string | number | null | undefined
): string {
  if (!value) return '';

  // Case 1: Value is already a plain time string (e.g., "14:30" or "14:30:00" from MySQL)
  if (typeof value === 'string') {
    const timeRegex = /^(\d{1,2}):(\d{2})(?::\d{2})?$/;
    const match = value.trim().match(timeRegex);
    if (match) {
      const hours = match[1].padStart(2, '0');
      const minutes = match[2];
      return `${hours}:${minutes}`;
    }
  }

  // Case 2: Value is an ISO/UTC datetime string or timestamp
  let dateObj: Date;
  if (typeof value === 'string') {
    const trimmed = value.trim();
    const hasTimezone = trimmed.endsWith('Z') || /[+-]\d{2}:\d{2}$/.test(trimmed);
    dateObj = new Date(hasTimezone ? trimmed : `${trimmed}Z`);
  } else {
    dateObj = new Date(value);
  }

  if (isNaN(dateObj.getTime())) return '';

  // Extract 24-hour hour and minute in Asia/Manila (UTC+8)
  const formatter = new Intl.DateTimeFormat('en-GB', {
    timeZone: 'Asia/Manila',
    hour: '2-digit',
    minute: '2-digit',
    hourCycle: 'h23' // Ensures 00-23 format
  });

  const parts = formatter.formatToParts(dateObj);
  const hour = parts.find((p) => p.type === 'hour')?.value.padStart(2, '0') ?? '00';
  const minute = parts.find((p) => p.type === 'minute')?.value.padStart(2, '0') ?? '00';

  return `${hour}:${minute}`;
}