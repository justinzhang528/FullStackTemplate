using System.ComponentModel;

namespace DotNetCore.Enums;

public enum DbResponseErrorEnum
{
    [Description("DB Error")] DBError = -1,

    [Description("No Error")] NoError = 0,

    [Description("Invalid Company Key")] InvalidCompanyKey = 1,

    [Description("Request Is Not Following Json Format")]
    InvalidRequestJsonFormat = 2,

    [Description("Internal Error.")] InternalError = 3,

    [Description("Invalid Username")] InvalidUserName = 4,

    [Description("Invalid Country")] InvalidCountry = 5,

    [Description("Invalid Language")] InvalidLanguage = 6,

    [Description("Not Support With Agent Account")]
    NotSupportAgentAccount = 7,

    [Description("Invalid Request Format")]
    InvalidRequestFormat = 8,

    [Description("Invalid WebId")] InvalidWebId = 9,

    [Description("Referral Cannot Be Same With Username")]
    InvalidReferral = 10,

    [Description("Invalid Portfolio")] InvalidPortfolio = 11,

    [Description("Player Account Duplicate With Other Account")]
    PlayerAccountDuplicateWithOtherAccount = 12,

    [Description("Please choose a stronger Username. Try a mix of letters, numbers, and '_'")]
    UsernameTaken = 13,

    [Description("reach the api call limit restriction, please try again after 30 sec")]
    CallingLimitError = 14,

    [Description("Player Already Exists.")] PlayerExists = 1100,
    
    [Description("Player Not Exist.")] PlayerNotExist = 1101,
    
    [Description("RefNo Has Already Exists.")] RefNoHasAlreadyExist = 1102,

    [Description("Duplicate Primary Key")] DuplicatePrimaryKey = 2627,

    [Description("Currency Not Found.")] CurrencyNotFound = 3100,

    [Description("Company key verification failed")] CompanyKeyVerificationFail = 100,

    [Description("Agent Already Exists")] AgentAlreadyExists = 200,

    [Description("Invalid Currency.")] InvalidCurrency = 3101,

    [Description("Invalid Theme Id.")] InvalidThemeId = 3102,

    [Description("Create Agent Failed.")] CreateAgentFailed = 3104,

    [Description("Update Status Fail")] UpdateStatusFail = 3201,

    [Description("Update Status Invalid UserName")]
    UpdateStatusInvalidUserName = 3202,

    [Description("Already Update Status")] AlreadyUpdateStatus = 3203,

    [Description("Invalid Status")] InvalidStatus = 3204,

    [Description("Invalid Date")] InvalidDate = 3205,

    [Description("Invalid MinBet")] InvalidMin = 3206,

    [Description("Invalid MaxBet")] InvalidMax = 3207,

    [Description("Invalid MaxPerMatch")] InvalidMaxPerMatch = 3208,

    [Description("Invalid CasinoTableLimit")]
    InvalidCasinoTableLimit = 3209,
    
    [Description("AgentKey is already taken")]
    AgentKeyIsExist = 33,
    
    [Description("AgentID not found for the provided CompanyKey")]
    NotFoundCompanyKey = 34,

    [Description("Invalid Domain")] InvalidDomains = 3301,

    [Description("Create Supported Domain Failed.")]
    UpdateSupportedDomainFail = 3302,

    [Description("User Doesn't Exist")] UserNotExists = 3303,

    [Description("Account Is Closed.")] AccountIsClosed = 3304,

    [Description("Account Is Suspend.")] AccountIsSuspend = 3305,

    [Description("Lower than Agent Min Bet.")]
    LowerThanAgentMinBet = 3306,

    [Description("Higher Than Agent Max Bet.")]
    HigherThanAgentMaxBet = 3307,

    [Description("Higher Than Agent Max Per Match.")]
    HigherThanAgentMaxPerMatch = 3308,

    [Description("Higher Than Agent Table Limit.")]
    HigherThanAgentTableLimit = 3309,

    [Description("Sport Type And Market Type Has Duplicate.")]
    DuplicateSportTypeAndMarketType = 3310,

    [Description("Account Is Deleted.")] AccountIsDeleted = 3311,

    [Description("Agent Not Exists")] AgentNotExists = 4101,

    [Description("Fail To Create Player")] CreatePlayerFail = 4102,

    [Description("User Exists")] UserExists = 4103,

    [Description("Incorrect Downline Or User Not Exists")]
    IncorrectDownLineOrUserNotExists = 4104,

