import {
  Component,
  ChangeDetectionStrategy,
  signal,
  computed,
} from '@angular/core';
import { TransactionRecord } from './types';
import { TransactionHistoryComponent } from './components/transaction-history.component';
import { BankingSuccessNotificationComponent } from './components/banking-success-notification.component';
import { BankingTransactionInputComponent } from './components/banking-transaction-input.component';
import { RouterOutlet } from '@angular/router';
import { BankingNavComponent } from './components/banking-nav.component';

// id, starting balance , type (deposit | withdraw), amount, new balance

@Component({
  selector: 'app-banking',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [
    TransactionHistoryComponent,
    BankingSuccessNotificationComponent,
    BankingTransactionInputComponent,
    RouterOutlet,
    BankingNavComponent,
  ],
  template: `
    <app-banking-nav />
    <div>
      <p>Your Balance is {{ balance() }}</p>
      @if(isGoldAccount()) {

      <app-banking-success-notification
        message="You are a gold account! You'll get a bonus on your next deposit!"
      />

      } @else {
      <p>
        If you deposit {{ amountNeededToBeGold() }} more dollars, you will be a
        gold account!
      </p>
      }

      <div>
        <app-banking-transaction-input
          label="Deposit"
          (transaction)="deposit($event)"
        />

        <app-banking-transaction-input
          label="Withdraw"
          (transaction)="withdraw($event)"
        />
      </div>
      <router-outlet />
    </div>
  `,
  styles: ``,
})
export class BankingComponent {
  balance = signal(0);

  history = signal<TransactionRecord[]>([]);

  goldAccountCutoff = signal(5000);
  isGoldAccount = computed(() => this.balance() >= this.goldAccountCutoff());
  amountNeededToBeGold = computed(
    () => this.goldAccountCutoff() - this.balance()
  );

  deposit(amount: number) {
    const newTransaction: TransactionRecord = {
      id: crypto.randomUUID(),
      amount: amount,
      startingBalance: this.balance(),
      newBalance: this.balance() + amount,
      type: 'deposit',
    };
    this.history.set([newTransaction, ...this.history()]);
    this.balance.update((b) => b + amount);
  }

  withdraw(amount: number) {
    const newTransaction: TransactionRecord = {
      id: crypto.randomUUID(),
      amount: amount,
      startingBalance: this.balance(),
      newBalance: this.balance() - amount,
      type: 'withdrawal',
    };
    this.history.set([newTransaction, ...this.history()]);

    this.balance.update((b) => b - amount);
  }
}
