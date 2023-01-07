import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'

import { AtualizarDDDDTO } from '../models/ddd-atualizar-dto.model'
import { CadastrarDDDDTO } from '../models/ddd-cadastrar-dto.model'
import { DDDListagemDTO } from '../models/ddd-listagem-dto.model'
import { EnvironmentService } from './enviroment.service'

@Injectable({
  providedIn: 'root'
})
export class DddService {

  constructor(
    private http : HttpClient,
    private envService: EnvironmentService) { }

  obterDDDs = ():Observable<DDDListagemDTO[]> =>
    this.http.get<DDDListagemDTO[]>(`${this.envService.api}/ddd`)

  cadastrar = (dto: CadastrarDDDDTO): Observable<string> =>
    this.http.post<string>(`${this.envService.api}/ddd`, dto)

  atualizar = (dto:AtualizarDDDDTO): Observable<string> =>
    this.http.put<string>(`${this.envService.api}/ddd`, dto)

  deletar = (id: number) : Observable<string> =>
    this.http.delete<string>(`${this.envService.api}/ddd/${id}`)
}
