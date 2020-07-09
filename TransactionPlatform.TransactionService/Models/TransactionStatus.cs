namespace TransactionPlatform.TransactionService.Models
{
    public enum TransactionStatus
    {
        New,
        Validated,
        Waiting,
        Processing,
        Accepted,
        Done
    }
}