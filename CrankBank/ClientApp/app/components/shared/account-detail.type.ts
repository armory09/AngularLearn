import { AccountSummary } from './account-summary.type';
import { AccountTransaction } from './account-transaction.type';

export class AccountDetail {
    accountSummary: AccountSummary;
    accountTransaction: AccountTransaction[];
}