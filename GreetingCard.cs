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
    public class GreetingCard : Activity
    {
        string recipient;
        string sender;
        public GreetingCard(string recipient, string sender)
        {
            this.recipient = recipient;
            this.sender = sender;
        }
        public string Recipient
        {
            get { return this.recipient; }
            set { this.recipient = value; }
        }
        public string Sender
        {
            get { return this.sender; }
            set { this.sender = value; }
        }
        public virtual string GreetingMsg()
        {
            return "Congratulations!";
        }
        public override string ToString()
        {
            return $"Recipient: {this.recipient}, \nSender: {this.sender}";
        }
    }
}