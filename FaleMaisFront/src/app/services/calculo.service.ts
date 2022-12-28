import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'

import { environment } from 'src/environments/environment'
import { CalculoDTO } from '../models/calculo-dto.model'
import { CardCalculoDTO } from '../models/card-calculo-dto.model'

@Injectable({
  providedIn: 'root'
})
export class CalculoService {

  constructor(private http : HttpClient) { }

  calcular = (calculo: CalculoDTO): Observable<CardCalculoDTO[]> =>
    this.http.post<CardCalculoDTO[]>(`${environment.api}/calcular`, calculo)
}
