import { Component, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'app-banking',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  template: ` <p>Banking goes here</p> `,
  styles: ``,
})
export class BankingComponent {}
