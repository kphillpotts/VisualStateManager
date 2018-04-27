using System;
using Xamarin.Forms;

namespace VisualStateManagerDemo
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            CommonStatesButton.Clicked += CommonStatesButton_Clicked;
            ValidationButton.Clicked += ValidationButton_Clicked;
            OrientationButton.Clicked += OrientationButton_Clicked;
		}

        private void CommonStatesButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CommonStatesPage());
        }
        private void OrientationButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrientationPage());
        }

        private void ValidationButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrationPage());
        }
    }
}
