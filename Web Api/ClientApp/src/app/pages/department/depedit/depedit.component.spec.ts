import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DepeditComponent } from './depedit.component';

describe('DepeditComponent', () => {
  let component: DepeditComponent;
  let fixture: ComponentFixture<DepeditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DepeditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DepeditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
