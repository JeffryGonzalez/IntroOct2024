import { Component, ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'app-navigation',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [],
  template: `
    <div class="navbar bg-base-100">
      <div class="flex-1">
        <a class="btn btn-ghost text-xl">Intro To Programming</a>
      </div>
      <div class="flex-none">
        <ul class="menu menu-horizontal px-1">
          <li>
            <a href="/banking">Banking</a>
          </li>
        </ul>
      </div>
    </div>
  `,
  styles: ``,
})
export class NavigationComponent {}
