namespace Project0.StoreApplication.Domain.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}