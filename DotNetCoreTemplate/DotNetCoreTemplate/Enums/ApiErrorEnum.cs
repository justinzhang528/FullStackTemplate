using System.ComponentModel;

namespace DotNetCore.Enums;

public enum ApiErrorEnum
{
    [Description("No Error")] NoError = 0,

    [Description("UserNotFound")] UserNotExist = 5,

    [Description("Invalid Language")] InvalidLanguage = 6,

    ApiReturnNot200 = 104,

    ApiRequestException = 105,

    [Description("Provider Not Available")]
    ProviderNotFound = 111,

    [Description("Provider Agent Info Not Found")]
    ProviderAgentInfoNotFound = 112,

    [Description("Provider Bet Limit Info Not Found")]
    ProviderBetLimitInfoNotFound = 113,

    [Description("Default Provider Bet Limit Not Found")]
    DefaultProviderBetLimitInfoNotFound = 114,

    [Description("Invalid Request Amount")]
    InvalidRequestAmount = 115,

    [Description("Bet Found")] BetNotFound = 116,

    [Description("Bet With The Same Reference Number Exists")]
    BetWithSameRefNoExists = 117,

    [Description("Insufficient Balance")] InsufficientBalance = 118,

    [Description("Order Already Settled")] OrderAlreadySettled = 119,

    [Description("Order Already Cancelled")]
    OrderAlreadyCancelled = 120,

    [Description("Total Place Bet Amount Not Corrected")]
    TotalPlaceBetAmountNotCorrected = 121,

    [Description("Cancel Bet Not Found")] CancelBetNotFound = 122,

    [Description("Game Info Not Found")] GameInfoNotFound = 123,

    [Description("Game Under Maintenance")]
    GameUnderMaintenance = 124,

    [Description("Invalid Token")] InvalidToken = 125,

    [Description("Invalid Currency")] InvalidCurrency = 126,

    [Description("Failed to get order status")]
    GetOrderStatusFailed = 127,

    [Description("Cannot Rollback Running Bet")]
    CannotRollBackRunningBet = 128,

    [Description("Set Provider Bet Limit Failed")]
    SetBetLimitFail = 129,

    [Description("Sub Provider Not Available")]
    SubProviderNotFound = 130,

    [Description("Customer record not found")]
    CustomerRecordNotFound = 404,

    [Description("General Error")] GeneralError = 500,

    [Description("Stop Resend")] StopResendErrorCode = 997,

    [Description("Login Failed")] LoginFailed = 10409,
}