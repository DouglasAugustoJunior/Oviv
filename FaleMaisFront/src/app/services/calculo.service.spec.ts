import { TestBed } from '@angular/core/testing'
import { HttpClientTestingModule } from '@angular/common/http/testing'

import { CalculoService } from './calculo.service'

describe('CalculoService', () => {
  let service: CalculoService

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule], 
      providers: [CalculoService]
    })
    service = TestBed.inject(CalculoService)
  })

  it('should be created', () => {
    expect(service).toBeTruthy()
  })
})
