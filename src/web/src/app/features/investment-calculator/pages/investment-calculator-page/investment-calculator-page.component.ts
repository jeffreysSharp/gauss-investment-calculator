import { CommonModule, CurrencyPipe, PercentPipe } from '@angular/common';
import { Component, computed, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';

import { CalculateCdbInvestmentResponse } from '../../models/calculate-cdb-investment-response';
import { InvestmentCalculatorService } from '../../services/investment-calculator.service';

@Component({
  selector: 'app-investment-calculator-page',
  imports: [CommonModule, ReactiveFormsModule, CurrencyPipe, PercentPipe],
  templateUrl: './investment-calculator-page.component.html',
  styleUrl: './investment-calculator-page.component.css',
})

export class InvestmentCalculatorPageComponent {
  private readonly formBuilder = inject(FormBuilder);
  private readonly investmentCalculatorService = inject(InvestmentCalculatorService);

  protected readonly result = signal<CalculateCdbInvestmentResponse | null>(null);
  protected readonly isSubmitting = signal(false);
  protected readonly errorMessage = signal<string | null>(null);

  protected readonly form = this.formBuilder.nonNullable.group({
    initialAmount: [1000, [Validators.required, Validators.min(0.01)]],
    termInMonths: [12, [Validators.required, Validators.min(2)]],
  });

  protected readonly hasResult = computed(() => this.result() !== null);

  protected calculate(): void {
    this.errorMessage.set(null);
    this.result.set(null);

    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.isSubmitting.set(true);

    this.investmentCalculatorService
      .calculateCdbInvestment(this.form.getRawValue())
      .subscribe({
        next: response => {
          this.result.set(response);
          this.isSubmitting.set(false);
        },
        error: () => {
                  this.errorMessage.set('Não foi possível calcular a simulação. Revise os dados informados e tente novamente.');
                    this.isSubmitting.set(false);
                  },
      });
  }

  protected hasFieldError(fieldName: 'initialAmount' | 'termInMonths'): boolean {
    const field = this.form.controls[fieldName];

    return field.invalid && (field.dirty || field.touched);
  }
}