import { Card } from './../../models/card.model';
import { Component, OnInit } from '@angular/core'

import { PlanoService } from './../../services/plano.service'
import { PlanoListagemDTO } from 'src/app/models/plano-listagem-dto.model'

@Component({
  selector: 'app-plano',
  templateUrl: './plano.component.html',
  styleUrls: ['./plano.component.less']
})
export class PlanoComponent implements OnInit {

  listaPlanos: PlanoListagemDTO[] = []

  constructor(private planoService: PlanoService) { }

  ngOnInit(): void {
    this.planoService
      .obterPlanos()
      .subscribe(planos => this.listaPlanos = planos)
  }

  converterPlanoEmCard(plano:PlanoListagemDTO): Card {
    return {
      valor: plano.minutosGratuitos,
      descricao: plano.nome
    }
  }
}
