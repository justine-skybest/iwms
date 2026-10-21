// time-utils.ts

/**
 * Converts a UTC string/Date from the server to "HH:mm" in Philippine Time (UTC+8)
 * for binding to <input type="time">.
 */
export function utcToPhilippineTimeInput(utcValue: string | Date | null | undefined): string {
  if (!utcValue) return '';

  // Case A: Backend returned a TimeSpan / Time string (e.g., "08:30:00" or "08:30")
  if (typeof utcValue === 'string' && /^(\d{1,2}):(\d{2})(:(\d{2}))?$/.test(utcValue.trim())) {
    const [h, m] = utcValue.trim().split(':').map(Number);
    // Add 8 hours for PH time
    const phHour = (h + 8) % 24;
    return `${String(phHour).padStart(2, '0')}:${String(m).padStart(2, '0')}`;
  }

  // Case B: Backend returned a full ISO DateTime string or Date object
  let dateObj: Date;
  if (typeof utcValue === 'string') {
    const trimmed = utcValue.trim();
    const hasTz = trimmed.endsWith('Z') || /[+-]\d{2}:\d{2}$/.test(trimmed);
    dateObj = new Date(hasTz ? trimmed : `${trimmed}Z`);
  } else {
    dateObj = new Date(utcValue);
  }

  if (isNaN(dateObj.getTime())) return '';

  return new Intl.DateTimeFormat('en-GB', {
    timeZone: 'Asia/Manila',
    hour: '2-digit',
    minute: '2-digit',
    hourCycle: 'h23'
  }).format(dateObj);
}

/**
 * Converts the "HH:mm" Philippine time chosen in the input back to UTC for the server.
 * 
 * @param phTimeInput The "HH:mm" string from the <input type="time">
 * @param originalUtcValue (Optional) The original ISO string to preserve the original date
 */
export function philippineTimeToUtc(
  phTimeInput: string,
  originalUtcValue?: string | Date | null
): string {
  if (!phTimeInput) return '';

  const [phHours, phMinutes] = phTimeInput.split(':').map(Number);

  // If you are storing a full ISO string (DateTime in C#)
  if (originalUtcValue && typeof originalUtcValue === 'string' && originalUtcValue.includes('T')) {
    const baseDate = new Date(originalUtcValue);
    // Format to Asia/Manila date string parts: YYYY-MM-DD
    const parts = new Intl.DateTimeFormat('en-CA', {
      timeZone: 'Asia/Manila',
      year: 'numeric',
      month: '2-digit',
      day: '2-digit'
    }).format(baseDate);

    // Create a Date object set to that Manila time (+08:00 offset)
    const manilaIso = `${parts}T${String(phHours).padStart(2, '0')}:${String(phMinutes).padStart(2, '0')}:00+08:00`;
    return new Date(manilaIso).toISOString(); // Returns UTC: "YYYY-MM-DDTHH:mm:ss.sssZ"
  }

  // If you are storing a TimeSpan / Time string (TimeSpan in C#)
  // Subtract 8 hours to convert Manila back to UTC
  const utcHours = (phHours - 8 + 24) % 24;
  return `${String(utcHours).padStart(2, '0')}:${String(phMinutes).padStart(2, '0')}:00`;
}