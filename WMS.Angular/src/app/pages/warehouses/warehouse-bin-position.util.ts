import { Location3DDto } from '../../api/generated/models';

const BIN_FOOTPRINT = { width: 1.5, depth: 1.2 };
const BIN_SPACING = 2.5;

export function findOpenBinPosition(
  occupiedLocations: readonly Location3DDto[],
  warehouseId?: number
): Location3DDto {
  const isWarehouseOne = warehouseId === 1;
  const area = isWarehouseOne
    ? { centerX: 38, centerZ: 36, limitX: 6, limitZ: 4 }
    : { centerX: 0, centerZ: 0, limitX: 20, limitZ: 20 };
  const candidates: Array<{ positionX: number; positionZ: number; distance: number }> = [];

  const stepsX = Math.floor(area.limitX / BIN_SPACING);
  const stepsZ = Math.floor(area.limitZ / BIN_SPACING);
  for (let xStep = -stepsX; xStep <= stepsX; xStep += 1) {
    for (let zStep = -stepsZ; zStep <= stepsZ; zStep += 1) {
      const offsetX = xStep * BIN_SPACING;
      const offsetZ = zStep * BIN_SPACING;
      const positionX = area.centerX + offsetX;
      const positionZ = area.centerZ + offsetZ;
      candidates.push({
        positionX,
        positionZ,
        distance: offsetX * offsetX + offsetZ * offsetZ,
      });
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
