# WMS Frontend Migration Plan: Blazor to Angular

## Overview
Complete migration of WMS frontend from Blazor Server to Angular 22. Replace the entire frontend with Angular implementation using standalone components, signals, and new control flow syntax.

## Prerequisites
- Angular 22 with standalone components
- Tailwind CSS v4
- ng-openapi-gen for API client generation
- RxJS for async operations
- Reuse existing Angular shared components (StatCard, TableCard, UtilBar, Icon, LayoutService)

## Migration Strategy
1. **Route Structure** - Define all Angular routes
2. **API Services** - Leverage generated API client
3. **Core Layout** - Main layout with sidebar navigation
4. **Dashboard** - KPI cards, real-time data
5. **Master Data Pages** - Products, Warehouses, Pallets, Suppliers, Customers
6. **Workflow Operations** - Item Receipt, Check-In, Pick Order, Cycle Count, Transfer
7. **Mobile Operations** - Touch-optimized interface
8. **Tables & Forms** - Paginated, filterable, validated components

## Detailed Implementation Steps

### Phase 1: Foundation & Routes
#### 1.1 Update app.routes.ts
- Create routes for all pages:
  - `/` - Home/Dashboard
  - `/login` - Login (existing)
  - `/mobile-app` - Mobile operations (existing placeholder)
  - `/products` - Product management
  - `/warehouses` - Warehouse management
  - `/pallets` - Pallet management
  - `/suppliers` - Supplier management
  - `/customers` - Customer management
  - `/receiving` - Item Receipt workflow
  - `/check-in` - Check-In workflow
  - `/pick-order` - Pick Order (Manual Picking) workflow
  - `/cycle-count` - Cycle Count workflow
  - `/transfer` - Transfer workflow

#### 1.2 Verify Shared Components
- StatCard (src/app/shared/stat-card/)
- TableCard (src/app/shared/table-card/)
- UtilBar (src/app/shared/util-bar/)
- Icon (src/app/shared/icon/)
- LayoutService (src/app/lib/services/layout.service.ts)

### Phase 2: Core Layout & Navigation
#### 2.1 Main Layout
- Update src/app/layout/main-layout/main-layout.component.ts
- Maintain sidebar navigation with all routes
- Include responsive header with user info/logout
- RouterOutlet for page content

#### 2.2 Sidebar Navigation
- Update src/app/shared/layout/sidebar/sidebar.component.ts/.html
- Navigation items for all master data and workflow pages
- Icons for each section
- Active route highlighting

### Phase 3: Dashboard Implementation
#### 3.1 Home Component
- File: src/app/pages/home/home.component.ts/.html
- Use LayoutService for responsive classes
- KPI StatCards showing:
  - Total Products
  - Total Warehouses
  - Total Pallets
  - Pending Receipts
  - Today's Check-ins
  - Pick Orders Due
- Recent activity table (receiving/warehouse movements)
- Quick action buttons for common workflows

#### 3.2 Data Sources
- GET /api/warehouse/v2 - WarehouseDetailsDto[] (paginated)
- GET /api/product/v2 - ProductSummaryDto[] (paginated)
- GET /api/pallet/v2 - PalletSummaryDto[] (paginated)
- GET /api/receiving/v2 - ReceivingSummaryDto[] (paginated)
- GET /api/check-in/v2 - CheckInSummaryDto[] (paginated)

### Phase 4: Master Data Pages
Each master data page follows the same pattern:
- List view with server-side pagination, filtering, sorting
- Create/Edit forms with validation
- Detail view
- Delete functionality

#### 4.1 Products Page
- Route: /products
- Components:
  - products-list.component.ts/.html
  - product-form.component.ts/.html (create/edit)
  - product-detail.component.ts/.html
- API Endpoints:
  - GET /api/product/v2 (PaginatedResponse<ProductSummaryDto>)
  - GET /api/product/{id} (ProductDetailsDto)
  - POST /api/product (CreateProductDto)
  - PUT /api/product/{id} (UpdateProductDto)
  - DELETE /api/product/{id}

#### 4.2 Warehouses Page
- Route: /warehouses
- Components:
  - warehouses-list.component.ts/.html
  - warehouse-form.component.ts/.html
  - warehouse-detail.component.ts/.html
- API Endpoints:
  - GET /api/warehouse/v2 (PaginatedResponse<WarehouseDetailsDto>)
  - GET /api/warehouse/{id} (WarehouseDetailsDto)
  - POST /api/warehouse (CreateWarehouseDto)
  - PUT /api/warehouse/{id} (UpdateWarehouseDto)
  - DELETE /api/warehouse/{id}

#### 4.3 Pallets Page
- Route: /pallets
- Components:
  - pallets-list.component.ts/.html
  - pallet-form.component.ts/.html
  - pallet-detail.component.ts/.html
