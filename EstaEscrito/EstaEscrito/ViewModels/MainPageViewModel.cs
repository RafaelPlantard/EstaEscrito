using EstaEscrito.Events;
using EstaEscrito.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;

namespace EstaEscrito.ViewModels
{
    /// <summary>
    /// The <see cref="MainPage"/>'s view model.
    /// </summary>
    public class MainPageViewModel : BindableBase
    {
        #region Fields

        private string _title = "Main Page";

        private readonly INavigationService _navigationService;

        #endregion

        #region Properties

        /// <summary>
        /// The title of the main page.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// A command to navigate to a next page.
        /// </summary>
        public DelegateCommand NavigateCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the commands and services with injection dependency.
        /// </summary>
        /// <param name="navigationService">A implementation of <see cref="INavigationService"/>.</param>
        public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;

            NavigateCommand = new DelegateCommand(Navigate);

            eventAggregator.GetEvent<GoBackEvent>().Subscribe(HandleGoBackEvent);
        }

        #endregion

        #region Methods

        #region Private

        private void Navigate()
        {
            NavigationParameters parameters = new NavigationParameters();

            parameters.Add("message", "Message from Main Page");

            _navigationService.Navigate<DetailPageViewModel>(parameters);
        }

        private void HandleGoBackEvent(string payload)
        {
            Title = payload;
        }

        #endregion

        #endregion
    }
}
