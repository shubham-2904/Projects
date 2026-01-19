using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionApp.Token;

public interface ITokenService
{
    string GenerateToken();

    string RefreshToken();

    bool VerifyToken(string token);
}
