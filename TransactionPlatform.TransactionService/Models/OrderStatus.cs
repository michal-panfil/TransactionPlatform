namespace TransactionPlatform.TransactionService.Models
{
    public enum OrderStatus
    {
        New,
        Validated,
        Invalid,
        Waiting,
        Processing,
        Accepted,
        Done,
        Cancelled
            
    }
}