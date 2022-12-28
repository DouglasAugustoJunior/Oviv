import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'

import { CalcularValoresComponent } from './calcular-valores.component'
import { CalcularFormularioModule } from '../calcular-formulario/calcular-formulario.module'
import { CalcularCardsModule } from '../calcular-cards/calcular-cards.module'

@NgModule({
  declarations: [
    CalcularValoresComponent
  ],
  imports: [
    CommonModule,
    CalcularFormularioModule,
    CalcularCardsModule
  ],
  exports: [
    CalcularValoresComponent
  ]
})
export class CalcularValoresModule { }
