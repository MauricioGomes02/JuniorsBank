import { Injectable } from '@angular/core';
import {BehaviorSubject, Observable} from 'rxjs';
import {Person} from '../models/Person';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private currentPersonSubject: BehaviorSubject<Person>;
  public currentPerson: Observable<Person>;

  constructor(private http: HttpClient) {
    this.currentPersonSubject = new BehaviorSubject<Person>(JSON.parse(localStorage.getItem('currentPerson')));
    this.currentPerson = this.currentPersonSubject.asObservable();
  }

  public get currentPersonValue(): Person {
    return this.currentPersonSubject.value;
  }

  login(email: string, password: string): any {
    return this.http.post<Person>(`${environment.api}/api/person/login`, { email, password })
      .pipe(map(data => {
        localStorage.setItem('currentPerson', JSON.stringify(data));
        this.currentPersonSubject.next(data);
        return data;
      }));
  }

  logout(): void {
    localStorage.removeItem('currentPerson');
    this.currentPersonSubject.next(null);
  }
}
