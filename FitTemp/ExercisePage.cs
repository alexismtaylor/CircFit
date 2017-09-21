using System;
using FitTemp.Models;

using Xamarin.Forms;

namespace FitTemp
{
    public class ExercisePage : ContentPage
    {
        Button startB;
        Label setsNum, repsNum, timeNum;
        int currentTime = 0;
        int workoutTime;
        ExerciseModel theWorkout;
        public ExercisePage(ExerciseModel exercise)
        {
            theWorkout = exercise;
            workoutTime = exercise.time;
            StackLayout stack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Padding = 50,
                Spacing = 50
            };

            Label reps = new Label()
            {
                Text = "Repetitions: ",
                TextColor = Color.Black
            };

            repsNum = new Label()
            {
                Text = Convert.ToString(exercise.reps),
                TextColor = Color.Black
            };

            Label sets = new Label()
            {
                Text = "Sets: ",
                TextColor = Color.Black
            };

            setsNum = new Label()
            {
                Text = Convert.ToString(exercise.sets),
                TextColor = Color.Black
            };

            Label time = new Label()
            {
                Text = "Time Remaining (secs): ",
                TextColor = Color.Black
            };


            timeNum = new Label()
            {
                Text = Convert.ToString(exercise.time),
                TextColor = Color.Black
            };

            StackLayout repsStack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
            };


            repsStack.Children.Add(reps);
            repsStack.Children.Add(repsNum);

            StackLayout setsStack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
            };

            setsStack.Children.Add(sets);
            setsStack.Children.Add(setsNum);

            StackLayout timeStack = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
            };

            timeStack.Children.Add(time);
            timeStack.Children.Add(timeNum);

            Label name = new Label()
            {
                Text = exercise.name,
                TextColor = Color.Black
            };

            startB = new Button()
            {
                Text = "Start",
				TextColor = Color.Black,
				BackgroundColor = Color.SkyBlue,
				WidthRequest = 100
            };
            startB.Clicked += StartB_Clicked;

            if(exercise.time != 0)
            {//will have a timer, button for start that changes to stop
                //will have reps and sets
                
            }
            else
            {//will have a button for start that changes to stop
                //will have reps and sets
                
            }
            stack.Children.Add(name);
            stack.Children.Add(setsStack);
            stack.Children.Add(repsStack);
            stack.Children.Add(timeStack);

            this.BackgroundColor = Color.LightGray;
            Content = stack;
        }

        void StartB_Clicked(object sender, EventArgs e)
        {
            
            if (workoutTime != 0 && currentTime != workoutTime) //if there is a workout time and it hasnt been completed yet
            {
                startB.Text = "Stop";
                Device.StartTimer(new TimeSpan(0, 0, 0, 1, 0), TimerElapsed);
            }
            else
            {
                if(Convert.ToInt32(setsNum.Text) != 0)
                {//if there are still more sets left, restart timer
					Device.StartTimer(new TimeSpan(0, 0, 0, 1, 0), TimerElapsed);
				}
            }
       	}

        bool TimerElapsed()
        {
            currentTime++;
            timeNum.Text = Convert.ToString(workoutTime - currentTime);
            if (currentTime == workoutTime) //if reached end of workout time dont do the timer again
            {
                if(Convert.ToInt32(setsNum.Text) != 0)
                {
                    var num = Convert.ToInt32(setsNum.Text);
                    num--;
                    setsNum.Text = Convert.ToString(num); //new amount of sets
                    startB.Text = "Start";
                }
                else
                {
                    startB.Text = "Back";   
                }
                return false;
            }
            else //start timer again
                return true;
        }
    }
}

