import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddcampComponent } from './addcamp.component';

describe('AddcampComponent', () => {
  let component: AddcampComponent;
  let fixture: ComponentFixture<AddcampComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddcampComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddcampComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
