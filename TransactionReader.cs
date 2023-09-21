using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace SupportBank
{
    public class TransactionReader

    {
        public static List<Transaction> ReadTransactions(string path)
        {
            // TODO: CultureInfo as argument
            using var reader = new StreamReader(path);
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