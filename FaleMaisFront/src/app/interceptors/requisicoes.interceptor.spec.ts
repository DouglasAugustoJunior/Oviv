import { HttpClientTestingModule } from '@angular/common/http/testing'
import { TestBed } from '@angular/core/testing'
import { RouterTestingModule } from '@angular/router/testing'
import { NzNotificationModule } from 'ng-zorro-antd/notification'

import { RequisicoesInterceptor } from './requisicoes.interceptor'

describe('RequisicoesInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      RequisicoesInterceptor
    ],
    imports: [
      HttpClientTestingModule,
      RouterTestingModule,
      NzNotificationModule
    ]
  }))

  it('should be created', () => {
    const interceptor: RequisicoesInterceptor = TestBed.inject(RequisicoesInterceptor)
    expect(interceptor).toBeTruthy()
  })
})
