using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
[QueryProperty(nameof(ClientId), "clientId")]
public partial class ProjectDetailView : ContentPage
{
    public int ClientId { get; set; }
    public ProjectDetailView()
    {
        InitializeComponent();
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ProjectViewModel(ClientId);
    }
}