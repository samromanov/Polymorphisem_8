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
    public class WeddingCard : GreetingCard
    {
        private string bride;
        private string groom;
        private string sender;
        public WeddingCard(string bride, string groom, string sender) : base($"{bride} and {groom}", sender)
        {
            this.bride = bride;
            this.groom = groom;
            this.sender = sender;
        }
        public override string GreetingMsg()
        {
            return $" Mrs. {this.bride} and Mr. {this.groom}, happy wedding day!\nfrom {this.sender}";
        }
        //public override string ToString()
        //{
        //    return base.ToString();
        //}
    }
}