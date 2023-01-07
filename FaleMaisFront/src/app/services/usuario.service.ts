import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'

import { CadastrarUsuarioDTO } from '../models/usuario-cadastrar-dto.model'
import { UsuarioListagemDTO } from '../models/usuario-listagem-dto.model'
import { EnvironmentService } from './enviroment.service'

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(
    private http : HttpClient,
    private envService: EnvironmentService) { }

  obterUsuarios = ():Observable<UsuarioListagemDTO[]> =>
    this.http.get<UsuarioListagemDTO[]>(`${this.envService.api}/usuarios`)

  cadastrar = (dto: CadastrarUsuarioDTO): Observable<string> =>
    this.http.post<string>(`${this.envService.api}/usuarios`, dto)

  atualizar = (dto:UsuarioListagemDTO): Observable<string> =>
    this.http.put<string>(`${this.envService.api}/usuarios`, dto)

  deletar = (id: number) : Observable<string> =>
    this.http.delete<string>(`${this.envService.api}/usuarios/${id}`)
}
