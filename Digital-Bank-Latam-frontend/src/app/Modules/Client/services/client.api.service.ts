import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BehaviorSubject, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Clients } from '../Models/client.model';

@Injectable({
  providedIn: 'root'
})
export class ClientApiService {

  private readonly destroy$ = new Subject();

  private readonly httpClient: HttpClient;

  private readonly snackBar: MatSnackBar;

  private _clients: Clients[] = [];

  private _client: Clients | null = null;

  private bsClient = new BehaviorSubject<Clients | null>(null);

  public get client$() {
    return this.bsClient.asObservable();
  }

  constructor(client: HttpClient, snackBar: MatSnackBar) {
    this.httpClient = client;
    this.snackBar = snackBar;
  }

  public get clients() {
    return this._clients;
  }

  public get client() {
    return this._client;
  }

  load(state: boolean) {
    this.httpClient.get<Clients[]>(`https://localhost:44347/api/Usuarios/GetBySet?state=${state}`)
      .pipe(
        takeUntil(this.destroy$)
      )
      .subscribe(response => this._clients = response)
  }

  create(data: Clients) {
    this.httpClient.post<Clients>(`https://localhost:44347/api/Usuarios`, data)
      .pipe(
        takeUntil(this.destroy$)
      )
      .subscribe(response => {
        this._client = response;
        this.snackBar.open(`El Usuario se creo correctamente con el id ${this._client.id}`, 'X')
      })
  }

  delete(data: Clients) {
    this.httpClient.delete<boolean>(`https://localhost:44347/api/Usuarios/${data.id}`)
      .pipe(
        takeUntil(this.destroy$)
      )
      .subscribe(success => {
        if (success) {
          this.snackBar.open(`El Usuario se elimino correctamente con el id ${data.id}`, 'X')
          this.load(true);
        } else {
          this.snackBar.open(`El Usuario no se pudo eliminar`, 'X')
        }
      })
  }

  update(id: number, data: Clients) {
    this.httpClient.put<boolean>(`https://localhost:44347/api/Usuarios/${id}`, data)
      .pipe(
        takeUntil(this.destroy$)
      )
      .subscribe(success => {
        if (success) {
          this.snackBar.open(`El usuario se actualizo correctamente con el id ${id}`, 'X');
          this.load(true);
        } else {
          this.snackBar.open(`El usuario no se pudo actualizar`, 'X')
        }
      })
  }

}
