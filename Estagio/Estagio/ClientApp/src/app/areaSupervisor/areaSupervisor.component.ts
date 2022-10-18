import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-areaSupervisor',
  templateUrl: './areaSupervisor.component.html',
  styleUrls: ['./areaSupervisor.component.css']
})
export class AreaSupervisorComponent implements OnInit {

  isAuthenticated: boolean = false;
  mostrarProdutos: boolean = false;
  mostrarEstoque: boolean = false;
  mostrarHistorico: boolean = false;

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

  mostrarTelaProdutos() {
    this.mostrarProdutos = true;
    this.mostrarEstoque = false;
    this.mostrarHistorico = false;
  }

  mostrarTelaEstoque() {
    this.mostrarProdutos = false;
    this.mostrarEstoque = true;
    this.mostrarHistorico = false;
  }

  mostrarTelaHistorico() {
    this.mostrarProdutos = false;
    this.mostrarEstoque = false;
    this.mostrarHistorico = true;
  }
}
