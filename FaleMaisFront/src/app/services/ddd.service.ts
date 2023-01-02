import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'

import { environment } from 'src/environments/environment'
import { AtualizarDDDDTO } from '../models/ddd-atualizar-dto.model'
import { CadastrarDDDDTO } from '../models/ddd-cadastrar-dto.model'
import { DDDListagemDTO } from '../models/ddd-listagem-dto.model'

@Injectable({
  providedIn: 'root'
})
export class DddService {

  constructor(private http : HttpClient) { }

  obterDDDs = ():Observable<DDDListagemDTO[]> =>
    this.http.get<DDDListagemDTO[]>(`${environment.api}/ddd`)

  cadastrar = (ddd: CadastrarDDDDTO): Observable<string> =>
    this.http.post<string>(`${environment.api}/ddd`, ddd)

  atualizar = (dto:AtualizarDDDDTO): Observable<string> =>
    this.http.put<string>(`${environment.api}/ddd`, dto)

  deletar = (id: number) : Observable<string> =>
    this.http.delete<string>(`${environment.api}/ddd/${id}`)
}
