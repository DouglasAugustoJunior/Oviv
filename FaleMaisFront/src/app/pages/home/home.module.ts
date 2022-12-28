import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { NzLayoutModule } from 'ng-zorro-antd/layout'

import { HomeComponent } from './home.component'
import { MenuModule } from 'src/app/components/menu/menu.module'
import { AppRoutingModule } from 'src/app/app-routing.module'

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    NzLayoutModule,
    MenuModule,
    AppRoutingModule
  ],
  exports: [
    HomeComponent
  ]
})
export class HomeModule { }
