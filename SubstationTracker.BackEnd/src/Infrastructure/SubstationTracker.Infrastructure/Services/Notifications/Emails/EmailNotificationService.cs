using System.Net;
using System.Net.Mail;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Notifications.Abstracts;
using SubstationTracker.Application.Features.Users._Bases.Queries.GetUserById;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserResetPasswords.Queries.GetUserResetPasswordCodeByUserId;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Application.Utilities.MultiLanguage.Services;
using SubstationTracker.Application.Utilities.Responses.Abstracts;
using SubstationTracker.Application.Utilities.Responses.Concretes;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications.Enums;
using SubstationTracker.Infrastructure.Options;

namespace SubstationTracker.Infrastructure.Services.Notifications.Emails;

public class EmailNotificationService : INotificationService
{
    private readonly IConfiguration _configuration;
    private readonly EmailSettingOption _emailSettingOption;
    private readonly bool _isServiceActive = true;
    private readonly LanguageService _languageService;
    private readonly IMediator _mediator;

    public EmailNotificationService(IMediator mediator, LanguageService languageService,
        IOptions<EmailSettingOption> emailSettingOption, IConfiguration configuration)
    {
        _mediator = mediator;
        _languageService = languageService;
        _configuration = configuration;
        _emailSettingOption = emailSettingOption.Value;
    }

    public async Task<IResponse> SendUserPasswordResetEmailAsync(Guid userId)
    {
        var webUrl = _configuration.GetSection("ClientUrls:WebUrl")?.Value ??
                     throw new ErrorException(_languageService.Get(Messages.WebClientUrlIsNotFound));

        var userResetPasswordCodeResult =
            await _mediator.Send(new GetUserResetPasswordCodeByUserIdQueryRequest(userId));
        if (userResetPasswordCodeResult.IsSuccess is false)
            return new ErrorResponse(userResetPasswordCodeResult.Message);

        webUrl += $"reset-password/{userResetPasswordCodeResult.Data.Code}";

        // Hello, we are received your password reset request. You can reset password with the link.

        string template = string.Format(_languageService.Get(Messages.ResetPasswordTemplate), webUrl);

        var emailSendResult = await SendAsync(new HashSet<string>() { userResetPasswordCodeResult.Data.Email },
            _languageService.Get(Messages.ResetPasswordHeader), template);

        if (emailSendResult.IsSuccess is false)
            return new ErrorResponse(emailSendResult.Message);

        return new SuccessResponse(_languageService.Get(Messages.WeAreSendAResetPasswordEmailToYou));
    }

    public async Task<IResponse> SendAsync(HashSet<string> emailAddresses, string subject, string content)
    {
        SmtpClient smtpClient = new()
        {
            Port = _emailSettingOption.Port,
            Host = _emailSettingOption.Host,
            EnableSsl = _emailSettingOption.EnableSsl,
            Credentials = new NetworkCredential(_emailSettingOption.Email, _emailSettingOption.Password)
        };

        MailMessage mailMessage = new()
        {
            From = new MailAddress(_emailSettingOption.Email, _emailSettingOption.DisplayName),
            Subject = subject,
            Body = content
        };

        foreach (var emailAddress in emailAddresses)
            mailMessage.To.Add(emailAddress);

        await smtpClient.SendMailAsync(mailMessage);

        return new SuccessResponse(_languageService.Get(Messages.EmailIsSended));
    }
}