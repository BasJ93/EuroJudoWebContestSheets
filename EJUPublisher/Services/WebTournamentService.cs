using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EJUPublisher.Configuration;
using EJUPublisher.Models;
using EJUPublisher.Services.Interfaces;
using EuroJudoProtocols.ShowFights.Models;
using EuroJudoWebContestSheets.Models.Tournament;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EJUPublisher.Services;

/// <inheritdoc />
public sealed class WebTournamentService : IWebTournamentService
{
    private readonly ILogger<WebTournamentService> _logger;
    private readonly IWebConfiguration _webConfiguration;
    private readonly IContestSheetsConfiguration _contestSheetsConfiguration;

    private readonly IDictionary<(string, string), int> _remoteCategories = new Dictionary<(string, string), int>();
    
    private readonly HttpClient _httpClient;

    public WebTournamentService(IWebConfiguration webConfiguration, IContestSheetsConfiguration contestSheetsConfiguration, ILogger<WebTournamentService> logger)
    {
        _webConfiguration = webConfiguration;
        _contestSheetsConfiguration = contestSheetsConfiguration;
        _logger = logger;

        _httpClient = new HttpClient();
        _httpClient.Timeout = TimeSpan.FromSeconds(5);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Add("X-Api-Key", _webConfiguration.ApiKey);
    }
    
    /// <inheritdoc />
    public async Task<CategoryDto> CreateNewCategory(CreateCategoryDto category, CancellationToken ctx)
    {
        Uri uploadPath = new Uri($"{_webConfiguration.WebServer}{_contestSheetsConfiguration.CreateContestPath}");
        
        StringContent requestBody = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8,
            "application/json");

        try
        {
            HttpResponseMessage response = await _httpClient.PostAsync(uploadPath, requestBody, ctx);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync(ctx);
                CategoryDto createdCategory = JsonConvert.DeserializeObject<CategoryDto>(json);
                
                _remoteCategories.Add((category.Short, category.Weight), createdCategory.Id);
                
                return createdCategory;
            }

            return default;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception during result upload.");
            return default;
        }
    }

    /// <inheritdoc />
    public int GetActiveTournament()
    {
        return _contestSheetsConfiguration.TournamentId;
    }

    /// <inheritdoc />
    public async Task<IList<TournamentDto>> GetAvailableTournaments(CancellationToken ctx = default)
    {
        Uri requestUri = new Uri($"{_webConfiguration.WebServer}{_contestSheetsConfiguration.TournamentsPath}");

        HttpResponseMessage response;
        
        try
        {
            response = await _httpClient.GetAsync(requestUri, ctx);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "General failure during request.");
            return default;
        }

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync(ctx);
            return JsonConvert.DeserializeObject<IList<TournamentDto>>(json);
        }

        return default;
    }

    /// <inheritdoc />
    public async Task<IList<CategoryDto>> GetAvailableCategoriesForTournament(int id, CancellationToken ctx = default)
    {
        Uri requestUri = new Uri($"{_webConfiguration.WebServer}{_contestSheetsConfiguration.GetCategoriesForTournamentPath}?tournamentId={id}");

        HttpResponseMessage response;
        
        try
        {
            response = await _httpClient.GetAsync(requestUri, ctx);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "General failure during request.");
            return default;
        }

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync(ctx);
            return JsonConvert.DeserializeObject<IList<CategoryDto>>(json);
        }

        return default;
    }

    /// <inheritdoc />
    public async Task<int?> GetIdForCategory(string categoryShort, string weight, CancellationToken ctx = default)
    {
        if (_remoteCategories.ContainsKey((categoryShort, weight)))
        {
            return _remoteCategories[(categoryShort, weight)];
        }
        
        Uri requestPath = new Uri($"{_webConfiguration.WebServer}{_contestSheetsConfiguration.GetCategoryIdPath}?TournamentId={_contestSheetsConfiguration.TournamentId}&CategoryShort={System.Web.HttpUtility.UrlEncode(categoryShort)}&Weight={System.Web.HttpUtility.UrlEncode(weight)}");

        HttpResponseMessage response;
        
        try
        {
            response = await _httpClient.GetAsync(requestPath, ctx);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception while trying to get the id for category: tournament [{tournament}], short [{shortName}], weight [{weight}].", _contestSheetsConfiguration.TournamentId, categoryShort, weight);
            
            return null;
        }

        if (response.IsSuccessStatusCode)
        {
            string idString = await response.Content.ReadAsStringAsync(ctx);
            if (int.TryParse(idString, out int id))
            {
                _remoteCategories.Add((categoryShort, weight), id);
                return id;
            }

            return null;
        }
        return null;
    }

    /// <inheritdoc />
    public void SetActiveTournament(int tournamentId)
    {
        _logger.LogInformation("Current tournament set to [{tournamentId}]", tournamentId);
        _contestSheetsConfiguration.TournamentId = tournamentId;
    }
    
    /// <inheritdoc />
    public async Task<bool> UploadContestResult(Contest contest, CancellationToken ctx = default)
    {
        int? categoryId = await GetIdForCategory(contest.Short, contest.Weight, ctx);

        if (categoryId != null)
        {
            Uri uploadPath = new Uri($"{_webConfiguration.WebServer}{_contestSheetsConfiguration.ContestResultPath}");

            UploadContestResultDto contestResultDto = new(_contestSheetsConfiguration.TournamentId, categoryId.Value, contest.Number,
                contest.CompetitorWhite, contest.CompetitorBlue, contest.ScoreWhite, contest.ScoreBlue, true);

            StringContent requestBody = new StringContent(JsonConvert.SerializeObject(contestResultDto), Encoding.UTF8,
                "application/json");

            try
            {
                HttpResponseMessage result = await _httpClient.PostAsync(uploadPath, requestBody, ctx);

                if (result.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception during result upload.");
                return false;
            }
            
            //DataReceivedLogEvent?.Invoke(this,
            //    $"{DateTime.Now.ToLongTimeString()} New data received consisting of {contestOrder.SelectMany(c => c.Contests).Count()} contests. Upload success: {result.IsSuccessStatusCode}");
        }
        return false;
    }

    /// <inheritdoc />
    public async Task<bool> UploadContestResult(QueuedUpload contest, CancellationToken ctx = default)
    {
        Uri uploadPath = new Uri($"{_webConfiguration.WebServer}{_contestSheetsConfiguration.ContestResultPath}");

        if (contest.ContestResult.CategoryId == 0)
        {
            int? categoryId = await GetIdForCategory(contest.Short, contest.Weight, ctx);
            if (categoryId == null)
            {
                return false;
            }

            contest.ContestResult.CategoryId = categoryId.Value;
        }
        
        
        StringContent requestBody = new StringContent(JsonConvert.SerializeObject(contest.ContestResult), Encoding.UTF8,
            "application/json");

        try
        {
            HttpResponseMessage result = await _httpClient.PostAsync(uploadPath, requestBody, ctx);

            if (result.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception during result upload.");
            return false;
        }
            
        //DataReceivedLogEvent?.Invoke(this,
        //    $"{DateTime.Now.ToLongTimeString()} New data received consisting of {contestOrder.SelectMany(c => c.Contests).Count()} contests. Upload success: {result.IsSuccessStatusCode}");
    }
}