import { Component, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'app-banking-statement',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  template: ` <p>Statement Will Go Here</p> `,
  styles: ``,
})
export class StatementComponent {}
