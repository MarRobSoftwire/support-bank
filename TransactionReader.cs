using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace SupportBank
{
    // TODO: Make static
    public class TransactionReader

    {
        public List<Transaction> ReadTransactions()
        {
            // TODO: Take path and CultureInfo as argument
            using var reader = new StreamReader("C:\\Users\\marrob\\Documents\\Training\\SupportBank\\SupportBank\\Transactions2014.csv");
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                MissingFieldFound = null,
                HeaderValidated = null,
            });
            return csv.GetRecords<Transaction>().ToList();
        }
    }
}