import { HttpClientTestingModule } from '@angular/common/http/testing'
import { TestBed } from '@angular/core/testing'

import { DddService } from './ddd.service'

describe('DddService', () => {
  let service: DddService

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule], 
      providers: [DddService]
    })
    service = TestBed.inject(DddService)
  })

  it('should be created', () => {
    expect(service).toBeTruthy()
  })
})
