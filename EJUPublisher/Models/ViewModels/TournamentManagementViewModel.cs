using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Collections;
using EJUPublisher.Services.Interfaces;
using EuroJudoWebContestSheets.Models.Tournament;
using ReactiveUI;

namespace EJUPublisher.Models.ViewModels;

public sealed class TournamentManagementViewModel : ReactiveObject
{
    private readonly IWebTournamentService _tournamentService;

    public AvaloniaList<TournamentDto> Tournaments { get; } = new();

    private TournamentDto _selectedTournament;
    public TournamentDto SelectedTournament
    {
        get => _selectedTournament;
        set => this.RaiseAndSetIfChanged(ref _selectedTournament, value);
    }

    private string _categoryName;
    public string CategoryName
    {
        get => _categoryName;
        set => this.RaiseAndSetIfChanged(ref _categoryName, value);
    }

    private string _categoryShort;
    public string CategoryShort
    {
        get => _categoryShort;
        set => this.RaiseAndSetIfChanged(ref _categoryShort, value);
    }

    private string _categoryWeight;
    public string CategoryWeight
    {
        get => _categoryWeight;
        set => this.RaiseAndSetIfChanged(ref _categoryWeight, value);
    }

    private int _categorySize;

    public int CategorySize
    {
        get => _categorySize;
        set => this.RaiseAndSetIfChanged(ref _categorySize, value);
    }
    
    public AvaloniaList<CategoryDto> Categories { get; } = new();

    public ReactiveCommand<Unit, Unit> LoadTournamentsCommand { get; }
    public ReactiveCommand<Unit, Unit> SaveConfigurationCommand { get; }
    
    public ReactiveCommand<Unit, Unit> CreateCategoryCommand { get; }

    public TournamentManagementViewModel(IWebTournamentService tournamentService)
    {
        _tournamentService = tournamentService;
        LoadTournamentsCommand = ReactiveCommand.CreateFromTask(LoadTournaments);
        SaveConfigurationCommand = ReactiveCommand.Create(SaveConfiguration);
        CreateCategoryCommand = ReactiveCommand.CreateFromTask(CreateNewCategory);

        PropertyChanged += OnPropertyChanged;

        var _ = LoadTournaments();
    }

    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SelectedTournament))
        {
            var _ = LoadCategories();
        }
    }

    private async Task LoadTournaments(CancellationToken ctx = default)
    {
        IList<TournamentDto> tournaments = await _tournamentService.GetAvailableTournaments(ctx);
        if (tournaments.Any())
        {
            Tournaments.Clear();
            Tournaments.AddRange(tournaments);

            int active = _tournamentService.GetActiveTournament();
            if (active > 0)
            {
                SelectedTournament = Tournaments.First(t => t.Id == active);
            }
        }
    }

    private async Task LoadCategories(CancellationToken ctx = default)
    {
        IList<CategoryDto> categories = await _tournamentService.GetAvailableCategoriesForTournament(
            _selectedTournament.Id, ctx);

        if (categories.Any())
        {
            Categories.Clear();
            Categories.AddRange(categories);
        }
    }

    private async Task CreateNewCategory(CancellationToken ctx = default)
    {
        CreateCategoryDto request = new(SelectedTournament.Name, CategoryName, CategoryShort, CategoryWeight,
            CategorySize);

        CategoryDto category = await _tournamentService.CreateNewCategory(request, ctx);

        if (category != default)
        {
            Categories.Add(category);
        }
    }
    
    private void SaveConfiguration()
    {
        _tournamentService.SetActiveTournament(SelectedTournament.Id);
    }
}