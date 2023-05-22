﻿using SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens._Bases.Dtos;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens.OtherFeatures.AccessTokens.Queries.
    GenerateUserAccessToken;

public class GenerateUserAccessTokenQueryResponse : UserTokenDto
{
    public GenerateUserAccessTokenQueryResponse(string token, DateTime expiryDate) : base(token, expiryDate)
    {
    }
}