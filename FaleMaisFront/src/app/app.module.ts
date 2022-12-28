import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { CommonModule, registerLocaleData } from '@angular/common'
import pt from '@angular/common/locales/pt'
import { FormsModule } from '@angular/forms'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { NzNotificationModule } from 'ng-zorro-antd/notification'
import { NZ_I18N } from 'ng-zorro-antd/i18n'
import { pt_BR } from 'ng-zorro-antd/i18n'

import { LoginModule } from './pages/login/login.module'
import { HomeModule } from './pages/home/home.module'
import { AppComponent } from './app.component'
import { AppRoutingModule } from './app-routing.module'
import { DDDModule } from './pages/ddd/ddd.module'
import { RequisicoesInterceptor } from './interceptors/requisicoes.interceptor'
import { UsuarioModule } from './pages/usuario/usuario.module'
import { TarifasModule } from './pages/tarifas/tarifas.module'
import { PlanoModule } from './pages/plano/plano.module'
import { CalcularFormularioModule } from './components/calcular-formulario/calcular-formulario.module'
import { CalcularCardsModule } from './components/calcular-cards/calcular-cards.module'
import { CalcularValoresModule } from './components/calcular-valores/calcular-valores.module'
import { PaginaNaoEncontradaModule } from './components/pagina-nao-encontrada/pagina-nao-encontrada.module'

registerLocaleData(pt)

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NzNotificationModule,
    HomeModule,
    LoginModule,
    DDDModule,
    UsuarioModule,
    TarifasModule,
    PlanoModule,
    CalcularValoresModule,
    CalcularFormularioModule,
    CalcularCardsModule,
    PaginaNaoEncontradaModule
  ],
  providers: [
    { provide: NZ_I18N, useValue: pt_BR },
    { provide: HTTP_INTERCEPTORS, useClass: RequisicoesInterceptor, multi: true }
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }
