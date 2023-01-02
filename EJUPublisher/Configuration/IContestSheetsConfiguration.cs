namespace EJUPublisher.Configuration;

public interface IContestSheetsConfiguration
{
    public string ContestResultPath { get; set; }

    public string CreateContestPath { get; set; }
    public string GetCategoryIdPath { get; set; }

    public string GetCategoriesForTournamentPath { get; set; }
    
    public string TournamentsPath { get; set; }
    
    public int TournamentId { get; set; }
}