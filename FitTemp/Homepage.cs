using System;

using Xamarin.Forms;

namespace FitTemp
{
	public class HomePage : ContentPage
	{
		public HomePage()
		{
			var stack = new StackLayout() { Spacing = 10 };

			var title = new Label();
			title.Text = "Home";

			stack.Children.Add(title);
			Content = stack;

		}
	}
}

