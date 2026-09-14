// ── Data ───────────────────────────────────────────────────────────────────
const recentReceiving = [
  { series: "RCV-2024-0891", warehouse: "WH-NORTH-01", shipper: "Pacific Exports Ltd.", date: "Sep 13, 2026" },
  { series: "RCV-2024-0890", warehouse: "WH-SOUTH-03", shipper: "Guangzhou Freight Co.", date: "Sep 13, 2026" },
  { series: "RCV-2024-0889", warehouse: "WH-EAST-02", shipper: "Manila Bay Logistics", date: "Sep 12, 2026" },
  { series: "RCV-2024-0888", warehouse: "WH-NORTH-01", shipper: "Trans-Asia Cargo Inc.", date: "Sep 12, 2026" },
  { series: "RCV-2024-0887", warehouse: "WH-WEST-04", shipper: "Evergreen Supply Chain", date: "Sep 11, 2026" },
];

const expiringProducts = [
  { product: "Organic Oat Bran (5kg)", series: "OOB-2024-0041", qty: 240, expiration: "Sep 20, 2026", status: "critical" },
  { product: "Whey Protein Isolate", series: "WPI-2024-0078", qty: 88, expiration: "Sep 25, 2026", status: "critical" },
  { product: "Brown Rice Flour (2kg)", series: "BRF-2024-0099", qty: 312, expiration: "Oct 03, 2026", status: "warning" },
  { product: "Chia Seeds Premium", series: "CSP-2024-0055", qty: 156, expiration: "Oct 08, 2026", status: "warning" },
  { product: "Coconut Milk Powder", series: "CMP-2024-0033", qty: 74, expiration: "Oct 15, 2026", status: "ok" },
];

const agingInventory = [
  { product: "Dried Mango Strips", series: "DMS-2023-0012", bins: "A-04, A-05", qty: 180, days: 384 },
  { product: "Black Sesame Seeds", series: "BSS-2023-0018", bins: "B-11", qty: 95, days: 340 },
  { product: "Quinoa (White)", series: "QNW-2023-0024", bins: "C-07, C-08, C-09", qty: 448, days: 298 },
  { product: "Hemp Seeds Hulled", series: "HSH-2023-0031", bins: "D-02", qty: 67, days: 265 },
  { product: "Moringa Powder", series: "MRP-2023-0044", bins: "E-15", qty: 120, days: 241 },
];

const topProducts = [
  { product: "Rolled Oats Premium", qty: 4820 },
  { product: "Brown Rice (25kg)", qty: 3910 },
  { product: "Whey Protein Concentrate", qty: 2740 },
  { product: "Organic Quinoa", qty: 2380 },
  { product: "Chia Seeds", qty: 1950 },
  { product: "Coconut Flour", qty: 1640 },
];

const receivingVsPicking = [
  { date: "Sep 08", received: 412, picked: 380 },
  { date: "Sep 09", received: 295, picked: 440 },
  { date: "Sep 10", received: 540, picked: 310 },
  { date: "Sep 11", received: 380, picked: 495 },
  { date: "Sep 12", received: 620, picked: 520 },
  { date: "Sep 13", received: 448, picked: 385 },
  { date: "Sep 14", received: 310, picked: 290 },
];

const warehouseBreakdown = [
  { warehouse: "WH-NORTH-01", pallets: 284, utilization: 78, pending: 12 },
  { warehouse: "WH-SOUTH-03", pallets: 196, utilization: 54, pending: 4 },
  { warehouse: "WH-EAST-02", pallets: 341, utilization: 93, pending: 8 },
  { warehouse: "WH-WEST-04", pallets: 118, utilization: 32, pending: 2 },
  { warehouse: "WH-CENTRAL-05", pallets: 402, utilization: 86, pending: 19 },
];