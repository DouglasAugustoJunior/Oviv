import { HttpClientTestingModule } from '@angular/common/http/testing'
import { ComponentFixture, TestBed } from '@angular/core/testing'

import { UsuarioComponent } from './usuario.component'
import { UsuarioModule } from './usuario.module'

describe('UsuarioComponent', () => {
  let component: UsuarioComponent
  let fixture: ComponentFixture<UsuarioComponent>

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UsuarioComponent ],
      imports: [ 
        UsuarioModule,
        HttpClientTestingModule
      ], 
      providers: [UsuarioComponent]
    })
    .compileComponents()
  })

  beforeEach(() => {
    fixture = TestBed.createComponent(UsuarioComponent)
    component = fixture.componentInstance
    fixture.detectChanges()
  })

  it('should create', () => {
    expect(component).toBeTruthy()
  })
})
