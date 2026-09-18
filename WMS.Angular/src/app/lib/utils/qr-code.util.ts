import QRCode from 'qrcode';

/**
 * Generates a PNG Data URL string for a given text or numeric hash code.
 */
export async function generateQrCodeDataUrl(
  value: string | number | null | undefined,
  width = 120
): Promise<string> {
  if (value === null || value === undefined || value === '') {
    return '';
  }

  try {
    return await QRCode.toDataURL(String(value), {
      width,
      margin: 1,
      color: {
        dark: '#0f172a', // slate-900
        light: '#ffffff',
      },
    });
  } catch (err) {
    console.error('Failed to generate QR code:', err);
    return '';
  }
}