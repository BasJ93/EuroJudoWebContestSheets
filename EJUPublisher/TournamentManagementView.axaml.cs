using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using EJUPublisher.Models.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace EJUPublisher;

public partial class TournamentManagementView : Window
{
    public TournamentManagementView()
    {
        InitializeComponent();
    }

    public TournamentManagementView(IServiceProvider serviceProvider)
    {
        DataContext = serviceProvider.GetService<TournamentManagementViewModel>();
        
        InitializeComponent();
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}