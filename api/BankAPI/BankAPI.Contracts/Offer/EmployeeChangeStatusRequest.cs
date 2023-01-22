namespace BankAPI.BankAPI.Contracts.Offer
{
    public class EmployeeChangeStatusRequest
    {
            public string Name { get; set; }
            public Guid offerId { get; set; }
    }
}
