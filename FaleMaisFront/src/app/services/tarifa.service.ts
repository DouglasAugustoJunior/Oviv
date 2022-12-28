import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'

import { environment } from 'src/environments/environment'
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
}
