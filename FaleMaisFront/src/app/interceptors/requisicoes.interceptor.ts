import { Injectable } from '@angular/core'
import {
  HttpRequest,
  HttpHandler,
  HttpInterceptor,
  HttpStatusCode,
  HttpErrorResponse
} from '@angular/common/http'
import { catchError, throwError } from 'rxjs'
import { NzNotificationService } from 'ng-zorro-antd/notification'

import { AutenticacaoService } from '../services/autenticacao.service'

@Injectable()
export class RequisicoesInterceptor implements HttpInterceptor {

  constructor(
    private autenticacaoService : AutenticacaoService,
    private notificationService: NzNotificationService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler) {
    const handleRequest = this.autenticacaoService.estaLogado
      ? request.clone({
          headers: request.headers.set(
            'Authorization',
            `Bearer ${this.autenticacaoService.obterTokenUsuario}`
          )
        })
      : request
    return next
      .handle(handleRequest)
      .pipe(catchError(this.validarErro()))
  }

  private validarErro = () => (erro:any) => {
    if (erro instanceof HttpErrorResponse)
      switch(erro.status){
        case HttpStatusCode.Unauthorized:
          this.notificationService.error(
            'Erro',
            'Usuário não autorizado ou sessão expirada!'
          )
          this.autenticacaoService.deslogar()
        break
        case HttpStatusCode.Forbidden:
          this.notificationService.error(
            'Erro de autenticação',
            'Você não tem permissão para acessar essa tela!')
          return throwError(() => erro)
        case HttpStatusCode.NotFound:
          this.notificationService.error(
            'Erro',
            `${erro.error ? erro.error : erro.message}`)
          return throwError(() => erro)
        case HttpStatusCode.BadRequest:
          this.notificationService.error(
            'Erro',
            `${erro.error ? erro.error : erro.message ? erro.message : erro}`)
          return throwError(() => erro)
        default:
            this.notificationService.error(
              'Erro',
              `${erro.message}`
            )
          return throwError(() => erro)
      }
    return throwError(() => erro)
  }
}
