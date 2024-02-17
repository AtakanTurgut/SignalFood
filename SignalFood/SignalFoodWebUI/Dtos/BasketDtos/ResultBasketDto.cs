namespace SignalFoodWebUI.Dtos.BasketDtos
{
    public class ResultBasketDto
    {
        public int BasketId { get; set; }

        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }

        public int ProductId { get; set; }
        //public Product? Product { get; set; }

        public int MenuTableId { get; set; }
        //public MenuTable? MenuTable { get; set; }
    }
}
