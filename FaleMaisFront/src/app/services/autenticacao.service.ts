import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Router } from '@angular/router'
import { Observable, tap } from 'rxjs'

import { environment } from 'src/environments/environment'
import { Usuario } from '../models/usuario.model'

@Injectable({
  providedIn: 'root'
})
export class AutenticacaoService {
  usuarioLogadoLocalStorage:string = 'usuarioLogado'
  tokenLocalStorageUsuario:string = 'tokenUsuario'
  autorizacaoLocalStorageUsuario:string = 'AutorizacaoUsuario'

  constructor(private http : HttpClient,private router: Router) { }

  logar = (usuario: Usuario): Observable<Usuario> =>
    this.http
      .post<Usuario>(`${environment.api}/login`, usuario)
      .pipe(tap((usuarioLogado: any) => {
        if (usuarioLogado == null)
          return
        localStorage.setItem(this.tokenLocalStorageUsuario, btoa(JSON.stringify(usuarioLogado['token'])))
        localStorage.setItem(this.usuarioLogadoLocalStorage, btoa(JSON.stringify(usuarioLogado['usuario'])))
        localStorage.setItem(this.autorizacaoLocalStorageUsuario, btoa(JSON.stringify(usuarioLogado['autorizacao'])))
        this.router.navigate([''])
      }))

  deslogar():void {
    localStorage.clear()
    this.router.navigate(['login'])
  }

  get obterUsuarioLogado(): string {
    return localStorage.getItem(this.usuarioLogadoLocalStorage)
      ? JSON.parse(atob(localStorage.getItem(this.usuarioLogadoLocalStorage)!))
      : null
  }

  get obterAutorizacaoUsuarioLogado(): string {
    return localStorage.getItem(this.autorizacaoLocalStorageUsuario)
      ? JSON.parse(atob(localStorage.getItem(this.autorizacaoLocalStorageUsuario)!))
      : null
  }

  get obterTokenUsuario(): string {
    return localStorage.getItem(this.tokenLocalStorageUsuario)
      ? JSON.parse(atob(localStorage.getItem(this.tokenLocalStorageUsuario)!))
      : null
  }

  get estaLogado(): boolean {
    return localStorage.getItem(this.tokenLocalStorageUsuario) ? true : false
  }
}
