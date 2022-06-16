import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Clients } from '../../Models/client.model';
import { ClientApiService } from '../../services/client.api.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {

  private clientApiService: ClientApiService;
  private router: Router;
  private activatedRoute: ActivatedRoute;


  public get rows() {
    return this.clientApiService.clients;
  }

  constructor(clientApiService: ClientApiService, router: Router, activatedRoute: ActivatedRoute) {
    this.clientApiService = clientApiService;
    this.router = router;
    this.activatedRoute = activatedRoute;
  }

  ngOnInit(): void {
    this.clientApiService.load(true);
  }

  onAdd() {
    this.router.navigate(['../add'], { relativeTo: this.activatedRoute });
  }

  onDelete(row: Clients) {
    this.clientApiService.delete(row);
  }

  onUpdate(row: Clients) {
    this.router.navigate(['../edit', row.id], { relativeTo: this.activatedRoute });
  }
}
