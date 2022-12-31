namespace EJUPublisher.Configuration;

public sealed class UploadConfig : IUploadConfig
{
    public bool UploadContest { get; set; }
    public bool UploadResults { get; set; }
}