import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'

import { environment } from 'src/environments/environment'
import { CadastrarUsuarioDTO } from '../models/usuario-cadastrar-dto.model'
import { UsuarioListagemDTO } from '../models/usuario-listagem-dto.model'

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http : HttpClient) { }

  obterUsuarios = ():Observable<UsuarioListagemDTO[]> =>
    this.http.get<UsuarioListagemDTO[]>(`${environment.api}/usuarios`)

  cadastrar = (dto: CadastrarUsuarioDTO): Observable<string> =>
    this.http.post<string>(`${environment.api}/usuarios`, dto)

  atualizar = (dto:UsuarioListagemDTO): Observable<string> =>
    this.http.put<string>(`${environment.api}/usuarios`, dto)

  deletar = (id: number) : Observable<string> =>
    this.http.delete<string>(`${environment.api}/usuarios/${id}`)
}
