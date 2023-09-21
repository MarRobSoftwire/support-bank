using SupportBank;

class App
{
    static void Main()
    {
        TransactionReader transactionReader = new TransactionReader();
        List<Transaction> transactions = transactionReader.ReadTransactions();
        List<Person> people = GetAllPeople(transactions);
        // foreach (Person person in people) {
        //     Console.WriteLine(person.Name + " has a balance " + person.Balance);
        // }

        foreach (Transaction transaction in GetPersonalTransactions("Jon A", transactions) )
        {
            Console.WriteLine(transaction.Date + ", from " + transaction.From + " to "  + transaction.To + ", "  + transaction.Narrative + ", "  + transaction.Amount);
        }
    }

    static List<Person> GetAllPeople (List<Transaction> transactions)
    {
        List<Person> people = new List<Person>();
        foreach (Transaction transaction in transactions )
        {
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

    static List<Transaction> GetPersonalTransactions (string Name, List<Transaction> transactions ) {
        List<Transaction> PersonalTransactions = new List<Transaction>();
        foreach (Transaction transaction in transactions)
        {
            if (transaction.From == Name || transaction.To == Name ) PersonalTransactions.Add(transaction);
        }
        return PersonalTransactions;
    }
}
