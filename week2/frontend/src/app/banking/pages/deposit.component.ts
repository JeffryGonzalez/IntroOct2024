import { Component, ChangeDetectionStrategy, inject } from '@angular/core';
import { BankingStore } from '../services/bank.store';
import { BankingSuccessNotificationComponent } from '../components/banking-success-notification.component';
import { BankingTransactionInputComponent } from '../components/banking-transaction-input.component';

@Component({
  selector: 'app-banking-deposit',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [
    BankingSuccessNotificationComponent,
    BankingTransactionInputComponent,
  ],
  template: `
    <h1 class="text-2xl font-black">Make a Deposit</h1>

    @if(store.isGoldAccount()) {

    <app-banking-success-notification
      message="You are a gold account! You'll get a bonus on your next deposit!"
    />

    } @else {
    <p>
      If you deposit {{ store.amountNeededToBeGold() }} more dollars, you will
      be a gold account!
    </p>
    }
    <app-banking-transaction-input
      label="Deposit Amount"
      (transaction)="store.deposit($event)"
    />
  `,
  styles: ``,
})
export class DepositComponent {
  store = inject(BankingStore);
}
