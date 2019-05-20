using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace firstapp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var myApp = Application.Current as App;
            myApp.OnLogin();
        }
    }
}
