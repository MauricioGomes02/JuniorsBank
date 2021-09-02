import { Component, OnInit } from '@angular/core';
import {CheckingAccountService} from '../services/checking-account.service';
import {AuthService} from '../auth/auth.service';
import {first} from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  depositObj = {
    value: null,
    transactionType: 'deposit'
  };
  withdrawalObj = {
    value: null,
    transactionType: 'withdrawal'
  };
  paymentObj = {
    value: null,
    transactionType: 'payment'
  };
  data: any;
  personId: number;
  constructor(
    // private formBuilder: FormBuilder,
    private checkingAccount: CheckingAccountService,
    private authService: AuthService,
  ) {
  }

  ngOnInit(): void {
    // @ts-ignore
    this.personId = this.authService.currentPersonValue.id;

    this.checkingAccount.query(this.personId)
      .pipe(
        first()
      ).subscribe(
        result => {
          this.data = result;
        }, error => {
          alert(error);
      }
    );
  }
  getTypeOfTransaction(typeOfTransaction: number): string {
    switch (typeOfTransaction) {
      case 0:
        return 'Depósito';
      case 1:
        return 'Saque';
      case 2:
        return 'Pagamento';
    }
  }
  formatBalance(value: number): string {
    return value.toFixed(2).replace('.', ',');
  }
  operation(obj: any): any {
    this.checkingAccount.operation(this.data.id, obj.value, obj.transactionType)
      .pipe(
        first()
      )
      .subscribe(
        result => {
          this.ngOnInit();
        }, error => {
          alert(error);
        }
      );
    obj.value = null;
  }
  logout(): void{
    this.authService.logout();
    location.reload();
  }
}
