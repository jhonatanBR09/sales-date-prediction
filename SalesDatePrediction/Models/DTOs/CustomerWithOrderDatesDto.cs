namespace SalesDatePrediction.Models.DTOs
{
    public class CustomerWithOrderDatesDto
    {
        public int customerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictedOrder { get; set; }
    }
}
