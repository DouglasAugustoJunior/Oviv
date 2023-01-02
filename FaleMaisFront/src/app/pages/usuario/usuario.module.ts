import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { NzTableModule } from 'ng-zorro-antd/table'
import { NzInputModule } from 'ng-zorro-antd/input'
import { NzButtonModule } from 'ng-zorro-antd/button'
import { ReactiveFormsModule } from '@angular/forms'
import { NzFormModule } from 'ng-zorro-antd/form'
import { NzModalModule } from 'ng-zorro-antd/modal'
import { NzSelectModule } from 'ng-zorro-antd/select'

import { UsuarioComponent } from './usuario.component'
import { IconsProviderModule } from 'src/app/components/menu/icons-provider.module'

@NgModule({
  declarations: [
    UsuarioComponent
  ],
  imports: [
    CommonModule,
    NzInputModule,
    NzButtonModule,
    ReactiveFormsModule,
    NzFormModule,
    NzTableModule,
    IconsProviderModule,
    NzModalModule,
    NzSelectModule
  ],
  exports: [
    UsuarioComponent
  ]
})
export class UsuarioModule { }
