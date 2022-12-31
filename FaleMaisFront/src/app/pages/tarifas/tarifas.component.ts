import { Component, OnInit } from '@angular/core'
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { NzNotificationService } from 'ng-zorro-antd/notification'

import { DDDListagemDTO } from 'src/app/models/ddd-listagem-dto.model'
import { AtualizarTarifaDTO } from 'src/app/models/tarifa-atualizar-dto.model'
import { TarifaListagemDTO } from 'src/app/models/tarifa-listagem-dto.model'
import { DddService } from 'src/app/services/ddd.service'
import { TarifaService } from 'src/app/services/tarifa.service'
import { destacarCamposInvalidos } from 'src/app/shared/utils/FormUtils'

@Component({
  selector: 'app-tarifas',
  templateUrl: './tarifas.component.html'
})
export class TarifasComponent implements OnInit {

  listaTarifas: TarifaListagemDTO[] = []
  tarifaParaEdicao!: TarifaListagemDTO
  modalVisivel = false
  listaDDDs: DDDListagemDTO[] = []
  form: FormGroup

  constructor(
    private fb:FormBuilder,
    private notificationService: NzNotificationService,
    private tarifaService: TarifaService,
    private dddService: DddService) {
      this.form = this.fb.group({
        id: [null, []],
        origemId: [null, [ Validators.required ]],
        destinoId: [null, [ Validators.required ]],
        valorPorMin: [null, [ Validators.required ]]
      })
    }

  ngOnInit(): void {
    this.obterTarifas()
    this.dddService
      .obterDDDs()
      .subscribe(listaDDD => this.listaDDDs = listaDDD)
  }

  obterDDDEdicao = (origem: string | undefined): number | null =>
    this.listaDDDs.find(ddd => ddd.nome.includes(origem ?? ''))?.id ?? null

  private obterTarifas():void {
    this.tarifaService
      .obterTarifas()
      .subscribe(tarifas => this.listaTarifas = tarifas)
  }

  showModal(tarifa: TarifaListagemDTO): void {
    console.log(tarifa)
    this.tarifaParaEdicao = tarifa
    this.form.patchValue({
      ...tarifa,
      origemId: this.obterDDDEdicao(this.tarifaParaEdicao?.origem),
      destinoId: this.obterDDDEdicao(this.tarifaParaEdicao?.destino)
    })
    this.modalVisivel = true
  }

  ok(): void {
    if(this.form.valid){
      this.tarifaService.atualizar(this.form.value).subscribe(resposta => {
        this.notificationService.success("Sucesso",resposta)
        this.obterTarifas()
        this.modalVisivel = false
      })
    }else
      destacarCamposInvalidos(this.form)
  }

  cancel(): void {
    this.modalVisivel = false
  }

  limpar(evento: MouseEvent): void {
    evento.preventDefault()
    this.form.reset()
    for (const key in this.form.controls) {
      if (this.form.controls.hasOwnProperty(key)) {
        this.form.controls[key].markAsPristine()
        this.form.controls[key].updateValueAndValidity()
      }
    }
  }

}
