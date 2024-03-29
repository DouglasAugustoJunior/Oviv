import { NzCardModule } from 'ng-zorro-antd/card'
import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'

import { CardComponent } from './card.component'

@NgModule({
  declarations: [
    CardComponent
  ],
  imports: [
    CommonModule,
    NzCardModule
  ],
  exports: [
    CardComponent
  ]
})
export class CardModule { }
