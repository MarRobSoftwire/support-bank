using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SupportBank
{
    public class TransactionReader
    {
        public static List<Transaction> ReadTransactions(string path)
        {
            // TODO: CultureInfo as argument

            Logger log = new SBLogger().GetLogger();

            log.Debug("Opening file " + path);
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                MissingFieldFound = null,
                HeaderValidated = null,
            });
            try 
            {
                return csv.GetRecords<Transaction>().ToList();
            }
            catch (Exception e)
            {
                log.Error(e);
                return new List<Transaction>();
            }
        }
    }
}