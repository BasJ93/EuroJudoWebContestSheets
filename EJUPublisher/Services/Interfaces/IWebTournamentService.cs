using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EJUPublisher.Models;
using EuroJudoProtocols.ShowFights.Models;
using EuroJudoWebContestSheets.Models.Tournament;

namespace EJUPublisher.Services.Interfaces;

public interface IWebTournamentService
{
    /// <summary>
    /// Create a new category within the selected tournament.
    /// </summary>
    /// <param name="category">The category to create.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>A bool indicating the success.</returns>
    Task<CategoryDto> CreateNewCategory(CreateCategoryDto category, CancellationToken ctx);

    /// <summary>
    /// Get the active tournament id.
    /// </summary>
    /// <returns>The id of the tournament.</returns>
    int GetActiveTournament();
    
    /// <summary>
    /// Retrieve all available tournaments on the server to upload results for. 
    /// </summary>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>A list of tournament DTOs.</returns>
    Task<IList<TournamentDto>> GetAvailableTournaments(CancellationToken ctx = default);

    /// <summary>
    /// Retrieve a list of available categories for a given tournament.
    /// </summary>
    /// <param name="id">The id for the tournament.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>A list of category DTOs.</returns>
    Task<IList<CategoryDto>> GetAvailableCategoriesForTournament(int id, CancellationToken ctx = default);
    
    /// <summary>
    /// Get the web server id for a given category. The tournament is inferred from the selected tournament.
    /// </summary>
    /// <param name="categoryShort">The short name of the category.</param>
    /// <param name="weight">The weight of the category.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>The id as an int if the server has the category.</returns>
    Task<int?> GetIdForCategory(string categoryShort, string weight, CancellationToken ctx = default); 
    
    /// <summary>
    /// Set the active tournament id for result uploads.
    /// </summary>
    /// <param name="tournamentId">The tournament id.</param>
    void SetActiveTournament(int tournamentId);
    
    /// <summary>
    /// Upload the result of a contest to the webserver.
    /// </summary>
    /// <param name="contest">The contest to upload.</param>
    /// <param name="ctx">Cancellation token</param>
    /// <returns>A bool indicating success.</returns>
    Task<bool> UploadContestResult(Contest contest, CancellationToken ctx = default);
    
    /// <summary>
    /// Upload the queued result of a contest to the webserver.
    /// </summary>
    /// <param name="contest">The contest to upload.</param>
    /// <param name="ctx">Cancellation token</param>
    /// <returns>A bool indicating success.</returns>
    Task<bool> UploadContestResult(QueuedUpload contest, CancellationToken ctx = default);
}