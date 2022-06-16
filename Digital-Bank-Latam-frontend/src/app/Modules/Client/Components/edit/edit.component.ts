import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Clients } from '../../Models/client.model';
import { ClientApiService } from '../../services/client.api.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent  {

  private clientApiService: ClientApiService;
  private router: Router;
  private activatedRoute: ActivatedRoute;

  public formGroup: FormGroup;

  public client$: Observable<Clients | null> = new Observable<Clients | null>();

  constructor(formBuilder: FormBuilder, clientApiService: ClientApiService, router: Router, activatedRoute: ActivatedRoute) {
    this.clientApiService = clientApiService;
    this.router = router;
    this.activatedRoute = activatedRoute;

    this.client$ = this.clientApiService.client$.pipe(
      tap((response) => {
        this.formGroup.get('name')?.setValue(response?.name);
        this.formGroup.get('fecha_nacimiento')?.setValue(response?.fecha_Nacimiento);
        this.formGroup.get('Sexo')?.setValue(response?.sexo);
        this.formGroup.get('state')?.setValue(response?.state);
      })
    );

    this.formGroup = formBuilder.group({
      'name': ['', Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(64)])],
      'Fecha_Nacimiento': ['', Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(64)])],
      'sexo': ['', Validators.compose([Validators.required, Validators.minLength(1), Validators.maxLength(1)])],
      'state': [true]
    });


  }

  public get client() {
    return this.clientApiService.client;
  }

  onList() {
    this.router.navigate(['../../list'], { relativeTo: this.activatedRoute });
  }

  onSubmit() {
    if (this.formGroup.invalid)
      return;

    const value = this.formGroup.value;

    console.log('Valor del formulario', value);

    const data: Clients = {
      name: value.name,
      fecha_Nacimiento: value.Fecha_Nacimiento,
      sexo: value.sexo,
      state: value.state,
      dateCreated: new Date(),
      id: 0,
    }

    const id = this.activatedRoute.snapshot.paramMap.get("id");

    this.clientApiService.update(+(id || 0), data);

    setTimeout(() => { this.router.navigate(['../../list'], { relativeTo: this.activatedRoute }); }, 200)
  }
}
