import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-areaSupervisor',
  templateUrl: './areaSupervisor.component.html',
  styleUrls: ['./areaSupervisor.component.css']
})
export class AreaSupervisorComponent implements OnInit {

  isAuthenticated: boolean = false;

  constructor() { }

  ngOnInit() {
  }

  authenticate() {
    if (this.isAuthenticated) {
      this.isAuthenticated = false;
    }
    else {
      this.isAuthenticated = true;
    }
  }

}
