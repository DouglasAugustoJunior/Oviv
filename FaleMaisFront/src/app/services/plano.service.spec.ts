import { TestBed } from '@angular/core/testing'
import { HttpClientTestingModule } from '@angular/common/http/testing'

import { PlanoService } from './plano.service'

describe('PlanoService', () => {
  let service: PlanoService

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule], 
      providers: [PlanoService]
    })
    service = TestBed.inject(PlanoService)
  })

  it('should be created', () => {
    expect(service).toBeTruthy()
  })
})