- API Endpoints:
  - GET /api/pallet/v2 (PaginatedResponse<PalletSummaryDto>)
  - GET /api/pallet/{id} (PalletSummaryDto)
  - POST /api/pallet (CreatePalletDto)
  - PUT /api/pallet/{id} (UpdatePalletDto)
  - DELETE /api/pallet/{id}

#### 4.4 Suppliers Page
- Route: /suppliers
- Components:
  - suppliers-list.component.ts/.html
  - supplier-form.component.ts/.html
  - supplier-detail.component.ts/.html
- API Endpoints (need to verify existence):
  - GET /api/supplier/v2 (if exists)
  - GET /api/supplier/{id}
  - POST /api/supplier
  - PUT /api/supplier/{id}
  - DELETE /api/supplier/{id}

#### 4.5 Customers Page
- Route: /customers
- Components:
  - customers-list.component.ts/.html
  - customer-form.component.ts/.html
  - customer-detail.component.ts/.html
- API Endpoints (need to verify existence):
  - GET /api/customer/v2 (if exists)
  - GET /api/customer/{id}
  - POST /api/customer
  - PUT /api/customer/{id}
  - DELETE /api/customer/{id}

### Phase 5: Workflow Operations
Each workflow follows a similar pattern with specific business logic.

#### 5.1 Item Receipt (Receiving)
- Route: /receiving
- Components:
  - receiving-list.component.ts/.html
  - receiving-form.component.ts/.html (create/edit)
  - receiving-detail.component.ts/.html
  - receiving-items.component.ts/.html (embedded in form)
- API Endpoints:
  - GET /api/receiving/v2 (PaginatedResponse<ReceivingSummaryDto>)
  - GET /api/receiving/{id} (ReceivingDetailsDto)
  - POST /api/receiving (CreateReceivingDto)
  - PUT /api/receiving/{id} (CreateReceivingDto for update)
  - DELETE /api/receiving/{id}
- Special Features:
  - QR code scanning for product/pallet lookup
  - Dynamic item addition/removal
  - CBM/weight calculation
  - Container/pallet association

#### 5.2 Check-In
- Route: /check-in
- Components:
  - check-in-list.component.ts/.html
  - check-in-form.component.ts/.html
  - check-in-detail.component.ts/.html
  - check-in-products.component.ts/.html
- API Endpoints:
  - GET /api/check-in/v2 (PaginatedResponse<CheckInSummaryDto>)
  - GET /api/check-in/{id} (CheckInDetailsDto)
  - POST /api/check-in (CreateCheckInDto)
  - PUT /api/check-in/{id} (CreateCheckInDto for update)
  - DELETE /api/check-in/{id}
- Special Features:
  - Bin selection with availability checking
  - Product validation against PO
  - Quantity received vs expected
  - Expiration date handling

#### 5.3 Pick Order (Manual Picking)
- Route: /pick-order
- Components:
  - pick-order-list.component.ts/.html
  - pick-order-form.component.ts/.html
  - pick-order-detail.component.ts/.html
  - pick-order-items.component.ts/.html
- API Endpoints:
  - GET /api/manual-picking/v2 (PaginatedResponse<ManualPickingSummaryDto>)
  - GET /api/manual-picking/{id} (ManualPickingDetailsDto)
  - POST /api/manual-picking (CreateManualPickingDto)
  - PUT /api/manual-picking/{id} (CreateManualPickingDto for update)
  - DELETE /api/manual-picking/{id}
- Special Features:
  - Wave/pick list generation
  - Bin-to-bin routing
  - Quantity picking confirmation
  - Destination bin validation

#### 5.4 Cycle Count
- Route: /cycle-count
- Components:
  - cycle-count-list.component.ts/.html
  - cycle-count-form.component.ts/.html
  - cycle-count-detail.component.ts/.html
  - cycle-count-items.component.ts/.html
- API Endpoints (need to verify existence):
  - GET /api/cycle-count/v2 (if exists)
  - GET /api/cycle-count/{id}
  - POST /api/cycle-count
  - PUT /api/cycle-count/{id}
  - DELETE /api/cycle-count/{id}
- Special Features:
  - Count sheet generation
  - Variance tracking
  - Approval workflow
  - Adjustment posting

#### 5.5 Transfer
- Route: /transfer
- Components:
  - transfer-list.component.ts/.html
  - transfer-form.component.ts/.html
  - transfer-detail.component.ts/.html
  - transfer-items.component.ts/.html
- API Endpoints (need to verify existence):
  - GET /api/transfer/v2 (if exists)
  - GET /api/transfer/{id}
  - POST /api/transfer
  - PUT /api/transfer/{id}
  - DELETE /api/transfer/{id}
- Special Features:
  - Source/destination warehouse selection
  - Transfer document creation
  - In-transit tracking
  - Receipt confirmation

### Phase 6: Mobile Operations
#### 6.1 Mobile App Page
- Route: /mobile-app
- Component: src/app/pages/mobile-app/mobile-app.component.ts/.html
- Touch-friendly interface for warehouse staff
- Large buttons for each workflow:
  - Item Receipt
  - Check-In
  - Pick Order
  - Cycle Count
  - Transfer
  - Products (lookup)
