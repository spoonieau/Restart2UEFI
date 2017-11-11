using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Resources;
using System.Reflection;
using Windows.UI.Xaml.Documents;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Restart2UEFIAPP
{
    public sealed partial class About : ContentDialog
    {
        public About()
        {
            this.InitializeComponent();
            var resourceLoader = ResourceLoader.GetForCurrentView();

            this.Title = resourceLoader.GetString("AppDisplayName") + " " + (typeof(App).GetTypeInfo().Assembly.GetName().Version).ToString();

            txtAbout.FontSize = 10;
            txtAbout.Text = resourceLoader.GetString("AboutInfo") + " ";

            Hyperlink hyperlink = new Hyperlink();
            Run gitLink = new Run();
            gitLink.Text = "https://github.com/spoonieau/Restart2UEFI";
            hyperlink.NavigateUri = new Uri("https://github.com/spoonieau/Restart2UEFI");
            hyperlink.Inlines.Add(gitLink);
            txtAbout.Inlines.Add(hyperlink);


        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        
    }
}
