using EstaEscrito.ViewModels;
using EstaEscrito.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;

namespace EstaEscrito
{
    /// <summary>
    /// Is simply a class that initializes all the services that Prism will be using.
    /// </summary>
    public class Bootstrapper : UnityBootstrapper
    {
        #region Methods

        #region Protected

        /// <summary>
        /// It will return the page we want to use as the root page of the application.
        /// </summary>
        /// <returns>The root page of the application.</returns>
        protected override Page CreateMainPage()
        {
            return Container.Resolve<MainPage>();
        }

        /// <summary>
        /// It will be used to register our application types with our container of choice.
        /// </summary>
        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<DetailPage, DetailPageViewModel>();
        }

        #endregion

        #endregion
    }
}
