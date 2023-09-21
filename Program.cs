using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

public class Transaction
{
    public string Date { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public string Narrative { get; set; }
    public decimal Amount { get; set; }
}

public class Person
{
    public Person(string nme, decimal blnce) {
        this.Name = nme;
        this.Balance = blnce;
    }
    public string Name { get; set; }
    public decimal Balance { get; set; }
}

// TODO: Make static
public class TransactionReader

{
    public List<Transaction> readTransactions()
    {
        // TODO: Take path and CultureInfo as argument
        using (var reader = new StreamReader("C:\\Users\\marrob\\Documents\\Training\\SupportBank\\SupportBank\\Transactions2014.csv"))
        {
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                MissingFieldFound = null,
                HeaderValidated = null,
            }))
            {
                return csv.GetRecords<Transaction>().ToList();
            }
        }
    }
}

class App
{
    static void Main()
    {
        TransactionReader transactionReader = new TransactionReader();
        IEnumerable<Transaction> transactions = transactionReader.readTransactions();
        // foreach (Transaction transaction in transactions ) {
        //     Console.WriteLine(transaction.From);
        // }
        List<Person> people = GetAllPeople(transactions);
        foreach (Person person in people) {
            Console.WriteLine(person.Balance);
        }
    }

    static List<Person> GetAllPeople (IEnumerable<Transaction> transactions)
    {
        List<Person> people = new List<Person>();
        foreach (Transaction transaction in transactions ) {
            int FromIndex = people.FindIndex((person) => person.Name == transaction.From);
            if ( FromIndex == -1 )
            {
                people.Add(new Person(transaction.From, transaction.Amount));
            }
            else
            {
                people[FromIndex].Balance += transaction.Amount;
            }
            int ToIndex = people.FindIndex((person) => person.Name == transaction.To);
            if ( ToIndex == -1 )
            {
                people.Add(new Person(transaction.To, -transaction.Amount));
            }
            else
            {
                people[ToIndex].Balance += -transaction.Amount;
            }
        }
        return people;
    }
}
