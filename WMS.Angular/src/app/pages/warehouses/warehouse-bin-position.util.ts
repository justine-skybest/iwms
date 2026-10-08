import { Location3DDto } from '../../api/generated/models';

const BIN_FOOTPRINT = { width: 1.5, depth: 1.2 };
const BIN_SPACING = 2.5;
const OPEN_AREA_LIMIT = 20;

export function findOpenBinPosition(occupiedLocations: readonly Location3DDto[]): Location3DDto {
  const candidates: Array<{ positionX: number; positionZ: number; distance: number }> = [];

  for (let x = -OPEN_AREA_LIMIT; x <= OPEN_AREA_LIMIT; x += BIN_SPACING) {
    for (let z = -OPEN_AREA_LIMIT; z <= OPEN_AREA_LIMIT; z += BIN_SPACING) {
      candidates.push({ positionX: x, positionZ: z, distance: x * x + z * z });
    }
  }

  candidates.sort((a, b) => a.distance - b.distance || a.positionX - b.positionX || a.positionZ - b.positionZ);

  const available = candidates.find((candidate) =>
    occupiedLocations.every((location) => {
      const existingX = location.positionX ?? 0;
      const existingZ = location.positionZ ?? 0;
      const minimumXDistance = (BIN_FOOTPRINT.width + (location.width ?? BIN_FOOTPRINT.width)) / 2;
      const minimumZDistance = (BIN_FOOTPRINT.depth + (location.depth ?? BIN_FOOTPRINT.depth)) / 2;
      return Math.abs(candidate.positionX - existingX) >= minimumXDistance ||
        Math.abs(candidate.positionZ - existingZ) >= minimumZDistance;
    })
  );

  if (!available) {
    throw new Error('No unoccupied bin positions remain in the warehouse open-floor area.');
  }

  return {
    positionX: available.positionX,
    positionY: 0.6,
    positionZ: available.positionZ,
    rotationY: 0,
    ...BIN_FOOTPRINT,
    height: 1.2,
  };
}
