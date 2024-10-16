

using Banking.Domain;

namespace Banking.Tests.Account;
public class MakingDeposits
{
    [Theory]
    [InlineData(112.25)]
    [InlineData(22.43)]


    public void MakingADepositIncreasesOurBalance(decimal amountToDeposit)
    {
        // Given
        var account = new BankAccount();
        var openingBalance = account.GetBalance();


        // When
        account.Deposit(amountToDeposit);

        // Then
        var endingBalance = account.GetBalance();

        Assert.Equal(amountToDeposit + openingBalance, endingBalance);
    }




}
