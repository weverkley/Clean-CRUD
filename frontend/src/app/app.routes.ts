import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./modules/customer/customer.component').then(
        (m) => m.CustomerComponent
      ),
  },
];
