import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'

import { AtualizarTarifaDTO } from '../models/tarifa-atualizar-dto.model'
import { CadastrarTarifaDTO } from '../models/tarifa-cadastrar-dto.model'
import { TarifaInputDTO } from '../models/tarifa-input-dto.model'
import { TarifaListagemDTO } from '../models/tarifa-listagem-dto.model'
import { EnvironmentService } from './enviroment.service'

@Injectable({
  providedIn: 'root'
})
export class TarifaService {

  constructor(
    private http : HttpClient,
    private envService: EnvironmentService) { }

  obterTarifas = ():Observable<TarifaListagemDTO[]> =>
    this.http.get<TarifaListagemDTO[]>(`${this.envService.api}/tarifas`)

  obterTarifasParaInput = ():Observable<TarifaInputDTO[]> =>
    this.http.get<TarifaInputDTO[]>(`${this.envService.api}/tarifasParaInput`)

  cadastrar = (dto: CadastrarTarifaDTO): Observable<string> =>
    this.http.post<string>(`${this.envService.api}/tarifas`, dto)

  atualizar = (dto:AtualizarTarifaDTO): Observable<string> =>
    this.http.put<string>(`${this.envService.api}/tarifas`, dto)

  deletar = (id: number) : Observable<string> =>
    this.http.delete<string>(`${this.envService.api}/tarifas/${id}`)
}
