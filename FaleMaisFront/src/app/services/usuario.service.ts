import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'

import { environment } from 'src/environments/environment'
import { UsuarioListagemDTO } from '../models/usuario-listagem-dto.model'

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http : HttpClient) { }

  obterUsuarios = ():Observable<UsuarioListagemDTO[]> =>
    this.http.get<UsuarioListagemDTO[]>(`${environment.api}/usuarios`)
}
