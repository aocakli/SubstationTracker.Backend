﻿using SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens._Bases.Dtos;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens.OtherFeatures.RefreshTokens.Commands.
    CreateUserRefreshToken;

public class CreateUserRefreshTokenCommandResponse : UserTokenDto
{
    public CreateUserRefreshTokenCommandResponse(string token, DateTime expiryDate) : base(token, expiryDate)
    {
    }
}