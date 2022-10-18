import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-estoque',
  templateUrl: './estoque.component.html',
  styleUrls: ['./estoque.component.css']
})
export class EstoqueComponent implements OnInit {

  mostrarConsultarEstoque: boolean = false;
  mostrarRealizarCompra: boolean = false;
  mostrarConsultarHistorico: boolean = false;

  constructor() { }

  ngOnInit() {
  }

  mostrarTelaConsultarEstoque() {
    this.mostrarConsultarEstoque = true;
    this.mostrarRealizarCompra = false;
    this.mostrarConsultarHistorico = false;
  }

  mostrarTelaRealizarCompra() {
    this.mostrarConsultarEstoque = false;
    this.mostrarRealizarCompra = true;
    this.mostrarConsultarHistorico = false;
  }

  mostrarTelaConsultarHistorico() {
    this.mostrarConsultarEstoque = false;
    this.mostrarRealizarCompra = false;
    this.mostrarConsultarHistorico = true;
  }
}
