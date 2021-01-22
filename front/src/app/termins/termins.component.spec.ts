import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TerminsComponent } from './termins.component';

describe('TerminsComponent', () => {
  let component: TerminsComponent;
  let fixture: ComponentFixture<TerminsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TerminsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TerminsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
