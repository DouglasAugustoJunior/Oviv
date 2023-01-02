import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'

import { environment } from 'src/environments/environment'
import { AtualizarTarifaDTO } from '../models/tarifa-atualizar-dto.model'
import { TarifaInputDTO } from '../models/tarifa-input-dto.model'
import { TarifaListagemDTO } from '../models/tarifa-listagem-dto.model'

@Injectable({
  providedIn: 'root'
})
export class TarifaService {

  constructor(private http : HttpClient) { }

  obterTarifas = ():Observable<TarifaListagemDTO[]> =>
    this.http.get<TarifaListagemDTO[]>(`${environment.api}/tarifas`)

  obterTarifasParaInput = ():Observable<TarifaInputDTO[]> =>
    this.http.get<TarifaInputDTO[]>(`${environment.api}/tarifasParaInput`)

  atualizar = (dto:AtualizarTarifaDTO): Observable<string> =>
    this.http.put<string>(`${environment.api}/tarifas`, dto)

  deletar = (id: number) : Observable<string> =>
    this.http.delete<string>(`${environment.api}/tarifas/${id}`)
}
