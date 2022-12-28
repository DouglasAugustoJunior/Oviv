import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalcularValoresComponent } from './calcular-valores.component';

describe('CalcularValoresComponent', () => {
  let component: CalcularValoresComponent;
  let fixture: ComponentFixture<CalcularValoresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CalcularValoresComponent ],
      imports: [HttpClientTestingModule], 
      providers: [CalcularValoresComponent]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CalcularValoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
