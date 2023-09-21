using SupportBank;

class App
{
    static void Main()
    {
        List<Transaction> transactions = TransactionReader.ReadTransactions("C:\\Users\\marrob\\Documents\\Training\\SupportBank\\SupportBank\\Transactions2014.csv");
        List<Person> people = GetAllPeople(transactions);
        foreach (Person person in people) {
            Console.WriteLine(person.Name + " has a balance " + person.Balance);
        }

        foreach (Transaction transaction in GetPersonalTransactions("Jon A", transactions) )
        {
            Console.WriteLine(transaction.Date + ", from " + transaction.From + " to "  + transaction.To + ", "  + transaction.Narrative + ", "  + transaction.Amount);
        }
    }

    static List<Person> GetAllPeople (List<Transaction> transactions)
    {
        var people = new List<Person>();
        foreach (Transaction transaction in transactions )
        {
            int fromIndex = people.FindIndex((person) => person.Name == transaction.From);
            if ( fromIndex == -1 )
            {
                people.Add(new Person(transaction.From, transaction.Amount));
            }
            else
            {
                people[fromIndex].Balance += transaction.Amount;
            }

            int toIndex = people.FindIndex((person) => person.Name == transaction.To);
            if ( toIndex == -1 )
            {
                people.Add(new Person(transaction.To, -transaction.Amount));
            }
            else
            {
                people[toIndex].Balance += -transaction.Amount;
            }
        }
        return people;
    }

    static List<Transaction> GetPersonalTransactions(string Name, List<Transaction> transactions ) {
        return transactions.Where(t => t.From == Name || t.To == Name).ToList();
    }
}
