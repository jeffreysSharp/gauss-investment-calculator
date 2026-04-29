import { Routes } from '@angular/router';

import { InvestmentCalculatorPageComponent } from './features/investment-calculator/pages/investment-calculator-page/investment-calculator-page.component';

export const routes: Routes = [
  {
    path: '',
    component: InvestmentCalculatorPageComponent,
  },
  {
    path: '**',
    redirectTo: '',
  },
];