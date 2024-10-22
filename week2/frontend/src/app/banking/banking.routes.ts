import { Routes } from '@angular/router';
import { BankingComponent } from './banking.component';
import { StatementComponent } from './pages/statement.component';

export const BANKING_ROUTES: Routes = [
  {
    path: '', // /banking
    component: BankingComponent,
    children: [
      {
        path: 'statement', // banking/statement
        component: StatementComponent,
      },
    ],
  },
];
