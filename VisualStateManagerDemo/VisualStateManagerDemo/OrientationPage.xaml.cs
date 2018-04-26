using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VisualStateManagerDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrientationPage : ContentPage
	{
		public OrientationPage ()
		{
			InitializeComponent ();
		}

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            var state = (width > height) ? "Landscape" : "Portrait";
            VisualStateManager.GoToState(DetailsBoxView, state);
            VisualStateManager.GoToState(AdditionalText, state);
        }
    }
}