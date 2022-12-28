import { Component, OnInit } from '@angular/core'
import { TarifaListagemDTO } from 'src/app/models/tarifa-listagem-dto.model'
import { TarifaService } from 'src/app/services/tarifa.service'

@Component({
  selector: 'app-tarifas',
  templateUrl: './tarifas.component.html'
})
export class TarifasComponent implements OnInit {

  listaTarifas: TarifaListagemDTO[] = []

  constructor(private tarifaService: TarifaService) { }

  ngOnInit(): void {
    this.tarifaService
      .obterTarifas()
      .subscribe(tarifas => this.listaTarifas = tarifas)
  }

}
