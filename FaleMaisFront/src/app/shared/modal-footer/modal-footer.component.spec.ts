import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalFooterComponent } from './modal-footer.component';
import { ModalFooterModule } from './modal-footer.module';

describe('ModalFooterComponent', () => {
  let component: ModalFooterComponent;
  let fixture: ComponentFixture<ModalFooterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ ModalFooterModule ],
      declarations: [ ModalFooterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalFooterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
