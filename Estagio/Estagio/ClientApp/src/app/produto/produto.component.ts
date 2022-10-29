import { Component, OnInit } from '@angular/core';
import { ProdutoDataService } from '../_data-services/produto.data-service';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {

  produtos: any[] = [];
  produto: any = {};
  showList: boolean = true;

  constructor(private produtoDataService: ProdutoDataService) { }

  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.produtoDataService.getAll().subscribe((data:any) => {
      this.produtos = data;
    }, error => {
      console.log(error);
      alert('erro interno do sistema - get produtos');
    })
  }

  post() {
    if (this.produtos.some(x => x.nome.trim().toLowerCase() == this.produto.nome.trim().toLowerCase() && x.marca.trim().toLowerCase() == this.produto.marca.trim().toLowerCase())) {
      alert('Já existe um produto ativo com este nome e marca!');
      return false;
    }
    if (this.produto.preco == 0) {
      alert('O produto deve ter valor maior que 0!');
      return false;  
    }
    if (this.produto.nome.trim() == '' || this.produto.marca.trim() == '') {
      alert('O nome/marca não podem estar vazios!');
      return false;  
    }
    this.produtoDataService.post(this.produto).subscribe(data => {
      if (data) {
        alert('Produto cadastrado com sucesso!');
        this.showList = true;
        this.produto = {};
        this.getAll();
      } else {
        alert('Erro ao cadastrar o produto!')
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema - post');  
    });
  }

  put() {
    this.produtoDataService.put(this.produto).subscribe(data => {
      if (data) {
        alert('Produto atualizado com sucesso!');
        this.showList = true;
        this.produto = {};
      } else {
        alert('Erro ao atualizar o produto!')
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema - put');  
    });
  }

  openDetails(produto) {
    this.showList = false;
    this.produto = produto;
  }

  save() {
    if (this.produto.id) {
      this.put()
    } else {
      this.post()
    }
  }

  voltar() {
    this.showList = true;
  }

  adicionarNovo() {
    this.produto = {};
    this.showList = false;
  }

  delete(produto) {
    this.produtoDataService.delete(produto.id).subscribe(data => {
      if (data) {
        alert('Produto excluído com sucesso!');
        this.getAll();
        this.produto = {};
      } else {
        alert('Erro ao excluir o produto!')
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema - delete');  
    });
  }
}
