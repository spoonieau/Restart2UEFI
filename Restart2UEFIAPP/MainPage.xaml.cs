/*
 * Restar2UEFIAPP UWP build 1.1.0.0
 * 
 * Restart2UEFI winforms build ported to UWP.
 * Was going to be release on the windows store but due to needing the ues of a win32
 * exe and only holding a developer licence I was unable to submit.
 * 
 * I win32 dir is is the helper win32 (Restart2UEFIHelper.exe), which is need to make the 
 * OS calls out side the WR sand box.
 * 
 * Written by SpoonieAU
 * https://github.com/spoonieau/Restart2UEFI
 * Released under GPL3
 */

using System;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.ApplicationModel;
using Windows.UI.ViewManagement;
using System.Runtime.InteropServices;
using Windows.ApplicationModel.Resources;
using Windows.ApplicationModel.AppService;
using Windows.UI.Popups;
using Windows.UI;
using Windows.UI.Xaml.Navigation;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Restart2UEFIAPP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(395, 250));
            ApplicationView.PreferredLaunchViewSize = new Size(395, 250);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            var resourceLoader = ResourceLoader.GetForCurrentView();

            tblRestartButton.Text = resourceLoader.GetString("btnFirmwareRestart");
            tblShutdownButton.Text = resourceLoader.GetString("btnFirmwareShutdown");

        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutAsync();
        }

        private async void btnFirmwareRestart_ClickAsync(object sender, RoutedEventArgs e)
        {
            await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync("restart");
            
        }

        private async void btnFirmwareShutdown_ClickAsync(object sender, RoutedEventArgs e)
        {
            await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync("shutdown");
        }

        private async void AboutAsync()
        {
            About about = new About();
            await about.ShowAsync();
        }
    }
}
