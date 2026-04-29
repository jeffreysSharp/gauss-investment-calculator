export interface CalculateCdbInvestmentResponse {
  initialAmount: number;
  termInMonths: number;
  grossAmount: number;
  profitAmount: number;
  incomeTaxRate: number;
  incomeTaxAmount: number;
  netAmount: number;
}