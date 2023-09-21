using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

public class Transaction
{
    public string Date { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public string Narrative { get; set; }
    public float Ammount { get; set; }
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
        foreach (Transaction transaction in transactions ) {
            Console.WriteLine(transaction.From);
        }
    }
}