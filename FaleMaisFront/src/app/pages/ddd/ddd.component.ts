import { Component, OnInit } from '@angular/core'

import { DDDListagemDTO } from 'src/app/models/ddd-listagem-dto.model'
import { DddService } from 'src/app/services/ddd.service'

@Component({
  selector: 'app-ddd',
  templateUrl: './ddd.component.html'
})
export class DDDComponent implements OnInit {
  listaDDD: DDDListagemDTO[] = []

  constructor(private dddService: DddService) { }

  ngOnInit(): void {
    this.dddService.obterDDDs().subscribe(ddd => this.listaDDD = ddd)
  }

}
