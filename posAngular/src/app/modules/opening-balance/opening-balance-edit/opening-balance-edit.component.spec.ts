import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpeningBalanceEditComponent } from './opening-balance-edit.component';

describe('OpeningBalanceEditComponent', () => {
  let component: OpeningBalanceEditComponent;
  let fixture: ComponentFixture<OpeningBalanceEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OpeningBalanceEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OpeningBalanceEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
