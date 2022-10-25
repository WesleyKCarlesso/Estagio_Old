import { Component, OnInit } from '@angular/core';
import { CompraDataService } from '../_data-services/compra.data-service';
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
  total: any = 0.0;

  constructor(
    private produtoDataService: ProdutoDataService,
    private compraDataService: CompraDataService
  ) { }

  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.produtoDataService.getProdutosParaCompra().subscribe((data:any[]) => {
      this.produtos = data;
    }, error => {
      console.log(error);
      alert('erro interno do sistema - get produtos');
    })
  }

  realizarCompra() {
    let idUsuario = JSON.parse(localStorage.user_logged).usuario.id;
    this.compraDataService.realizarCompra(this.produtos).subscribe(data => {
      if (data) {
        alert('Compra realizada com sucesso!');
        this.produtos;
        this.produtos.forEach(x => {
          this.total += (x.quantidade * x.preco);
        });
        this.total = Math.round(this.total*100)/100;
        this.compraFeita = true;
      } else {
        alert('Erro ao realizar a compra!')
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema - realizar compra');  
    });
  }
}
