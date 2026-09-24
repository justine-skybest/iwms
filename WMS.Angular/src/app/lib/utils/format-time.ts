 export function formatTime(timeStr?: string): string {
  if (!timeStr) return '—';
  try {
    const date = new Date(timeStr);
    if (!isNaN(date.getTime())) {
      return date.toLocaleTimeString('en-US', { hour: '2-digit', minute: '2-digit' });
    }
    return timeStr;
  } catch {
    return timeStr;
  }
}