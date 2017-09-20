using System;

using Xamarin.Forms;

namespace FitTemp
{
    public class App : Application
    {
        public App()
        {
			MainPage = new NavigationPage(new EntryPage());
		}
    }
}
