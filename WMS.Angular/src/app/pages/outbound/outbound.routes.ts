import type { Routes } from '@angular/router';

export const outboundRoutes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./outbound-workflow.component').then((module) => module.OutboundWorkflowComponent),
    data: { breadcrumb: 'Outbound Workflow' },
  },
  {
    path: 'kanban',
    loadComponent: () =>
      import('./outbound-workflow-kanban.component').then(
        (module) => module.OutboundWorkflowKanbanComponent,
      ),
    data: { breadcrumb: 'Kanban Board' },
  },
];