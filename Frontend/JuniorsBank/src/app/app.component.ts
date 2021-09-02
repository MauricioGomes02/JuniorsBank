import { Component } from '@angular/core';
import {Person} from './models/Person';
import {Router} from '@angular/router';
import {AuthService} from './auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  currentPerson: Person;

  constructor(
    private router: Router,
    private authService: AuthService
  ) {
    this.authService.currentPerson.subscribe(x => this.currentPerson = x);
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
