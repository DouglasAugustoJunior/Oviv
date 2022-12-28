import { ComponentFixture, TestBed } from '@angular/core/testing'
import { HttpClientTestingModule } from '@angular/common/http/testing'
import { TarifasComponent } from './tarifas.component'

describe('TarifasComponent', () => {
  let component: TarifasComponent
  let fixture: ComponentFixture<TarifasComponent>

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TarifasComponent ],
      imports: [HttpClientTestingModule], 
      providers: [TarifasComponent]
    })
    .compileComponents()
  })

  beforeEach(() => {
    fixture = TestBed.createComponent(TarifasComponent)
    component = fixture.componentInstance
    fixture.detectChanges()
  })

  it('should create', () => {
    expect(component).toBeTruthy()
  })
})
