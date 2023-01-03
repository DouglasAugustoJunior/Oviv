import { Component } from '@angular/core'

import { CalculoDTO } from './../../models/calculo-dto.model'
import { CalculoService } from 'src/app/services/calculo.service'
import { CardCalculoDTO } from 'src/app/models/card-calculo-dto.model'

@Component({
  selector: 'app-calcular-valores',
  templateUrl: './calcular-valores.component.html',
  styleUrls: ['./calcular-valores.component.less']
})
export class CalcularValoresComponent {
  calculos: CardCalculoDTO[] = []
  constructor(private calculoService: CalculoService) { }

  calcular(dadosParaCalcular: CalculoDTO):void {
    this.calculoService
      .calcular(dadosParaCalcular)
      .subscribe(calculos => this.calculos = calculos)
  }

}