using Banking.Domain;


namespace Banking.Tests.Account;
public class OverdraftingAccounts
{
    [Fact]
    public void OverdraftIsNotAllowed()
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();

        try
        {
            account.Withdraw(openingBalance + .01M);
        }
        catch
        {

            // swallowing any exceptions because the assert is an invariant.
        }

        Assert.Equal(openingBalance, account.GetBalance());
    }

    [Fact]
    public void OverdraftThrows()
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();


        Assert.Throws<AccountOverdraftException>(
            () => account.Withdraw(openingBalance + .01M));

    }
}
