import { TestBed } from '@angular/core/testing'
import { HttpClientTestingModule } from '@angular/common/http/testing'

import { AutenticacaoService } from './autenticacao.service'
import { RouterTestingModule } from '@angular/router/testing'

describe('AutenticacaoService', () => {
  let service: AutenticacaoService

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule,RouterTestingModule], 
      providers: [AutenticacaoService]
    })
    service = TestBed.inject(AutenticacaoService)
  })

  it('should be created', () => {
    expect(service).toBeTruthy()
  })
})
