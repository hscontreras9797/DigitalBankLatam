import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Clients } from '../../Models/client.model';
import { ClientApiService } from '../../services/client.api.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss']
})
export class AddComponent implements OnInit {

  private clientApiService: ClientApiService;
  private router: Router;
  private activatedRoute: ActivatedRoute;

  public formGroup: FormGroup;

  public get client() {
    return this.clientApiService.client;
  }


  constructor(formBuilder: FormBuilder, clientApiService: ClientApiService, router: Router, activatedRoute: ActivatedRoute) {
    this.clientApiService = clientApiService;
    this.router = router;
    this.activatedRoute = activatedRoute;

    this.formGroup = formBuilder.group({
      'name': ['', Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(64)])],
      'Fecha_Nacimiento': ['', Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(64)])],
      'sexo': ['', Validators.compose([Validators.required, Validators.minLength(1), Validators.maxLength(1)])],
      'state': [true]
    });
  }

  ngOnInit(): void {
    this.clientApiService.load(true);
  }

  onList() {
    this.router.navigate(['../list'], { relativeTo: this.activatedRoute });
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

    this.clientApiService.create(data);

    setTimeout(() => { this.router.navigate(['../list'], { relativeTo: this.activatedRoute }); }, 200)
  }
}
