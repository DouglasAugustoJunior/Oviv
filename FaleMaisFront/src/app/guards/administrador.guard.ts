import { Injectable } from '@angular/core'
import { CanActivate } from '@angular/router'

import { AutenticacaoService } from './../services/autenticacao.service'

@Injectable({
  providedIn: 'root'
})
export class AdministradorGuard implements CanActivate {

  constructor(private autenticacaoService: AutenticacaoService) { }

  canActivate = (): boolean =>
    this.autenticacaoService.obterAutorizacaoUsuarioLogado == 'Administrador'
}
