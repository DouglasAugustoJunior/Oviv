import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core'
import { DDDListagemDTO } from '../models/ddd-listagem-dto.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DddService {

  constructor(private http : HttpClient) { }

  obterDDDs = ():Observable<DDDListagemDTO[]> =>
    this.http.get<DDDListagemDTO[]>(`${environment.api}/ddd`)
}
