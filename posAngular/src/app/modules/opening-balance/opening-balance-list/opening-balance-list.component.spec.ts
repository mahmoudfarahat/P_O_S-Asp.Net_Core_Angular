import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OpeningBalanceListComponent } from './opening-balance-list.component';

describe('OpeningBalanceListComponent', () => {
  let component: OpeningBalanceListComponent;
  let fixture: ComponentFixture<OpeningBalanceListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OpeningBalanceListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OpeningBalanceListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
