using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Token;

public interface ITokenService
{
    string GenerateToken(TokenPayload tokenPayload);

    string RefreshToken(TokenPayload tokenPayload);

    bool VerifyToken(string token);
}
