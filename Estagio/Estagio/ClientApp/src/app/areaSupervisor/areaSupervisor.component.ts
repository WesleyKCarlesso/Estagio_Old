import { Component, OnInit } from '@angular/core';
import { UsuarioDataService } from '../_data-services/usuario.data-service';

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
  usuarioLogin: any = {};

  constructor(private usuarioDataService: UsuarioDataService) { }

  ngOnInit() {
  }

  // authenticate() {
  //   if (this.isAuthenticated) {
  //     this.isAuthenticated = false;
  //   }
  //   else {
  //     this.isAuthenticated = true;
  //   }
  // }

  authenticateAdmin() {
    this.usuarioDataService.authenticateAdmin(this.usuarioLogin).subscribe((data:any) => {
      if (data.usuario) {
        this.isAuthenticated = true;
      } else {
        alert('Usuário inválido!')
      }
    }, error => {
      console.log(error);
      alert('Usuário inválido');
    });
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
