namespace TransactionPlatform.TransactionService.Models
{
    public enum TransactionStatus
    {
        New,
        Validated,
        Invalid,
        Waiting,
        Processing,
        Accepted,
        Done
    }
}