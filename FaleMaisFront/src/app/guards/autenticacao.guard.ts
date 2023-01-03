import { Injectable } from '@angular/core'
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router'

import { AutenticacaoService } from '../services/autenticacao.service'

@Injectable({
  providedIn: 'root'
})
export class AutenticacaoGuard implements CanActivate {

  constructor(
    private autenticacaoService: AutenticacaoService,
    private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot): boolean {
    let estaLogado = this.autenticacaoService.estaLogado
    if(route.routeConfig?.path == 'login')
      return this.validarAcessoParaLogin(estaLogado)
    return this.validarAcessoParaAplicacao(estaLogado)
  }

  validarAcessoParaLogin(estaLogado:boolean): boolean {
    if(estaLogado){
      this.router.navigateByUrl('')
      return false
    }
    return true
  }

  validarAcessoParaAplicacao(estaLogado: boolean): boolean {
    if(estaLogado)
      return true
    this.router.navigateByUrl('login')
    return false
  }

}