using System;
using Xamarin.Forms;

namespace firstapp
{

    public class ContentPageBase : ContentPage
    {
        public App MyApp = Application.Current as App;
        public ContentPageBase()
        {
        }
    }
}
