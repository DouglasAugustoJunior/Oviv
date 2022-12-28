import { HttpClientTestingModule } from '@angular/common/http/testing'
import { TestBed } from '@angular/core/testing'
import { RouterTestingModule } from '@angular/router/testing'

import { AdministradorGuard } from './administrador.guard'

describe('AdministradorGuard', () => {
  let guard: AdministradorGuard

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule,RouterTestingModule], 
      providers: [AdministradorGuard]})
    guard = TestBed.inject(AdministradorGuard)
  })

  it('should be created', () => {
    expect(guard).toBeTruthy()
  })
})
