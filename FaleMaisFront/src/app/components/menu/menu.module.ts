import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { RouterModule } from '@angular/router'
import { NzMenuModule } from 'ng-zorro-antd/menu'
import { NzToolTipModule } from 'ng-zorro-antd/tooltip'
import { NzButtonModule } from 'ng-zorro-antd/button'

import { MenuComponent } from '../menu/menu.component'
import { IconsProviderModule } from './icons-provider.module'

@NgModule({
  declarations: [
    MenuComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    NzMenuModule,
    NzButtonModule,
    NzToolTipModule,
    IconsProviderModule
  ],
  exports: [
    MenuComponent
  ]
})
export class MenuModule { }
