import { CurrencyPipe } from '@angular/common';
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalcularCardsComponent } from './calcular-cards.component';

describe('CalcularCardsComponent', () => {
  let component: CalcularCardsComponent;
  let fixture: ComponentFixture<CalcularCardsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CalcularCardsComponent ],
      providers: [CurrencyPipe]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CalcularCardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
