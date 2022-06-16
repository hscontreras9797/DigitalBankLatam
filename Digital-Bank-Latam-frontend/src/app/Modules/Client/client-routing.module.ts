import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddComponent } from './Components/add/add.component';
import { EditComponent } from './Components/edit/edit.component';
import { ListComponent } from './Components/list/list.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'list'
  },
  {
    path: 'list',
    component: ListComponent
  },
  {
    path: 'add',
    component: AddComponent
  },
  {
    path: 'edit/:id',
    component: EditComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientRoutingModule { }
