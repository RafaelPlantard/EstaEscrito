using Xamarin.Forms;

namespace EstaEscrito
{
    /// <summary>
    /// The app initializer.
    /// </summary>
    public class App : Application
    {
        #region Constructors
        
        /// <summary>
        /// Initialize and runs the <see cref="Bootstrapper"/>.
        /// </summary>
        public App()
        {
            Bootstrapper bootstrapper = new Bootstrapper();

            bootstrapper.Run(this);
        } 

        #endregion
    }
}
