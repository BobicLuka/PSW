import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTerminComponent } from './add-termin.component';

describe('AddTerminComponent', () => {
  let component: AddTerminComponent;
  let fixture: ComponentFixture<AddTerminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddTerminComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddTerminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
