using System;

using Xamarin.Forms;

namespace FitTemp
{
	public class ViewPage : ContentPage
	{
		public ViewPage()
		{
			var stack = new StackLayout() { Spacing = 10 };

			var title = new Label();
			title.Text = "View";

			stack.Children.Add(title);
			Content = stack;
		}
	}
}

