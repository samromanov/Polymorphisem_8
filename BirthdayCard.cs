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
    public class BirthdayCard : GreetingCard
    {
        private int age;
        private string recipient;
        public BirthdayCard(string recipient, string sender, int age) : base(recipient, sender)
        {
            this.age = age;
            this.recipient = recipient;
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public override string GreetingMsg()
        {
            return base.ToString() + $" {this.recipient}, happy birthday!\nYou're {this.age} years old!";
        }
        public override string ToString()
        {
            return base.ToString() + $"\nAge: {this.age}";
        }
    }
}