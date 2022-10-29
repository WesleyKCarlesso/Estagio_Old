import { Component, OnInit } from '@angular/core';
import { ProdutoDataService } from '../_data-services/produto.data-service';

@Component({
  selector: 'app-estoque',
  templateUrl: './estoque.component.html',
  styleUrls: ['./estoque.component.css']
})
export class EstoqueComponent implements OnInit {

  mostrarConsultarEstoque: boolean = false;
  mostrarRealizarCompra: boolean = false;
  produtos: any[] = [];
  produtosFiltrados: any[] = [];

  constructor(
    private produtoDataService: ProdutoDataService
  ) { }

  ngOnInit() {
    this.getProdutosEstoque();
  }

  getProdutosEstoque() {
    this.produtoDataService.getAll().subscribe((data:any) => {
      this.produtos = data;
      this.produtosFiltrados = data;
    }, error => {
      console.log(error);
      alert('erro interno do sistema - get produtos estoque');
    })
  }

  filtrar(txt) {
    txt = txt.trim().toLowerCase();
    if (txt != '') {
      this.produtosFiltrados = this.produtos.filter(x => x.nome.toLowerCase().includes(txt));
    }
  }

  realizarCompraEstoque() {
    this.produtoDataService.realizarCompraEstoque(this.produtos).subscribe(data => {
      if (data) {
        alert('Compra realizada com sucesso!');
        this.getProdutosEstoque();
        this.mostrarRealizarCompra = false;
      } else {
        alert('Erro ao realizar a compra!')
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema - realizar compra estoque');  
    });
  }

  mostrarTelaConsultarEstoque() {
    this.mostrarConsultarEstoque = true;
    this.mostrarRealizarCompra = false;
  }

  mostrarTelaRealizarCompra() {
    this.mostrarConsultarEstoque = false;
    this.mostrarRealizarCompra = true;
  }
}
