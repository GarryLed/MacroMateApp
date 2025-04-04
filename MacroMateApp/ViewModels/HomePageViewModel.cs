﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroMateApp.ViewModels
{
    class HomePageViewModel
    {
        public UserGoalsViewModel GoalsVM { get; set; }
        public DailyLogViewModel LogVM { get; set; }

        public HomePageViewModel()
        {
            // composite view model 
            // these view models are used on the home page to display and update the daily log and user goals
            GoalsVM = App.SharedUserGoalsViewModel;
            LogVM = App.SharedDailyLogViewModel;
        }
    }
}
