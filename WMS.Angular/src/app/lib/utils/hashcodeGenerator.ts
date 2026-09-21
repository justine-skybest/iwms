export function generateHashCode(): number {
  const array = new Uint32Array(1);
  crypto.getRandomValues(array);
  return (array[0] % 900000) + 10000000; // Guarantees a 8-digit number (10000000 - 99999999)
}