using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using EJUPublisher.Models.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EJUPublisher
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        public MainView(IServiceProvider serviceProvider)
        {
            DataContext = serviceProvider.GetService<MainViewModel>();

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
