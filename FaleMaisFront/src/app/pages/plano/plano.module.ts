import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { NzGridModule } from 'ng-zorro-antd/grid'

import { PlanoComponent } from './plano.component'
import { CardModule } from 'src/app/shared/card/card.module'

@NgModule({
  declarations: [
    PlanoComponent
  ],
  imports: [
    CommonModule,
    CardModule,
    NzGridModule
  ],
  exports: [
    PlanoComponent
  ]
})
export class PlanoModule { }
