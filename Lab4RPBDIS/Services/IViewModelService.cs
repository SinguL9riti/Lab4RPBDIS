using Lab4RPBDIS.ViewModels;


namespace Lab4RPBDIS.Services
{
    public interface IViewModelService
    {
        HomeViewModel GetHomeViewModel(int numberRows = 10);
    }
}
