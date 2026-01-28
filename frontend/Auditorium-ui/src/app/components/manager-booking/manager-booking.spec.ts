import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagerBooking } from './manager-booking';

describe('ManagerBooking', () => {
  let component: ManagerBooking;
  let fixture: ComponentFixture<ManagerBooking>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ManagerBooking]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ManagerBooking);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
