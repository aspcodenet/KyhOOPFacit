using System.Reflection.Metadata.Ecma335;

namespace KyhOOPFacit.Banken;

/*
 * Skapa en klass Transaction. Den ska ha belopp och kontonummer samt Typ (enum Withdrawal/Deposit)

Skapa en basklass BankAccount. Denna ska ha kontonummer och saldo. Dessutom en Lista med Transactions

Gör klassen ABSTRACT. Gör en virtuell metod "Withdraw".

Gör en metod "Deposit"

Skapa en Subklass: Sparkonto. Gör override på Withdraw och  kontrollera först genom Transactions att man inte gjort mer än 5 uttag senaste 30 dagarna. Isåfall är det EJ TILLÅTET att ta ut pengar.  

Skapa en Subklass: Personkonto. Gör override på Withdraw 

 */

public enum TransactionType
{
    Withdrawal,   
    Deposit
}



public class Transaction
{
    private readonly int _amount;
    private readonly TransactionType _transactionType;
    private readonly DateTime _timeStamp;

    public DateTime TimeStamp
    {
        get { return _timeStamp; }
    }
    public TransactionType TransactionType
    {
        get { return _transactionType; }
    }

    public Transaction(int amount, TransactionType transactionType, DateTime timeStamp)
    {
        _amount = amount;
        _transactionType = transactionType;
        _timeStamp = timeStamp;
    }

}

public abstract class BankAccount
{
    private readonly string _kontoNummer;
    protected int _balance;
    protected List<Transaction> transactions;

    public BankAccount(string kontoNummer)
    {
        _kontoNummer = kontoNummer;
        _balance = 0;
        transactions = new List<Transaction>();
    }

    public void Deposit(int amount)
    {
        _balance += amount;
    }
    public abstract bool Withdraw(int amount);
}


public class PersonAccount : BankAccount
{
    public PersonAccount(string kontoNummer) : base(kontoNummer)
    {
        
    }


    public override bool Withdraw(int amount)
    {
        if (amount > _balance) return false;
        _balance = _balance - amount;
        transactions.Add(new Transaction(amount, TransactionType.Withdrawal, DateTime.Now));
        return true;
    }
}

//public class FondKonto : BankAccount
//{
//    public FondKonto(string kontoNummer): base(kontoNummer)
//    {
        
//    }

//    public override bool Withdraw(int amount)
//    {
//        //d
//    }
//}

public class SavingsAccount : BankAccount
{
    public SavingsAccount(string kontoNummer) : base(kontoNummer)
    {

    }

    public override bool Withdraw(int amount)
    {
        if (amount > _balance) return false;

        //inte gjort mer än 5 uttag senaste 30 dagarna
        int antalUttagSenaste30 = 0;
        foreach (var tran in transactions)
        {
            if (tran.TransactionType != TransactionType.Deposit) continue;
            var timeSpan = DateTime.Now - tran.TimeStamp;
            if (timeSpan.TotalDays < 30)
                antalUttagSenaste30++;
        }

        // foreach ( var tran in transacvtiuons
        //int antalUttagSenaste30 = transactions.Count( tran => tran.TransactionType == TransactionType.Deposit &&  (DateTime.Now - tran.TimeStamp).TotalDays < 30  ));


        if (antalUttagSenaste30 > 5) return false;

        _balance = _balance - amount;
        transactions.Add(new Transaction(amount, TransactionType.Withdrawal, DateTime.Now));
        return true;

    }
}




public class BankApp
{
    public void Run()
    {
        var list = new List<BankAccount>();
        foreach (var acc in list)
            acc.Withdraw(200);
    }
}