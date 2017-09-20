using System;
using System.Collections.Generic;
using Xamarin.Forms;
using FitTemp.Models;

namespace FitTemp
{
	public class AddPage : ContentPage
    {
        ListView list = new ListView();

		public AddPage()
		{
			var stack = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = 50,
			};

			var circuitName = new Entry()
			{
				Placeholder = "Circuit Name",
				TextColor = Color.Black,
				PlaceholderColor = Color.Gray
			};

			var addStack = new StackLayout()
			{
				Spacing = 30
			};


			var exercises = new Label()
			{
				Text = "Exercises",
				TextColor = Color.Black,
				VerticalOptions = LayoutOptions.Center
			};

			var addButton = new Button()
			{
				Text = "Add Exercise",
				TextColor = Color.Black,
				BackgroundColor = Color.SkyBlue,
				WidthRequest = 100
			};

            var subButton = new Button()
            {
                Text = "Submit Circuit",
                TextColor = Color.Black,
                BackgroundColor = Color.SkyBlue,
                WidthRequest = 100
            };


            addButton.Clicked += addExercise;

			if (Application.Current.Properties.ContainsKey("tempExercises"))
			{
				var exerciseList = Application.Current.Properties["tempExercises"] as List<ExerciseModel>;
                List<string> exerciseNames = new List<string>();
                foreach(var exercise in exerciseList)
                {
                    exerciseNames.Add(exercise.name);
                }

                list.ItemsSource = exerciseNames;
			}

			addStack.Children.Add(exercises);
			addStack.Children.Add(list);
			addStack.Children.Add(addButton);
            addStack.Children.Add(subButton);

			var scrollView = new ScrollView()
			{

			};

			stack.Children.Add(circuitName);
			stack.Children.Add(addStack);
			//stack.Children.Add(scrollView);

			Device.StartTimer(new TimeSpan(0, 0, 0, 15, 0), TimerElapsed);

			this.BackgroundColor = Color.LightGray;
			//scrollView.Content = stack;
            //Content = scrollView;
            Content = stack;
		}

		bool TimerElapsed()
		{
            list.ItemsSource = null;
            if (Application.Current.Properties.ContainsKey("tempExercises"))
			{
				var exerciseList = Application.Current.Properties["tempExercises"] as List<ExerciseModel>;
				List<string> exerciseNames = new List<string>();
				foreach (var exercise in exerciseList)
				{
					exerciseNames.Add(exercise.name);
				}

				list.ItemsSource = exerciseNames;
			}
			return true;
		}

		private void addExercise(object sender, EventArgs e)
		{
			Navigation.PushModalAsync(new AddExercise());
		}
	}
}
