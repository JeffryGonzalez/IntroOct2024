import { Component, ChangeDetectionStrategy, inject } from '@angular/core';
import { BankingTransactionInputComponent } from '../components/banking-transaction-input.component';
import { BankingStore } from '../services/bank.store';

@Component({
  selector: 'app-banking-withdraw',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [BankingTransactionInputComponent],
  template: `
    <h1 class="text-2xl font-black">Make a Withdrawal</h1>
    <app-banking-transaction-input
      label="Withdrawal Amount"
      (transaction)="store.withdraw($event)"
    />
  `,
  styles: ``,
})
export class WithdrawComponent {
  store = inject(BankingStore);
}
