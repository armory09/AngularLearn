import { Component, OnInit } from '@angular/core';
import { AccountSummary } from '../../shared/account-summary.type';
import { AccountType } from '../../shared/account-type.enum';
import { AccountService } from '../../shared/account.service';

@Component({
    selector: 'account-list',
    templateUrl: './account-list.component.html'
})
export class AccountListComponent {

    cashAccounts: AccountSummary[];
    creditAccounts: AccountSummary[];

    constructor(private accountService: AccountService) {
        //this.cashAccounts = [
        //    { accountNumber: "123-234-4567", balance: 1234.56, name: "Checking", type: AccountType.Checking },
        //    { accountNumber: "234-456-1234", balance: 5234.56, name: "Savings", type: AccountType.Savings }
        //];
        //this.creditAccounts = [
        //    { accountNumber: "1111-2222-3333-4444", balance: 1234.56, name: "Credit", type: AccountType.Credit }
        //];
    }

    ngOnInit() {
        this.accountService.getAccountSummaries()
            .then(accounts => {
                this.cashAccounts = accounts.filter(v => v.type === AccountType.Checking || v.type === AccountType.Savings);
                this.creditAccounts = accounts.filter(v => v.type === AccountType.Credit);
            })
    }
}