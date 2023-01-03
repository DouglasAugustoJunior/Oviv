import { HttpClientTestingModule } from '@angular/common/http/testing'
import { ComponentFixture, TestBed } from '@angular/core/testing'

import { DDDComponent } from './ddd.component'
import { DDDModule } from './ddd.module'

describe('DDDComponent', () => {
  let component: DDDComponent
  let fixture: ComponentFixture<DDDComponent>

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DDDComponent ],
      imports: [
        DDDModule,
        HttpClientTestingModule
      ], 
      providers: [DDDComponent]
    })
    .compileComponents()
  })

  beforeEach(() => {
    fixture = TestBed.createComponent(DDDComponent)
    component = fixture.componentInstance
    fixture.detectChanges()
  })

  it('should create', () => {
    expect(component).toBeTruthy()
  })
})
