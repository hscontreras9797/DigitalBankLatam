import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClientRoutingModule } from './client-routing.module';
import { ListComponent } from './Components/list/list.component';
import { AddComponent } from './Components/add/add.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { HttpClientModule } from '@angular/common/http';
import { ClientApiService } from './services/client.api.service';
import { MatCardModule } from '@angular/material/card';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { EditComponent } from './Components/edit/edit.component';
import {MatSelectModule} from '@angular/material/select';



@NgModule({
  declarations: [
    ListComponent,
    AddComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    ClientRoutingModule,
    NgxDatatableModule,
    HttpClientModule,
    MatCardModule,
    FlexLayoutModule,
    MatIconModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatInputModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSelectModule
  ],
  providers: [
    ClientApiService
  ]
})
export class ClientModule { }
