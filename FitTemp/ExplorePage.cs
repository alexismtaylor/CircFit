using System;

using Xamarin.Forms;

namespace FitTemp
{
	public class ExplorePage : ContentPage
	{
		public ExplorePage()
		{
			var stack = new StackLayout() { Spacing = 10 };

			var title = new Label();
			title.Text = "Explore";

			stack.Children.Add(title);
			Content = stack;
		}
	}
}

