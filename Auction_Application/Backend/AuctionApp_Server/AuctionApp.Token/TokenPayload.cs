namespace AuctionApp.Token;

public class TokenPayload
{
    public Guid TokenId { get; set; }
    public required string UserName { get; set; }
    public DateTime TokenExpiry {  get; set; }
}
