import { HttpClientTestingModule } from '@angular/common/http/testing'
import { TestBed } from '@angular/core/testing'
import { RouterTestingModule } from '@angular/router/testing'

import { AutenticacaoGuard } from './autenticacao.guard'

describe('AutenticacaoGuard', () => {
  let guard: AutenticacaoGuard

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule,RouterTestingModule], 
      providers: [AutenticacaoGuard]})
    guard = TestBed.inject(AutenticacaoGuard)
  })

  it('should be created', () => {
    expect(guard).toBeTruthy()
  })
})
