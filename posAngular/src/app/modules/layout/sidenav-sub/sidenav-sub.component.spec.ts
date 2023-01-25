import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SidenavSubComponent } from './sidenav-sub.component';

describe('SidenavSubComponent', () => {
  let component: SidenavSubComponent;
  let fixture: ComponentFixture<SidenavSubComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SidenavSubComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SidenavSubComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
