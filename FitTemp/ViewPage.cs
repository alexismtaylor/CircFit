using System;
using System.Collections.Generic;
using FitTemp.Models;
using Xamarin.Forms;

namespace FitTemp
{
	public class ViewPage : ContentPage
	{
		ListView list = new ListView();
		public ViewPage()
		{
			var stack = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = 50
            };

            if(Application.Current.Properties.ContainsKey("circuits"))
            {
				var circuits = Application.Current.Properties["circuits"] as List<CircuitModel>;
                List<string> circuitNames = new List<string>();
                foreach(var circuit in circuits)
                {
                    circuitNames.Add(circuit.name);   
                }

                list.ItemsSource = circuitNames;
			}

			var title = new Label();
			title.Text = "Circuits";

			stack.Children.Add(title);
            stack.Children.Add(list);

			this.BackgroundColor = Color.LightGray;
			Device.StartTimer(new TimeSpan(0, 0, 0, 15, 0), TimerElapsed);

			Content = stack;
		}

		bool TimerElapsed()
		{
			list.ItemsSource = null;
			if (Application.Current.Properties.ContainsKey("circuits"))
			{
				var circuitList = Application.Current.Properties["circuits"] as List<CircuitModel>;
				List<string> circuitNames = new List<string>();
				foreach (var circuit in circuitList)
				{
					circuitNames.Add(circuit.name);
				}

				list.ItemsSource = circuitNames;
			}
			return true;
		}
	}
}

