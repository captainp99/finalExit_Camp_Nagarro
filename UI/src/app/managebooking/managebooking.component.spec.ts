import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManagebookingComponent } from './managebooking.component';

describe('ManagebookingComponent', () => {
  let component: ManagebookingComponent;
  let fixture: ComponentFixture<ManagebookingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManagebookingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManagebookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
