using EstaEscrito.Events;
using EstaEscrito.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;

namespace EstaEscrito.ViewModels
{
    /// <summary>
    /// The <see cref="DetailPage"/>'s view model.
    /// </summary>
    public class DetailPageViewModel : BindableBase, INavigationAware
    {
        #region Fields

        private string _title;

        private IEventAggregator _eventAggregator;
        private readonly INavigationService _navigationService;

        #endregion

        #region Properties

        /// <summary>
        /// The title of the detail page.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /// <summary>
        /// The command to navigate to back on a stack of pages.
        /// </summary>
        public DelegateCommand NavigateCommand { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the commands and services with injection dependency.
        /// </summary>
        /// <param name="navigationService">A implementation of <see cref="INavigationService"/>.</param>
        /// <param name="eventAggregator">A implementation of <see cref="IEventAggregator"/>.</param>
        public DetailPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            NavigateCommand = new DelegateCommand(GoBack);
        }

        #endregion

        #region Methods

        #region Private

        private void GoBack()
        {
            _eventAggregator.GetEvent<GoBackEvent>().Publish("ViewA Message");

            _navigationService.GoBack();
        }

        #endregion

        #region Public

        /// <summary>
        /// It is performed when the focus quits from the page.
        /// </summary>
        /// <param name="parameters">The navigation parameters.</param>
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        /// <summary>
        /// It is performed when the focus enters in the page.
        /// </summary>
        /// <param name="parameters">The navigation parameters.</param>
        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Title = (string)parameters["message"];
        }

        #endregion

        #endregion
    }
}
