import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'

import { CalculoDTO } from '../models/calculo-dto.model'
import { CardCalculoDTO } from '../models/card-calculo-dto.model'
import { EnvironmentService } from './enviroment.service'

@Injectable({
  providedIn: 'root'
})
export class CalculoService {

  constructor(
    private http : HttpClient,
    private envService: EnvironmentService) { }

  calcular = (calculo: CalculoDTO): Observable<CardCalculoDTO[]> =>
    this.http.post<CardCalculoDTO[]>(`${this.envService.api}/calcular`, calculo)
}
