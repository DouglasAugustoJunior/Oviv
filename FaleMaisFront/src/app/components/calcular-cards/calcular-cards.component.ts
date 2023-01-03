import { Component, Input } from '@angular/core'
import { CurrencyPipe } from '@angular/common'

import { CardCalculoDTO } from 'src/app/models/card-calculo-dto.model'
import { Card } from 'src/app/models/card.model'

@Component({
  selector: 'app-calcular-cards',
  templateUrl: './calcular-cards.component.html'
})
export class CalcularCardsComponent {
  @Input() calculos: CardCalculoDTO[] = []

  constructor(private currencyPipe:CurrencyPipe) { }

  converterCalculoEmCard(calculo:CardCalculoDTO): Card {
    return {
      valor: this.currencyPipe.transform(calculo.totalPlano, 'R$'),
      descricao: calculo.plano,
      subDescricao: `Sem o plano: ${this.currencyPipe.transform(calculo.totalSemPlano, 'R$')}`
    }
  }

}
