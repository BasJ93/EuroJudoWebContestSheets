using System;

namespace EuroJudoWebContestSheets.Configuration;

public sealed class InvalidConfigurationException : Exception
{
    public InvalidConfigurationException(string? message) : base(message)
    {
    }
}