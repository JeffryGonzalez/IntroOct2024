import { Component, ChangeDetectionStrategy } from '@angular/core';
import { BankingComponent } from './banking/banking.component';

@Component({
  selector: 'app-home',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [BankingComponent],
  template: ` <p>Home Page Stuff Here</p> `,
  styles: ``,
})
export class HomePageComponent {}
