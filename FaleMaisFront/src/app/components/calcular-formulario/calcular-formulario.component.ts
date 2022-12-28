import { Component, EventEmitter, OnInit, Output } from '@angular/core'
import { FormBuilder, FormGroup, Validators } from '@angular/forms'

import { CalculoDTO } from 'src/app/models/calculo-dto.model'
import { DDDListagemDTO } from 'src/app/models/ddd-listagem-dto.model'
import { TarifaInputDTO } from 'src/app/models/tarifa-input-dto.model'
import { DddService } from 'src/app/services/ddd.service'
import { TarifaService } from 'src/app/services/tarifa.service'
import { destacarCamposInvalidos } from 'src/app/shared/utils/FormUtils'

@Component({
  selector: 'app-calcular-formulario',
  templateUrl: './calcular-formulario.component.html',
  styleUrls: ['./calcular-formulario.component.less']
})
export class CalcularFormularioComponent implements OnInit {
  @Output() enviarCalculo = new EventEmitter<CalculoDTO>()
  calcularForm!: FormGroup
  origemLista: DDDListagemDTO[] = []
  origemListaOriginal: DDDListagemDTO[] = []
  destinoLista: DDDListagemDTO[] = []
  tarifasLista: TarifaInputDTO[] = []
  estaCarregando = false

  constructor(
    private fb: FormBuilder,
    private dddService: DddService,
    private tarifaService: TarifaService) {
    this.calcularForm = this.fb.group({
      origemId: [ '', [ Validators.required ] ],
      destinoId: [ '', [ Validators.required ] ],
      qtdeMin: [ 0, [ Validators.required, Validators.min(1) ] ]
    })
    }

  ngOnInit(): void {
    this.obterTarifas()
    this.obterOrigem()
  }

  calcular():void {
    if(this.calcularForm.valid)
      this.enviarCalculo.emit(this.calcularForm.value)
    else
      destacarCamposInvalidos(this.calcularForm)
  }

  obterTarifas():void {
    this.tarifaService
      .obterTarifasParaInput()
      .subscribe(tarifa => this.tarifasLista = tarifa)
  }

  obterOrigem():void{
    this.dddService
      .obterDDDs()
      .subscribe(listaDDD => 
        this.origemListaOriginal = listaDDD)
  }

  filtrarOrigem(origem:string):void {
    this.origemLista = this.origemListaOriginal.filter(ddd => ddd.nome.includes(origem))
  }

  filtrarDestino():void {
    this.calcularForm.controls['destinoId'].reset()
    let tarifasCompativeis = this.tarifasLista
      .filter(tarifa => tarifa.origemId == this.calcularForm.controls['origemId'].value)
    this.destinoLista = this.origemListaOriginal
      .filter(ddd => tarifasCompativeis.find(tarifa => tarifa.destinoId == ddd.id))
  }

  get origemIdInvalido():boolean {
    return this.calcularForm.controls['origemId'].invalid
  }

}
