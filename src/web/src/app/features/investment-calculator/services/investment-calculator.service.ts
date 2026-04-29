import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

import { environment } from '../../../../environments/environment';
import { CalculateCdbInvestmentRequest } from '../models/calculate-cdb-investment-request';
import { CalculateCdbInvestmentResponse } from '../models/calculate-cdb-investment-response';

@Injectable({
  providedIn: 'root',
})

export class InvestmentCalculatorService {
  private readonly httpClient = inject(HttpClient);

  calculateCdbInvestment(request: CalculateCdbInvestmentRequest) {
    return this.httpClient.post<CalculateCdbInvestmentResponse>(
      `${environment.apiBaseUrl}/api/investments/cdb/simulations`,
      request,
    );
  }
}