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
    internal static class CardsList
    {
        public static List<GreetingCard> cardsList = new List<GreetingCard>();
        //public CardsList()
        //{

        //}
        public static void Add(GreetingCard card)
        {
            cardsList.Add(card);
        }
    }
}