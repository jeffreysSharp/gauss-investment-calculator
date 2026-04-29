import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

import { API_BASE_URL } from '../../../core/api/api.config';
import { CalculateCdbInvestmentRequest } from '../models/calculate-cdb-investment-request';
import { CalculateCdbInvestmentResponse } from '../models/calculate-cdb-investment-response';

@Injectable({
  providedIn: 'root',
})
export class InvestmentCalculatorService {
  private readonly httpClient = inject(HttpClient);

  calculateCdbInvestment(request: CalculateCdbInvestmentRequest) {
    return this.httpClient.post<CalculateCdbInvestmentResponse>(
      `${API_BASE_URL}/api/investments/cdb/simulations`,
      request,
    );
  }
}