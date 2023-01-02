import { Component, OnInit } from '@angular/core'
import { FormBuilder, Validators } from '@angular/forms'
import { NzNotificationService } from 'ng-zorro-antd/notification'

import { DDDListagemDTO } from 'src/app/models/ddd-listagem-dto.model'
import { DddService } from 'src/app/services/ddd.service'
import { destacarCamposInvalidos } from 'src/app/shared/utils/FormUtils'
import { IListagemUtils } from 'src/app/shared/utils/IListagemUtils'
import { ListagemUtils } from 'src/app/shared/utils/ListagemUtils'

@Component({
  selector: 'app-ddd',
  templateUrl: './ddd.component.html'
})
export class DDDComponent extends ListagemUtils implements IListagemUtils, OnInit {

  listaDDD: DDDListagemDTO[] = []
  dddParaEdicao!: DDDListagemDTO
  
  constructor(
    private fb:FormBuilder,
    private notificationService: NzNotificationService,
    private dddService: DddService) {
      super()
      this.form = this.fb.group({
        id: [null, []],
        nome: ['', [ Validators.required ]]
      })
    }

  ngOnInit(): void {
    this.obterDDDs()
  }

  private obterDDDs() {
    this.dddService.obterDDDs().subscribe(ddd => this.listaDDD = ddd)
  }

  showModal(ddd: DDDListagemDTO): void {
    this.dddParaEdicao = ddd
    this.form.patchValue(ddd)
    this.modalVisivel = true
  }

  ok(): void {
    if(this.form.valid){
      this.dddService.atualizar(this.form.value).subscribe(resposta => {
        this.notificationService.success("Sucesso",resposta)
        this.obterDDDs()
        this.modalVisivel = false
      })
    }else
      destacarCamposInvalidos(this.form)
  }

}
