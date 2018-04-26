using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VisualStateManagerDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            Validation.Clicked += Validation_Clicked;
            Orientation.Clicked += Orientation_Clicked;
		}

        private void Orientation_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new OrientationPage());
        }

        private void Validation_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new RegistrationPage());
        }
    }
}
