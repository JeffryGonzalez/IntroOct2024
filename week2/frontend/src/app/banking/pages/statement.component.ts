import { Component, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'app-banking-statement',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  template: ` <p>Transaction History goes here</p> `,
  styles: ``,
})
export class StatementComponent {}
