import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { UsuarioDataService } from './_data-services/usuario.data-service';
import { Interceptor } from 'src/app.interceptor.module';
import { CompraComponent } from '../compra/compra.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UsuariosComponent,
    CompraComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'usuarios', component: UsuariosComponent },
      { path: 'compras', component: CompraComponent },
    ]),
    Interceptor
  ],
  providers: [UsuarioDataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
