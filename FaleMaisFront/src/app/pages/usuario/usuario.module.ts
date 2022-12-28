import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { NzTableModule } from 'ng-zorro-antd/table'

import { UsuarioComponent } from './usuario.component'

@NgModule({
  declarations: [
    UsuarioComponent
  ],
  imports: [
    CommonModule,
    NzTableModule
  ],
  exports: [
    UsuarioComponent
  ]
})
export class UsuarioModule { }
