
namespace Banking.Domain;

public class BonusCalculator
{


    public decimal CalculateBonusForDepositOn(decimal balance, decimal amount)
    {
        return balance >= 5000 ? amount * .10M : 0;
    }
}