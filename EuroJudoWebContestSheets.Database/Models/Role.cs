namespace EuroJudoWebContestSheets.Database.Models;

public class Role : BaseIdEntity
{
    public string Name { get; set; } = string.Empty;

    public virtual IList<ApiKey> ApiKeys { get; set; } = new List<ApiKey>();

    public Role()
    {
        
    }
    
    public Role(string name)
    {
        Name = name;
    }
}