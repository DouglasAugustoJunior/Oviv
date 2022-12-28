import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'

import { environment } from 'src/environments/environment'
import { PlanoListagemDTO } from '../models/plano-listagem-dto.model'

@Injectable({
  providedIn: 'root'
})
export class PlanoService {

  constructor(private http : HttpClient) { }

  obterPlanos = ():Observable<PlanoListagemDTO[]> =>
    this.http.get<PlanoListagemDTO[]>(`${environment.api}/planos`)
}
