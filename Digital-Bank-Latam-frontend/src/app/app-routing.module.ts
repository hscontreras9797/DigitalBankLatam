import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'client',
    pathMatch: 'full',
  },
  {
    path: 'client',
    loadChildren: () => import('./Modules/Client/client.module').then(m => m.ClientModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
