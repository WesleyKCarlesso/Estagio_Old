import { Component, OnInit } from '@angular/core';
import { UsuarioDataService } from '../_data-services/usuario.data-service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  usuarios: any[] = [];
  usuario: any = {};
  showList: boolean = true;

  constructor(private usuarioDataService: UsuarioDataService) { }

  ngOnInit() {
    this.get();
  }

  get() {
    this.usuarioDataService.get().subscribe((data:any[]) => {
      this.usuarios = data;
      this.showList = true;
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    })
  }

  save() {
    debugger;
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
        this.get();
        this.usuario = {};
      } else {
        alert('Erro ao cadastrar usuário!')
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema');  
    })
  }

  put() {
    this.usuarioDataService.put(this.usuario).subscribe(data => {
      if (data) {
        alert('Usuário atualizado com sucesso!');
        this.get();
        this.usuario = {};
      } else {
        alert('Erro ao cadastrar usuário!')
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema');  
    })
  }

  delete(usuario) {
    this.usuarioDataService.delete(usuario.id).subscribe(data => {
      if (data) {
        alert('Usuário excluído com sucesso!');
        this.get();
        this.usuario = {};
      } else {
        alert('Erro ao excluir o usuário!')
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema');  
    })
  }
}
