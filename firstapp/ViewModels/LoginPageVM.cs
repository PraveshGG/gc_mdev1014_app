﻿using System;
using System.Diagnostics;
using System.Windows.Input;
using firstapp.ENUMS;
using firstapp.Models;
using Xamarin.Forms;

namespace firstapp.ViewModels
{
    public class LoginPageVM
    {
        public string PH_Title { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand SigninCommand => new Command(SignInClicked);

        private ServerConnect serviceConnect => new ServerConnect();
        public LoginPageVM()
        {
            PH_Title = "Login Page";
        }

        async public void SignInClicked()
        {
            Debug.WriteLine($"check against username:{Username}, password:{Password}");
            var _user = new UserAuthInfoObject
            {
                Email = Username,
                Password = Password,
                AuthType = AuthType.SignIn,
            };

            var result = await serviceConnect.Connect(_user);

        }
    }
}
