using System;
using System.Collections.Generic;
using FitTemp.Models;
using Xamarin.Forms;

namespace FitTemp
{
	public class AddExercise : ContentPage
	{
		Entry exerciseName;
		Picker timePicker, repPicker, setPicker;
		int timeIndex, repIndex, setIndex;
		public AddExercise()
		{
			var stack = new StackLayout()
			{
				Padding = 50,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				Spacing = 50
			};

			exerciseName = new Entry()
			{
				TextColor = Color.Black,
				Placeholder = "Exercise Name",
				PlaceholderColor = Color.Gray
			};

			timePicker = new Picker()
			{
				Title = "Time (min:sec)"
			};
			timePicker.SelectedIndexChanged += (sender, e) =>
			{
				timeIndex = timePicker.SelectedIndex;
			};

			timePicker.Items.Add("None");
			for (int seconds = 15; seconds <= 180; seconds += 15)
			{
				if (seconds > 60)
				{
					int totalSecs = seconds % 60;
					int totalMins = seconds / 60;
					string addTime = "";
					if (totalSecs == 0)
						addTime = "0" + Convert.ToString(totalMins) + ":" + "0" + Convert.ToString(totalSecs);
					else
						addTime = "0" + Convert.ToString(totalMins) + ":" + Convert.ToString(totalSecs);


					timePicker.Items.Add(addTime);
				}
				else
				{
					string addTime = "00" + ":" + Convert.ToString(seconds);
					timePicker.Items.Add(addTime);

				}
			}

			repPicker = new Picker()
			{
				Title = "Reps per set"
			};
			repPicker.SelectedIndexChanged += (sender, e) =>
			{
				repIndex = repPicker.SelectedIndex;
			};

			repPicker.Items.Add("None");

			for (int i = 1; i <= 30; i++)
				repPicker.Items.Add(Convert.ToString(i));

			setPicker = new Picker()
			{
				Title = "Sets"
			};
			setPicker.SelectedIndexChanged += (sender, e) =>
			{
				setIndex = setPicker.SelectedIndex;
			};

			setPicker.Items.Add("None");
			for (int i = 1; i <= 10; i++)
				setPicker.Items.Add(Convert.ToString(i));


			var subButton = new Button()
			{
				Text = "Add to Circuit",
				BackgroundColor = Color.SkyBlue
			};

			subButton.Clicked += SubButton_Clicked;

			stack.Children.Add(exerciseName);
			stack.Children.Add(timePicker);
			stack.Children.Add(setPicker);
			stack.Children.Add(repPicker);
			stack.Children.Add(subButton);

			this.BackgroundColor = Color.LightGray;


			Content = stack;
		}

		void SubButton_Clicked(object sender, EventArgs e)
		{
			ExerciseModel exercise = new ExerciseModel();
			if (exerciseName.Text != "" && timeIndex != -1 && setIndex != -1 && repIndex != -1)
			{
				exercise.name = exerciseName.Text;
				exercise.reps = Convert.ToInt32(repPicker.Items[repIndex]);
				exercise.time = timePicker.Items[timeIndex];
				exercise.sets = Convert.ToInt32(setPicker.Items[setIndex]);
				if (Application.Current.Properties.ContainsKey("tempExercises"))
				{
					var exers = Application.Current.Properties["tempExercises"] as List<ExerciseModel>;
					Application.Current.Properties.Remove("tempExercises");
					exers.Add(exercise);
					Application.Current.Properties["tempExercises"] = exers;
				}
				else
				{
					var exers = new List<ExerciseModel>();
					exers.Add(exercise);
					Application.Current.Properties["tempExercises"] = exers;
				}
				Navigation.PopModalAsync();
			}
			else
				DisplayAlert("Error", "Please add all information about this exercise.", "OK");

		}
	}
}