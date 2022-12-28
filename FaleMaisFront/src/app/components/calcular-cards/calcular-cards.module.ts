import { DEFAULT_CURRENCY_CODE, NgModule } from '@angular/core'
import { CommonModule, CurrencyPipe } from '@angular/common'
import { NzGridModule } from 'ng-zorro-antd/grid'

import { CalcularCardsComponent } from './calcular-cards.component'
import { CardModule } from 'src/app/shared/card/card.module'

@NgModule({
  declarations: [
    CalcularCardsComponent
  ],
  imports: [
    CommonModule,
    CardModule,
    NzGridModule
  ],
  exports: [
    CalcularCardsComponent
  ],
  providers: [
    {
        provide:  DEFAULT_CURRENCY_CODE,
        useValue: 'BRL'
    },
    CurrencyPipe
]
})
export class CalcularCardsModule { }
