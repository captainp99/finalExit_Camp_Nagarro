import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CampbookingComponent } from './campbooking.component';

describe('CampbookingComponent', () => {
  let component: CampbookingComponent;
  let fixture: ComponentFixture<CampbookingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CampbookingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CampbookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
