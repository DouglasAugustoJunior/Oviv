import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'

import { TarifasComponent } from './tarifas.component'
import { NzTableModule } from 'ng-zorro-antd/table'

@NgModule({
  declarations: [
    TarifasComponent
  ],
  imports: [
    CommonModule,
    NzTableModule
  ],
  exports: [
    TarifasComponent
  ]
})
export class TarifasModule { }
