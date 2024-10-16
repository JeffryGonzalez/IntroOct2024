
using Banking.Domain;

namespace Banking.Tests.Account;
public class NewAccounts
{
    // new accounts have the right opening balance.

    [Fact]
    public void NewAccountsHaveCorrectOpeningBalance()
    {
        // Write the code you wish you had. (WTCYWYH) (JFHCI)
        // Given (Arrange)
        var account = new BankAccount();
        // When (Act)
        decimal balance = account.GetBalance();
        // Then (Assert)
        Assert.Equal(5000M, balance);

    }
}
