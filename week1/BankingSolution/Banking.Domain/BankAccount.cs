


namespace Banking.Domain;

public class BankAccount
{
    private decimal _balance = 7000M;
    public void Deposit(decimal amountToDeposit)
    {
        var calculator = new BonusCalculator();
        decimal bonus = calculator.CalculateBonusForDepositOn(_balance, amountToDeposit);



        _balance += amountToDeposit + bonus;
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if (_balance >= amountToWithdraw)
        {
            _balance -= amountToWithdraw;
        }
        else
        {
            throw new AccountOverdraftException();
        }
    }
}

public class AccountOverdraftException : ArgumentOutOfRangeException;