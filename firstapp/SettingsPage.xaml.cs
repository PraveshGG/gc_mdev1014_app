using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace firstapp
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var myApp = Application.Current as App;
            myApp.OnLogout();
        }
    }
}
