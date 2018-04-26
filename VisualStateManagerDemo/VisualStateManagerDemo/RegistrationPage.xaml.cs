using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualStateManagerDemo.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VisualStateManagerDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationPage : ContentPage
	{
		public RegistrationPage()
		{
			InitializeComponent ();
            UserName.TextChanged += UserName_TextChanged;
            Email.TextChanged += Email_TextChanged;
            Password.TextChanged += Password_TextChanged;
            SubmitButton.Clicked += SubmitButton_Clicked;
        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            if (IsValid())
                DisplayAlert("Welcome", "You've successfully registered", "OK");
            else
                DisplayAlert("Welcome", "You've still got some fields to correct", "OK");
        }

        bool IsValid()
        {
            var emailValid = CheckEmailValid();
            var passwordValid = CheckPasswordValid();
            var userDetailsValid = CheckUserDetailsValid();

            return emailValid && passwordValid && userDetailsValid;
        }


        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckPasswordValid();
        }

        private void UserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckUserDetailsValid();
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckEmailValid();
        }

        private bool CheckEmailValid()
        {
            bool isValid = IsValidEmail(Email.Text);

            var state = isValid ? "Valid" : "Invalid";
            VisualStateManager.GoToState(Email, state);
            VisualStateManager.GoToState(EmailMsg, state);

            return isValid;
        }

        private bool CheckPasswordValid()
        {
            var pwdLength = (Password.Text == null) ? 0 : Password.Text.Length;

            // check overall validity
            bool isValid = pwdLength >= 6;
            string validityState = isValid ? "Valid" : "Invalid";

            // check strength
            string strengthState = "Invalid";
            if (pwdLength >= 10)
                strengthState = "Strong";
            else if (pwdLength >= 6)
                strengthState = "Weak";

            VisualStateManager.GoToState(Password, validityState);
            VisualStateManager.GoToState(PasswordMsg, strengthState);

            return isValid;
        }

        private bool CheckUserDetailsValid()
        {
            var isValid = (UserName.Text ?? "").Length > 0;

            var state = isValid ? "Valid" : "Invalid";

            VisualStateManager.GoToState(UserName, state);
            VisualStateManager.GoToState(UserNameMsg, state);

            return isValid;
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}