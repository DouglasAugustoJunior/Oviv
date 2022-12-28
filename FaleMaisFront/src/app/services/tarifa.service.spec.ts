import { TestBed } from '@angular/core/testing'
import { HttpClientTestingModule } from '@angular/common/http/testing'

import { TarifaService } from './tarifa.service'

describe('TarifaService', () => {
  let service: TarifaService

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule], 
      providers: [TarifaService]
    })
    service = TestBed.inject(TarifaService)
  })

  it('should be created', () => {
    expect(service).toBeTruthy()
  })
})
