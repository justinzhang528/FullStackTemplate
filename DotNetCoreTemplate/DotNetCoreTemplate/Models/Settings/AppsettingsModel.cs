namespace DotNetCore.Models.Settings;

public class AppsettingsModel
{
    public string ProviderUrl { get; set; }
    public string ProviderRecordUrl { get; set; }
    public bool IsBetDetailInfoStore { get; set; }
    public bool IsCancelOrderRequestStoreInCache { get; set; }
    public int VirtualBaccaratGameID { get; set; }
    
    public string CustomerUrl { get; set; }
}