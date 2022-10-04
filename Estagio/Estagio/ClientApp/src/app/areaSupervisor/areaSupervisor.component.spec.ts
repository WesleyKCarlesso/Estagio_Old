import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AreaSupervisorComponent } from './areaSupervisor.component';

describe('CompraComponent', () => {
  let component: AreaSupervisorComponent;
  let fixture: ComponentFixture<AreaSupervisorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AreaSupervisorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AreaSupervisorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
