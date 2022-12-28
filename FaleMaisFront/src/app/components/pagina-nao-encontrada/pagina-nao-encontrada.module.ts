import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { NzResultModule } from 'ng-zorro-antd/result'
import { NzButtonModule } from 'ng-zorro-antd/button'
import { RouterModule } from '@angular/router'

import { PaginaNaoEncontradaComponent } from './pagina-nao-encontrada.component'

@NgModule({
  declarations: [
    PaginaNaoEncontradaComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    NzResultModule,
    NzButtonModule
  ],
  exports: [
    PaginaNaoEncontradaComponent
  ]
})
export class PaginaNaoEncontradaModule { }
