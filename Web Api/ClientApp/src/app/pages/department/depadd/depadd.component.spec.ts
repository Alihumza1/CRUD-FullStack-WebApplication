import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DepaddComponent } from './depadd.component';

describe('DepaddComponent', () => {
  let component: DepaddComponent;
  let fixture: ComponentFixture<DepaddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DepaddComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DepaddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
