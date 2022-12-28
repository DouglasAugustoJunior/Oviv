import { Component } from '@angular/core'

import { AutenticacaoService } from 'src/app/services/autenticacao.service'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less']
})
export class HomeComponent {
  isCollapsed = false

  constructor(private autenticacaoService: AutenticacaoService) { }

  get estaAutenticado():boolean{
    return this.autenticacaoService.estaLogado
  }
}
