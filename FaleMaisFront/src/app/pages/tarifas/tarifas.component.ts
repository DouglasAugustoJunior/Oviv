import { Component, OnInit } from '@angular/core'
import { FormBuilder, Validators } from '@angular/forms'
import { NzModalService } from 'ng-zorro-antd/modal'

import { IListagemUtils } from './../../shared/utils/IListagemUtils'
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
  listaDDDs: DDDListagemDTO[] = []

  constructor(
    private fb:FormBuilder,
    private modalService: NzModalService,
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
    this.form.patchValue({
      ...tarifa,
      origemId: this.obterDDDEdicao(tarifa?.origem),
      destinoId: this.obterDDDEdicao(tarifa?.destino)
    })
    this.modalVisivel = true
  }

  cadastrar(): void {
    throw new Error('Method not implemented.')
  }

  salvar(): void {
    if(this.form.valid){
      this.tarifaService.atualizar(this.form.value).subscribe(() => {
        this.obterTarifas()
        this.modalVisivel = false
      })
    }else
      destacarCamposInvalidos(this.form)
  }

  modalDeletar(tarifa:TarifaListagemDTO): void {
    this.modalService.create({
      nzTitle: 'Deletar',
      nzContent: `Deseja realmente excluir a tarifa de Origem ${tarifa.origem} e Destino ${tarifa.destino}?`,
      nzOkText: 'Excluir',
      nzCancelText: 'Cancelar',
      nzMaskClosable: false,
      nzClosable: false,
      nzOnOk: () => this.deletar(tarifa.id),
      nzOnCancel: () => this.cancel()
    })
  }

  private deletar(id: number): void {
    this.tarifaService.deletar(id).subscribe(() => {
      this.obterTarifas()
      this.modalVisivel = false
    })
  }

}
