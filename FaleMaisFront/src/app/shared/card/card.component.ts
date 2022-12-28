import { Component, Input } from '@angular/core'

import { Card } from 'src/app/models/card.model'

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.less']
})
export class CardComponent {
  @Input() card: Card = {
    valor: '0',
    descricao: 'empty'
  }

  constructor() { }

}
