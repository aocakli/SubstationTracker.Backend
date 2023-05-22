﻿using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Users;
using SubstationTracker.Application.Repositories.Users._Bases;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Application.Utilities.MultiLanguage.Services;

namespace SubstationTracker.Application.Features.Users._Bases.BusinessRules;

public class UserBusinessRules
{
    private readonly LanguageService _languageService;
    private readonly IUserReadRepository _userReadRepository;

    public UserBusinessRules(IUserReadRepository userReadRepository, LanguageService languageService)
    {
        _userReadRepository = userReadRepository;
        _languageService = languageService;
    }

    public async Task<bool> EmailShouldNotExistInDatabaseAsync(string email)
    {
        var emailIsExist = await _userReadRepository.AnyAsync(_user => _user.Email.Equals(email));
        if (emailIsExist)
            throw new BusinessException(_languageService.Get(Messages.EmailIsAlreadyUsed));

        return true;
    }
}