import { NgModule } from '@angular/core'
import { Routes, RouterModule } from '@angular/router'

import { PlanoComponent } from './pages/plano/plano.component'
import { TarifasComponent } from './pages/tarifas/tarifas.component'
import { DDDComponent } from './pages/ddd/ddd.component'
import { AutenticacaoGuard } from './guards/autenticacao.guard'
import { LoginComponent } from './pages/login/login.component'
import { CalcularValoresComponent } from './components/calcular-valores/calcular-valores.component'
import { AdministradorGuard } from './guards/administrador.guard'
import { UsuarioComponent } from './pages/usuario/usuario.component'
import { PaginaNaoEncontradaComponent } from './components/pagina-nao-encontrada/pagina-nao-encontrada.component'

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    children: [
      { path: '', component: CalcularValoresComponent }
    ],
    canActivate: [AutenticacaoGuard]
  },
  {
    path: 'login',
    canActivate: [AutenticacaoGuard],
    component: LoginComponent
  },
  {
    path: 'ddd',
    canActivate: [
      AutenticacaoGuard,
      AdministradorGuard
    ],
    component: DDDComponent
  },
  {
    path: 'usuarios',
    canActivate: [
      AutenticacaoGuard,
      AdministradorGuard
    ],
    component: UsuarioComponent
  },
  {
    path: 'tarifas',
    canActivate: [
      AutenticacaoGuard,
      AdministradorGuard
    ],
    component: TarifasComponent
  },
  {
    path: 'planos',
    canActivate: [
      AutenticacaoGuard
    ],
    component: PlanoComponent
  },
  {
    path: '**',
    pathMatch: 'full',
    children: [
      { path: '', component: PaginaNaoEncontradaComponent }
    ],
    canActivate: [
      AutenticacaoGuard
    ]
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