    [Description("Cannot Find Settings To Update")]
    CanNotFindSettingsToUpdate = 4105,

    [Description("Agent Account Is Closed")]
    AgentIsClosed = 4106,

    [Description("Parent Is DownLine, Not An Agent Account")]
    ParentIsDownLineNotAnAgentAccount = 4107,

    [Description("Request Currency Not Tally With Existing Agent, Please Use Same Currency And Register Again")]
    RequestCurrencyNotTallyWithExistingAgent = 4108,

    [Description("Register Agent Ucompleted, Please Call This API Again, If Still Get Error Please Contact Support")]
    AgentRegistrationOnGameProviderFail = 4109,

    [Description("Register Player Ucompleted, Please Call This API Again, If Still Get Error Please Contact Support")]
    PlayerRegistrationOnGameProviderFail = 4110,

    [Description("Authentication Fail")] AuthenticationFail = 4201,

    [Description("Invalid Transaction Id")]
    InvalidTxnId = 4401,

    [Description("Invalid Transaction Amount")]
    InvalidTxnAmount = 4402,

    [Description("Transaction Fail")] TxnFail = 4403,

    [Description("Transaction Has Made With Same Id")]
    TxnHasMadeWithSameId = 4404,

    [Description("Insufficient Balance")] InsufficientBalance = 4501,

    [Description("Rollback Transaction Due To Insufficient Balance")]
    RollbackTxnDueToInsufficientBalance = 4502,

    [Description("Check Transaction Status Fail")]
    CheckTransactionStatusFail = 4601,

    [Description("No Transaction Found")] NoTransactionFound = 4602,

    [Description("Fail To Get Player Balance")]
    GetBalanceFail = 4701,

    [Description("Player Get Negative Outstanding")]
    NegativeOutstanding = 4702,

    [Description("Fail To Start Trading")] FailToStartTrading = 5201,

    [Description("Fail To Stop Trading")] FailToStopTrading = 5301,

    [Description("Get Customer Report Fail")]
    GetCustomerReportFail = 6101,

    [Description("Get Customer Bet List Fail")]
    GetCustomerBetListFail = 6102,

    [Description("Seamless Game Provider Not Found")]
    InvalidSeamlessGameProvider = 6543,

    [Description("Game Not Found")]
    InvalidGame = 6544,

    [Description("BetSetting Not Found")] BetSettingNotFound = 6546,

    [Description("Update BetSetting fail")]
    UpdateBetSettingFail = 6547,

    [Description("No Bet Found")] NoBetFound = 6666,

    [Description("Invalid Sport Type")] InvalidSportType = 9527,

    [Description("Invalid Market Type")] InvalidMarketType = 9528,

    [Description("Invalid League Group Type")]
    InvalidLeagueGroupType = 9529,

    [Description("Invalid Max Bet Ratio")] InvalidMaxBetRatio = 9530,

    [Description("Withdraw request so frequent")]
    WithdrawRequestSoFrequent = 9720,

    [Description("Invalid Password Format")]
    InvalidPasswordFormat = 9721,

    //App
    [Description("Cannot Get App Download Link")]
    NoDownloadLinkGet = 10000,

    [Description("Cannot Get Product")] GetProductListFail = 10001,

    [Description("CompanyPlayer Already Exist")]
    CompanyPlayerExist = 10002,

    [Description("Failed To Insert Into PageAccessToken")]
    PageAccessTokenInsertError = 10003,

    [Description("Invalid PageName")] InvalidPageName = 10004,

    [Description("Create Token Fail")] CreateTokenFail = 10005,

    [Description("Invalid Token")] InvalidToken = 10006,

    [Description("Invalid Referral Redeem Amount")]
    InvalidReferralRedeemAmount = 10007,

    [Description("Failed When Redeem")] FailedWhenRedeem = 10008,

    [Description("Company Player Not Exist")]
    CompanyPlayerNotExist = 10009,

    [Description("Invalid Process Redeem Status")]
    InvalidProcessRedeemStatus = 10010,

    [Description("Invalid Redeem RequestId")]
    InvalidRedeemRequestId = 10011,

    [Description("Invalid User Group")] InvalidUserGroup = 10012,

    [Description("Setting Not Open")] SettingNotOpen = 10013,

    //Risk-control
    [Description("You Do Not Have Permission, Please Contact Our Support")]
    NoPermission = 10100
}