namespace EuroJudoWebContestSheets.Database.Models;

public class ApiKeyLinkRole
{
    public int ApiKeyId { get; set; }

    public int RoleId { get; set; }
    
    public virtual ApiKey ApiKey { get; set; }
    
    public virtual Role Role { get; set; }
}