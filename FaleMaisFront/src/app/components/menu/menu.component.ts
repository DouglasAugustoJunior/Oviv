import { Component, Input } from '@angular/core'
import { NzMenuModeType } from 'ng-zorro-antd/menu'

import { AutenticacaoService } from './../../services/autenticacao.service'

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.less']
})
export class MenuComponent {
  @Input() modo: NzMenuModeType = 'horizontal'

  constructor(private autenticacaoService: AutenticacaoService) { }

  deslogar = ():void =>
    this.autenticacaoService.deslogar()

  get EhUsuarioAdministrador():boolean {
    return this.autenticacaoService.obterAutorizacaoUsuarioLogado == 'Administrador'
  }
}
