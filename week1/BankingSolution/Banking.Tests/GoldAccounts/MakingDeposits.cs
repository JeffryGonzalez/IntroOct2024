

using Banking.Domain;

namespace Banking.Tests.GoldAccounts;
public class MakingDeposits
{
    [Fact]
    public void GetsBonus()
    {
        // Given
        var account = new BankAccount();
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;


        // when
        // account.Deposit(amountToDeposit, isGold: true);
        account.Deposit(amountToDeposit);

        // then
        var expectedBalance = openingBalance + (amountToDeposit * 1.10M);

        Assert.Equal(expectedBalance, account.GetBalance());


    }
}
