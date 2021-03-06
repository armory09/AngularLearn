﻿using CrankBank.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrankBank.Controllers
{
    [Route("api/bank")]
    public class BankController : Controller
    {
        private static AccountSummary[] _accountSummaries = new AccountSummary[]
        {
            new AccountSummary{ AccountNumber = "012-123-1234", Type = AccountType.Checking, Name = "John's Checking - server", Balance = 1234.56},
            new AccountSummary{ AccountNumber = "567-234-5586", Type = AccountType.Savings, Name = "John's Holiday Stash - server", Balance = 5000.27},
            new AccountSummary{ AccountNumber = "9999-2222-3333-4444", Type = AccountType.Credit, Name = "Platinum Card - server", Balance = 1234.56}
        };

        
        [HttpGet("[action]")]
        public IActionResult GetAccountSummaries()
        {
            return new ObjectResult(_accountSummaries);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetAccountDetails(string id)
        {
            try
            {
                var summary = _accountSummaries.FirstOrDefault(a => a.AccountNumber == id);

                if (summary == null)
                {
                    return NotFound();
                }

                var random = new Random();

                var transaction = new List<AccountTransaction>();

                for (int i = 0; i < 15; i++)
                {
                    transaction.Add(new AccountTransaction
                    {
                        TransactionDate = DateTimeOffset.Now - TimeSpan.FromDays(i),
                        Description = $"Server Transaction #{i}",
                        Amount = (random.NextDouble() * 500) - 250
                    });
                }

                return new ObjectResult(new AccountDetail
                {
                    AccountSummary = summary,
                    AccountTransactions = transaction.ToArray()
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
