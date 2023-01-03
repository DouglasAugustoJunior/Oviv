import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { NzTableModule } from 'ng-zorro-antd/table'
import { NzModalModule } from 'ng-zorro-antd/modal'
import { NzInputModule } from 'ng-zorro-antd/input'
import { NzButtonModule } from 'ng-zorro-antd/button'
import { ReactiveFormsModule } from '@angular/forms'
import { NzFormModule } from 'ng-zorro-antd/form'

import { DDDComponent } from './ddd.component'
import { IconsProviderModule } from 'src/app/components/menu/icons-provider.module'
import { BotaoCadastrarModule } from 'src/app/shared/botao-cadastrar/botao-cadastrar.module';

@NgModule({
  declarations: [
    DDDComponent
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
    NzButtonModule,
    BotaoCadastrarModule
  ],
  exports: [
    DDDComponent
  ]
})
export class DDDModule { }
