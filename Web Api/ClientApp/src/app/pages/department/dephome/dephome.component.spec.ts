import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DephomeComponent } from './dephome.component';

describe('DephomeComponent', () => {
  let component: DephomeComponent;
  let fixture: ComponentFixture<DephomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DephomeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DephomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
