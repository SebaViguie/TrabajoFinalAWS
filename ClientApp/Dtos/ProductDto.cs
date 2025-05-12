namespace ClientApp.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public int Counter { get; set; } = 0;
        public void IncrementCounter()
        {
            if (Counter < Stock)
                Counter++;
        }
    }
}
