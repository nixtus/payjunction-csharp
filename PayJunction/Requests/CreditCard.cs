namespace PayJunction.Requests
{
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string CardExpMonth { get; set; }
        public string CardExpYear { get; set; }
        public string CardCvv { get; set; }
    }
}
