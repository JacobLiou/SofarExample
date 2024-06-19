using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ui.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private string _welcomeText = "Welcome to MvvmCross!";
        public string WelcomeText
        {
            get => _welcomeText;
            set => SetProperty(ref _welcomeText, value);
        }
    }
}
