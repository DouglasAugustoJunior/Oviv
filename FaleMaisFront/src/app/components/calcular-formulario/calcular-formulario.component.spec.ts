import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { NzSelectModule } from 'ng-zorro-antd/select'
import { HttpClientTestingModule } from '@angular/common/http/testing'
import { ComponentFixture, TestBed } from '@angular/core/testing'
import { ReactiveFormsModule } from '@angular/forms'

import { CalcularFormularioComponent } from './calcular-formulario.component'

describe('CalcularFormularioComponent', () => {
  let component: CalcularFormularioComponent
  let fixture: ComponentFixture<CalcularFormularioComponent>

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CalcularFormularioComponent ],
      imports: [
        ReactiveFormsModule,
        HttpClientTestingModule,
        BrowserAnimationsModule,
        NzSelectModule
      ]
    })
    .compileComponents()
  })

  beforeEach(() => {
    fixture = TestBed.createComponent(CalcularFormularioComponent)
    component = fixture.componentInstance
    fixture.detectChanges()
  })

  it('should create', () => {
    expect(component).toBeTruthy()
  })
})
