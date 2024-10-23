import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { TransactionRecord, TransactionType } from '../types';
type TransactionApiItem = {
  ibnTxLsn: string;
  amount: number;
  type: TransactionType;
  postedOn: string;
};
type BankStatementResponse = {
  accountNumber: string;
  statementDate: string;
  openingBalance: number;
  transactions: TransactionApiItem[];
};
@Injectable({ providedIn: 'root' })
export class BankDataService {
  #client = inject(HttpClient);

  constructor() {
    console.log('Created an instance of the BankDataService');
  }

  addDeposit(amount: number): Observable<TransactionRecord> {
    return this.#client
      .post<TransactionApiItem>(
        `http://fake-api.bankohypertheory.com/user/deposits`,
        { amount }
      )
      .pipe(
        map(
          (r) =>
            ({
              id: r.ibnTxLsn,
              amount,
              created: isoToTimeStamp(r.postedOn),
              newBalance: 99999, // no idea
              startingBalance: 99999, // no idea
            } as TransactionRecord)
        )
      );
  }

  getCurrentBankStatement(): Observable<TransactionRecord[]> {
    const now = new Date();
    return this.#client
      .get<BankStatementResponse>(
        `http://fake-api.bankohypertheory.com/user/statements/${now.getFullYear()}/${
          now.getMonth() + 1
        }`
      )
      .pipe(
        map((r) => {
          let previousBalance = r.openingBalance;
          return r.transactions
            .sort(
              (a, b) => isoToTimeStamp(b.postedOn) - isoToTimeStamp(a.postedOn)
            )
            .map((t) => {
              let newBalance =
                t.type === 'deposit'
                  ? previousBalance + t.amount
                  : previousBalance - t.amount;
              const response: TransactionRecord = {
                id: t.ibnTxLsn,
                created: isoToTimeStamp(t.postedOn),
                amount: t.amount,
                newBalance,
                startingBalance: previousBalance,
                type: t.type,
              };
              previousBalance = newBalance;
              return response;
            });
        })
      );
  }
}

function isoToTimeStamp(iso: string) {
  return new Date(iso).getTime();
}