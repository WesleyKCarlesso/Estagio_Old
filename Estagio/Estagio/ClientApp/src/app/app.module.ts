import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { UsuarioDataService } from './_data-services/usuario.data-service';
import { Interceptor } from 'src/app.interceptor.module';
import { CompraComponent } from './compra/compra.component';
import { AreaSupervisorComponent } from './areaSupervisor/areaSupervisor.component';
import { ProdutoComponent } from './produto/produto.component';
import { EstoqueComponent } from './estoque/estoque.component';
import { ProdutoDataService } from './_data-services/produto.data-service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UsuariosComponent,
    CompraComponent,
    AreaSupervisorComponent,
    ProdutoComponent,
    EstoqueComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'usuario', component: UsuariosComponent },
      { path: 'compra', component: CompraComponent },
      { path: 'areaSupervisor', component: AreaSupervisorComponent },
      { path: 'produto', component: ProdutoComponent },
      { path: 'estoque', component: EstoqueComponent },
    ]),
    Interceptor
  ],
  providers: [
    UsuarioDataService,
    ProdutoDataService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
