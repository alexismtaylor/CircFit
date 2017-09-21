using System;
using FitTemp.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FitTemp
{
    public class CircuitPage : ContentPage
    {
        ListView list = new ListView();
        Label label = new Label();
        public CircuitPage(CircuitModel circuit)
        {
			var stack = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = 50
			};

            label.Text = circuit.name;
            label.TextColor = Color.Black;

            List<string> names = new List<string>();
            foreach(var circ in circuit.circuit)
            {
                names.Add(circ.name);
            }

            list.ItemsSource = names;
            list.ItemSelected += async (sender, e) => 
            {
                if (e.SelectedItem != null)
                {
                    ExerciseModel exerc = null;
                    foreach (var exercise in circuit.circuit)
                    {
                        if (exercise.name.Equals(e.SelectedItem))
                        {
                            exerc = exercise;
                            break;
                        }
                    }
                    var exercisePage = new ExercisePage(exerc);
                    await Navigation.PushModalAsync(exercisePage);
                }
            };

            Button backButton = new Button()
            {
                Text = "Back",
                TextColor = Color.Black,
                BackgroundColor = Color.SkyBlue,
                WidthRequest = 40,
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.Start
            };

            backButton.Clicked += async (sender, e) => 
            {
                await Navigation.PopModalAsync(); //go back to viewpage
            };

            stack.Children.Add(label);
            stack.Children.Add(backButton);
			this.BackgroundColor = Color.LightGray;

			Content = stack;

		}
    }
}

