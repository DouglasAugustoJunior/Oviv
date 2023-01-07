import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'

import { PlanoListagemDTO } from '../models/plano-listagem-dto.model'
import { EnvironmentService } from './enviroment.service'

@Injectable({
  providedIn: 'root'
})
export class PlanoService {

  constructor(
    private http : HttpClient,
    private envService: EnvironmentService) { }

  obterPlanos = ():Observable<PlanoListagemDTO[]> =>
    this.http.get<PlanoListagemDTO[]>(`${this.envService.api}/planos`)
}
