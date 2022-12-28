import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { NzTableModule } from 'ng-zorro-antd/table'

import { DDDComponent } from './ddd.component'

@NgModule({
  declarations: [
    DDDComponent
  ],
  imports: [
    CommonModule,
    NzTableModule
  ],
  exports: [
    DDDComponent
  ]
})
export class DDDModule { }
