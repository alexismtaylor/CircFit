using System;
using System.Collections.Generic;
using Xamarin.Forms;
using FitTemp.Models;

namespace FitTemp
{
	public class AddPage : ContentPage
    {
        ListView list = new ListView();
        Entry circuitName;

		public AddPage()
		{
			var stack = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = 50,
			};

			circuitName = new Entry()
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

            subButton.Clicked += submitCircuit;


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

			stack.Children.Add(circuitName);
			stack.Children.Add(addStack);

			Device.StartTimer(new TimeSpan(0, 0, 0, 15, 0), TimerElapsed);

			this.BackgroundColor = Color.LightGray;
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

        private void submitCircuit(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("tempExercises") && circuitName.Text != "")
			{
				var exerciseList = Application.Current.Properties["tempExercises"] as List<ExerciseModel>; //get exercises
                CircuitModel circuit = new CircuitModel();
                circuit.circuit = exerciseList;
                circuit.name = circuitName.Text;

                if(Application.Current.Properties.ContainsKey("circuits"))
                {  
                    var circuits = Application.Current.Properties["circuits"] as List<CircuitModel>;
					Application.Current.Properties.Remove("circuits");
                    circuits.Add(circuit);
                    Application.Current.Properties["circuits"] = circuits;
				}
                else
                {
                    var circuitList = new List<CircuitModel>();
                    circuitList.Add(circuit);
                    Application.Current.Properties["circuits"] = circuitList;
                }

                list.ItemsSource = ""; //clear circuit 
                circuitName.Text = ""; //clear circuit name
                Application.Current.Properties.Remove("tempExercises"); //clear the temp circuit
            }
        }
	}
}
