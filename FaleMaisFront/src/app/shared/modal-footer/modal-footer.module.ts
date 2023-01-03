import { NzButtonModule } from 'ng-zorro-antd/button';
import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'

import { ModalFooterComponent } from './modal-footer.component'

@NgModule({
  declarations: [
    ModalFooterComponent
  ],
  imports: [
    CommonModule,
    NzButtonModule
  ],
  exports: [
    ModalFooterComponent
  ]
})
export class ModalFooterModule { }
