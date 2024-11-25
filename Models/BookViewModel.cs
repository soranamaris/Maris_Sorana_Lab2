namespace Maris_Sorana_Lab2.Models
{
    public class BookViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
