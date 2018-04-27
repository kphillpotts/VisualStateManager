using Xamarin.Forms;

namespace VisualStateManagerDemo
{
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