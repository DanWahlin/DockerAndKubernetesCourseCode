import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CustomersComponent }     from './customers/customers.component';

const routes: Routes = [
  { path: '',  pathMatch:'full', redirectTo: '/customers' },
  { path: 'customers', component: CustomersComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
