using EJUPublisher.Models;
using Newtonsoft.Json;
using Xunit;

namespace EJUPublisher.Tests;

public class DeserializationTests
{
    [Fact]
    public void QueueObjectCanBeDeserialized()
    {
        string input =
            @"{""ContestResult"":{""TournamentId"":0,""CategoryId"":0,""Contest"":7,""CompetitorWhite"":"" NIEDERDORFER, Michael"",""CompetitorBlue"":"" VOS, Biko"",""ScoreWhite"":0,""ScoreBlue"":0,""ShowSimpleScore"":true},""ShortName"":""M18+"",""Weight"":""-90"",""TournamentId"":0}";

        QueuedUpload upload = JsonConvert.DeserializeObject<QueuedUpload>(input);
        
        Assert.Equal("-90", upload.Weight);
    }
}