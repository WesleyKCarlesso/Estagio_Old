import { Component, OnInit } from '@angular/core';
import { ProdutoDataService } from '../_data-services/produto.data-service';

@Component({
  selector: 'app-compra',
  templateUrl: './compra.component.html',
  styleUrls: ['./compra.component.css']
})
export class CompraComponent implements OnInit {

  produtos: any[] = [];
  produtosSelecionados: any[] = [];
  compraFeita: boolean = false;

  constructor(private produtoDataService: ProdutoDataService) { }

  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.produtoDataService.getAll().subscribe((data:any[]) => {
      this.produtos = data;
    }, error => {
      console.log(error);
      alert('erro interno do sistema - get produtos');
    })
  }

  finalizarCompra() {
    this.compraFeita = true;
  }
}
