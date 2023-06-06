using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1.Views;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var welcomeLbl = new Label
            {
                StyleId = "header",
                Text = "Welcome",
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(50)
            };

            var userEntry = new Entry
            {
                Placeholder = "Enter your username",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                StyleId = "entry",
                Margin = new Thickness(5)
            };

            var psswdEntry = new Entry
            {
                Placeholder = "Enter your password",
                IsPassword = true,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                StyleId = "entry",
                Margin = new Thickness(5)
            };

            var signInButton = new Button
            {
                Text = "Login",
                StyleId = "button",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(50)
            };

            signInButton.Clicked += (sender, e) =>
            {
                if (CheckUser(userEntry.Text) == "" && CheckPsswd(psswdEntry.Text) == "")
                {
                    string user = userEntry.Text;
                    string psswd = psswdEntry.Text;
                    int Pass = 0;

                    //UserLoginDigits range for student is 11 - 44
                    //UserLoginDigits range for teacher is 45 - 85
                    //UserLoginDigits range for admissions committee is 90 - 99

                    if (CheckUserGroup(user.Substring(0, 2)) == "") Pass = int.Parse(user.Substring(0, 2));

                    if (Pass >= 11 && Pass <= 14) Navigation.PushAsync(new StudentsPage(1));
                    else if (Pass >= 21 && Pass <= 24) Navigation.PushAsync(new StudentsPage(2));
                    else if (Pass >= 31 && Pass <= 34) Navigation.PushAsync(new StudentsPage(3));
                    else if (Pass >= 41 && Pass <= 44) Navigation.PushAsync(new StudentsPage(4));
                    else if (Pass >= 45 && Pass <= 85) Navigation.PushAsync(new EducatorsPage());
                    else if (Pass >= 90 && Pass <= 99) Navigation.PushAsync(new AdmissionsCommittee());
                    else DisplayAlert("Error", $"No user group using such combination of digits was found", "OK");
                }
                else
                {
                    DisplayAlert("Error", $"{CheckUser(userEntry.Text)}\n{CheckPsswd(psswdEntry.Text)}", "OK");
                }
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(25),
                Children =
                {
                    welcomeLbl,

                    new StackLayout
                    {
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Padding = new Thickness(25),
                        Children = {userEntry, psswdEntry, signInButton, }
                    },

                    signInButton
                }
            };
        }

        static string CheckUser(string user)
        {
            string message = "";

            if (user == null)
            {
                message = "Поле для ввода имени не может быть пустым.";
            }
            else
            {
                foreach (char symbol in user)
                {
                    if (!char.IsLetterOrDigit(symbol) && symbol != '-' && symbol != '_')
                    {
                        message = "Поле имя может содержать только буквы, цифры, -, _";
                        break;
                    }
                }
            }
            return message;
        }

        static string CheckPsswd(string psswd)
        {
            string message = "";

            if (psswd == null)
            {
                message = "Поле для ввода пароля не может быть пустым.";
            }
            else
            {
                foreach (char symbol in psswd)
                {
                    if (!char.IsLetterOrDigit(symbol) && symbol != '_' && symbol != '-' && symbol != '.')
                    {
                        message = "Поле пароля может содержать только буквы, цифры, -, _ и точки";
                        break;
                    }
                }
            }
            return message;
        }

        static string CheckUserGroup(string pass)
        {
            string message = "";

            foreach (char symbol in pass)
            {
                if (char.IsLetter(symbol))
                {
                    message = "No user group using such combination of digits was found";
                    break;
                }
            }
            return message;
        }
    }
}
