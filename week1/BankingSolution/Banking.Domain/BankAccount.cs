

namespace Banking.Domain;

public class BankAccount
{
    private decimal defaultBonus = 5000M;
    public void Deposit(decimal amountToDeposit)
    {
        defaultBonus += amountToDeposit;
    }

    public decimal GetBalance()
    {

        return defaultBonus; // "slime"
    }
}