using Xamarin.Forms;

namespace FitTemp
{
    public class EntryPage : ContentPage
    {
        public EntryPage()
        {
            StackLayout stack = new StackLayout();
            Button b = new Button()
            {
                Text = "Click me"
            };
            b.Clicked += async (sender, e) => 
            {
                await Navigation.PushAsync(new MainPage());
            };

            stack.Children.Add(b);

            Content = stack;
		}
    }
}