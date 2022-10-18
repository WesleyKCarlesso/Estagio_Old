import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsuarioDataService } from '../_data-services/usuario.data-service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  usuarios: any[] = [];
  usuario: any = {};
  usuarioLogado: any = {};
  usuarioLogin: any = {};
  showList: boolean = true;
  isAuthenticated: boolean = false;
  formulario: FormGroup;
  mostrarRealizarCompra: boolean = false;
  mostrarHistorico: boolean = false;
  mostrarEditarDados: boolean = false;

  constructor(
    private usuarioDataService: UsuarioDataService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.formulario = this.formBuilder.group({
      emailFormControl: [null, [Validators.required, Validators.email]]
    });
  }

  get() {
    this.usuarioDataService.get().subscribe((data:any[]) => {
      this.usuarios = data;
      this.showList = true;
    }, error => {
      console.log(error);
      alert('erro interno do sistema - get');
    });
  }

  save() {
    if (this.usuario.id) {
      this.put()
    } else {
      this.post()
    }
  }

  openDetails(usuario) {
    this.showList = false;
    this.usuario = usuario;
  }

  post() {
    this.usuarioDataService.post(this.usuario).subscribe(data => {
      if (data) {
        alert('Usuário cadastrado com sucesso!');
        this.showList = true;
        this.usuario = {};
      } else {
        alert('Erro ao cadastrar usuário!')
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema - post');  
    });
  }

  put() {
    this.usuarioDataService.put(this.usuario).subscribe(data => {
      if (data) {
        alert('Usuário atualizado com sucesso!');
        this.get();
        this.usuario = {};
      } else {
        alert('Erro ao atualizar usuário!')
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema - put');  
    });
  }

  delete() {
    this.usuarioDataService.delete().subscribe(data => {
      if (data) {
        alert('Usuário excluído com sucesso!');
        this.get();
        this.usuario = {};
      } else {
        alert('Erro ao excluir o usuário!')
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema - delete');  
    });
  }

  authenticate() {
    this.usuarioDataService.authenticate(this.usuarioLogin).subscribe((data:any) => {
      if (data.usuario) {
        localStorage.setItem('user_logged', JSON.stringify(data));
        this.get();
        this.getUserData();
      } else {
        alert('Usuário inválido!')
      }
    }, error => {
      console.log(error);
      alert('Usuário inválido');
    });
  }

  getUserData() {
    this.usuarioLogado = JSON.parse(localStorage.getItem('user_logged'));
    this.isAuthenticated = this.usuarioLogado != null;
  }

  mostrarTelaRealizarCompra() {
    this.mostrarRealizarCompra = true;
    this.mostrarHistorico = false;
    this.mostrarEditarDados = false;
  }

  mostrarTelaHistorico() {
    this.mostrarRealizarCompra = false;
    this.mostrarHistorico = true;
    this.mostrarEditarDados = false;
  }

  mostrarTelaEditarDados() {
    this.mostrarRealizarCompra = false;
    this.mostrarHistorico = false;
    this.mostrarEditarDados = true;
  }
  
  voltar() {
    this.mostrarRealizarCompra = false;
    this.mostrarHistorico = false;
    this.mostrarEditarDados = false;
  }

  voltarLogin() {
    this.isAuthenticated = false;

    this.usuarioLogin = {};
  }

  mudarLoginRegistro() {
    this.showList = !this.showList;

    this.usuario = {};
    this.usuarioLogin = {};
  }
}
