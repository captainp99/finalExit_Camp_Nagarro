import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListofcampComponent } from './listofcamp.component';

describe('ListofcampComponent', () => {
  let component: ListofcampComponent;
  let fixture: ComponentFixture<ListofcampComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListofcampComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListofcampComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
