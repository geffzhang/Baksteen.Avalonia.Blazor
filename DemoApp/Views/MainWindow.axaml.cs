using Avalonia.ReactiveUI;
using DemoApp.ViewModels;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using ReactiveUI;
using System.Reactive;

namespace DemoApp.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        var rootComponents = new RootComponentsCollection()
        {
            new RootComponent("#app", typeof(DemoApp.Main), null)
        };

        Resources.Add("services", App.AppHost!.Services);
        Resources.Add("rootComponents", rootComponents);

        InitializeComponent();
    
        this.WhenActivated(d => d(ViewModel!.ExitInteraction.RegisterHandler(DoExitAsync)));
    }

    private async Task DoExitAsync(InteractionContext<Unit, Unit> ic)
    {
        Close();
        await Task.CompletedTask;
        ic.SetOutput(Unit.Default);
    }
}
