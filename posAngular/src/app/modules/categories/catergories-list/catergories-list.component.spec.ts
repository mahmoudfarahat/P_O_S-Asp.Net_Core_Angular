import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatergoriesListComponent } from './catergories-list.component';

describe('CatergoriesListComponent', () => {
  let component: CatergoriesListComponent;
  let fixture: ComponentFixture<CatergoriesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CatergoriesListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CatergoriesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
