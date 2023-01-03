import { NzGridModule } from 'ng-zorro-antd/grid'
import { NzButtonModule } from 'ng-zorro-antd/button'
import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'

import { BotaoCadastrarComponent } from './botao-cadastrar.component'



@NgModule({
  declarations: [
    BotaoCadastrarComponent
  ],
  imports: [
    CommonModule,
    NzGridModule,
    NzButtonModule
  ],
  exports: [
    BotaoCadastrarComponent
  ]
})
export class BotaoCadastrarModule { }
