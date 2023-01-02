import { IListagemUtils } from './../../shared/utils/IListagemUtils';
import { Component, OnInit } from '@angular/core'
import { FormBuilder, Validators } from '@angular/forms'

import { DDDListagemDTO } from 'src/app/models/ddd-listagem-dto.model'
import { TarifaListagemDTO } from 'src/app/models/tarifa-listagem-dto.model'
import { DddService } from 'src/app/services/ddd.service'
import { TarifaService } from 'src/app/services/tarifa.service'
import { destacarCamposInvalidos } from 'src/app/shared/utils/FormUtils'
import { ListagemUtils } from 'src/app/shared/utils/ListagemUtils'

@Component({
  selector: 'app-tarifas',
  templateUrl: './tarifas.component.html'
})
export class TarifasComponent extends ListagemUtils implements IListagemUtils, OnInit {

  listaTarifas: TarifaListagemDTO[] = []
  tarifaParaEdicao!: TarifaListagemDTO
  listaDDDs: DDDListagemDTO[] = []

  constructor(
    private fb:FormBuilder,
    private tarifaService: TarifaService,
    private dddService: DddService) {
      super()
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

  private obterDDDEdicao = (origem: string | undefined): number | null =>
    this.listaDDDs.find(ddd => ddd.nome.includes(origem ?? ''))?.id ?? null

  private obterTarifas():void {
    this.tarifaService
      .obterTarifas()
      .subscribe(tarifas => this.listaTarifas = tarifas)
  }

  showModal(tarifa: TarifaListagemDTO): void {
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
      this.tarifaService.atualizar(this.form.value).subscribe(() => {
        this.obterTarifas()
        this.modalVisivel = false
      })
    }else
      destacarCamposInvalidos(this.form)
  }

}
