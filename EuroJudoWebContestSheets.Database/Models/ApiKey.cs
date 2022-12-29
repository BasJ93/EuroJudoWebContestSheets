namespace EuroJudoWebContestSheets.Database.Models
{
    public class ApiKey : BaseIdEntity
    {
        public string Owner { get; set; } = String.Empty;
        public Guid Key { get; set; } = Guid.Empty;
        public DateTime Created { get; set; }
        public virtual IList<Role> Roles { get; set; } = new List<Role>();

        public ApiKey()
        {
            
        }

        public ApiKey(int id, string owner, Guid key, DateTime created, IList<Role> roles)
        {
            Id = id;
            Owner = owner;
            Key = key;
            Created = created;
            Roles = roles;
        }
    }
}