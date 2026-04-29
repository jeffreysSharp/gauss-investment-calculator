import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvestmentCalculatorPageComponent } from './investment-calculator-page.component';

describe('InvestmentCalculatorPageComponent', () => {
  let component: InvestmentCalculatorPageComponent;
  let fixture: ComponentFixture<InvestmentCalculatorPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InvestmentCalculatorPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InvestmentCalculatorPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
