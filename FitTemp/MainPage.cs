using System;

using Xamarin.Forms;

namespace FitTemp
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
			this.Title = "CircuitFitness";

			this.Children.Add(new ViewPage()
			{
				Title = "View Circuits"
			});

			this.Children.Add(new AddPage()
			{
				Title = "Add Circuit"
			});

			this.Children.Add(new ExplorePage()
			{
				Title = "Explore"
			});
        }
    }
}

