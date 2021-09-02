import { Injectable } from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {environment} from '../../environments/environment';
import {map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CheckingAccountService {
  constructor(private http: HttpClient) { }

  operation(checkingAccountId: number, value: number, transactionType: string): Observable<any> {
    return this.http.post<any>(`${environment.api}/api/checkingaccount/${checkingAccountId}/${transactionType}`, { value })
      .pipe(map(result => {
        return result;
      }));
  }

  query(personId: number): Observable<any>{
    return this.http.get<any>(`${environment.api}/api/checkingaccount/getbyperson/${personId}`)
      .pipe(map(result => {
        return result;
      }));
  }
}
