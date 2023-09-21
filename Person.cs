namespace SupportBank
{
    public class Person
    {
        public Person(string nme, decimal blnce)
        {
            Name = nme;
            Balance = blnce;
        }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}