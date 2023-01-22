import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatergoriesEditComponent } from './catergories-edit.component';

describe('CatergoriesEditComponent', () => {
  let component: CatergoriesEditComponent;
  let fixture: ComponentFixture<CatergoriesEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CatergoriesEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CatergoriesEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