- Offline capability consideration
- Barcode/QR scanning integration
- Location-based features

### Phase 7: Tables & Data Components
#### 7.1 Paginated Table Component
- Reusable table component with:
  - Server-side pagination
  - Column sorting
  - Client-side filtering (search)
  - Row selection
  - Actions column (view/edit/delete)
  - Loading states
  - Empty states
  - Error handling

#### 7.2 Form Components
- Reactive forms with:
  - Field-level validation matching API DTOs
  - Cross-field validation (e.g., dates, quantities)
  - Async validation (uniqueness checks)
  - Reset functionality
  - Submit/loading states

### Phase 8: API Integration
#### 8.1 Generated API Client
- Use src/app/api/generated/ApiService
- Leverage generated functions.ts and models.ts
- Create service wrappers for each entity:
  - ProductService
  - WarehouseService
  - PalletService
  - ReceivingService
  - CheckInService
  - ManualPickingService
  - etc.

#### 8.2 Error Handling
- HttpInterceptor for:
  - Token attachment (when auth implemented)
  - Global error handling
  - Loading indicators
  - Retry logic (configurable)

#### 8.3 Response Mapping
- Map API responses to UI models
- Handle pagination metadata
- Transform dates/formatting
- Handle null/undefined values

### Phase 9: Validation & Forms
#### 9.1 DTO-Based Validation
- Extract validation rules from generated DTOs
- Implement reactive form validators:
  - Required fields
  - Min/max lengths
  - Pattern validation (email, etc.)
  - Min/max values
  - Custom validation functions

#### 9.2 Form States
- Pristine/Dirty/Touched tracking
- Validation feedback (inline messages)
- Submit disabling when invalid
- Reset to initial state

### Phase 10: Responsive Design
#### 10.1 Breakpoints
- Mobile: < 640px
- Tablet: 640px - 1024px
- Desktop: > 1024px

#### 10.2 Layout Adaptations
- Sidebar: collapsible on mobile
- Tables: horizontal scroll on small screens
- Forms: stacked vs inline layouts
- Cards: full-width on mobile, grid on desktop
- Navigation: bottom navigation on mobile

## Technical Implementation Details

### State Management
- Use Angular Signals for local component state
- Services for shared state (cart, selections, etc.)
- Consider NgRx for complex state if needed

### Styling
- Tailwind CSS v4 utility-first approach
- Custom CSS only when necessary
- Dark/light mode consideration
- Consistent spacing and typography

### Performance
- Lazy loading of feature modules
- TrackBy functions for *ngFor
- OnPush change detection where applicable
- Image optimization
- Bundle analysis

### Accessibility
- ARIA labels and roles
- Keyboard navigation
- Focus management
- Screen reader support
- Color contrast compliance

### Error Handling & UX
- Toast notifications (success/error/warning)
- Confirmation dialogs for destructive actions
- Loading skeletons/spinners
- Offline indicators
- Form validation feedback

## Verification Checklist
- [ ] All V2 GET endpoints utilized
- [ ] Server-side pagination implemented where available
- [ ] Forms validate against API DTO constraints
- [ ] Mobile-responsive layouts tested
- [ ] Shared components reused effectively
- [ ] Loading states for all async operations
- [ ] Error handling for API failures
- [ ] Empty states for data tables
- [ ] Navigation flows tested
- [ ] URL parameters for deep linking
- [ ] Browser back/forward button support
- [ ] Accessibility audits passed

## Estimated Effort
- Phase 1-2: 2 days
- Phase 3: 1 day
- Phase 4: 3 days
- Phase 5: 4 days
- Phase 6: 1 day
- Phase 7-8: 2 days
- Phase 9-10: 2 days
- Total: ~15 days

## Risks & Mitigations
- **Risk**: Missing API endpoints
  - **Mitigation**: Verify all endpoints exist before implementation
- **Risk**: Complex workflow logic
  - **Mitigation**: Break into small, testable components
- **Risk**: Performance with large datasets
  - **Mitigation**: Implement virtual scrolling, efficient change detection
- **Risk**: Mobile usability
  - **Mitigation**: Test on actual devices, use touch-friendly controls

## Open Questions
1. Do Suppliers and Customers endpoints exist in the API?
2. Are Cycle Count and Transfer endpoints implemented?
3. What authentication method will be used (JWT, etc.)?
4. Are there any WebSocket requirements for real-time updates?
5. What are the exact validation rules from the DTOs?

## Next Steps
1. Verify all required API endpoints exist
2. Begin implementing routes and navigation
3. Create shared table and form components
4. Implement dashboard with real data
5. Build master data pages (products, warehouses, pallets)
6. Implement workflow operations
7. Build mobile operations page
8. Add responsive breakpoints and testing
9. Implement validation and error handling
10. Final polishing and accessibility review