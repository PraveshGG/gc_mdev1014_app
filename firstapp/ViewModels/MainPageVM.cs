using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace firstapp.ViewModels
{
    public class MainPageVM
    {
        public string PH_Title { get; set; }
        public ICommand SignupCommand => new Command(OnSignUpClicked);

        public MainPageVM()
        {
            PH_Title = "Moos App";
        }

        void OnSignUpClicked()
        {
            Debug.WriteLine("sign up clicked");
        }
    }
}
