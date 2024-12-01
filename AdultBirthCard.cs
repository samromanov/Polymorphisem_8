using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polymorphism_ex._8
{
    public class AdultBirthCard : BirthdayCard
    {
        private string sender;
        public AdultBirthCard(string recipient, string sender, int age) : base(recipient, sender, age)
        {
            this.sender = sender;
        }
        public override string GreetingMsg()
        {
            return base.ToString() + $"\nI wish you have a wonderful house, car and a lot of money!\nyours, {this.sender}";
        }
    }
}