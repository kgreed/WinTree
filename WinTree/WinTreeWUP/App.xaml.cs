using System;

using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinTreeWUP.Services;
using WinTreeWUP.Views;

namespace WinTreeWUP
{
    public sealed partial class App : Application
    {
        private Lazy<ActivationService> _activationService;

        private ActivationService ActivationService
        {
            get { return _activationService.Value; }
        }

        public App()
        {
            InitializeComponent();

            // Deferred execution until used. Check https://msdn.microsoft.com/library/dd642331(v=vs.110).aspx for further info on Lazy<T> class.
            _activationService = new Lazy<ActivationService>(CreateActivationService);
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args);
            }
            
        }

        
        protected override async void OnActivated(IActivatedEventArgs args)
        {
            // await ActivationService.ActivateAsync(args);
            //https://docs.microsoft.com/en-us/windows/uwp/porting/desktop-to-uwp-extend#start
            if (args.Kind == ActivationKind.Protocol)
            {
                ProtocolActivatedEventArgs protocolArgs = (ProtocolActivatedEventArgs)args;
                Uri uri = protocolArgs.Uri;
                if (uri.Scheme == "WinTreeWup")
                {
                    Frame rootFrame = new Frame();
                    Window.Current.Content = rootFrame;
                    rootFrame.Navigate(typeof(MainPage), uri.Query);
                    Window.Current.Activate();
                }
            }
        }

        private ActivationService CreateActivationService()
        {
            return new ActivationService(this, typeof(Views.MainPage), new Lazy<UIElement>(CreateShell));
        }

        private UIElement CreateShell()
        {
            return new Views.ShellPage();
        }
    }
}
