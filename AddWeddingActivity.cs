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
    [Activity(Label = "AddWeddingActivity")]
    public class AddWeddingActivity : Activity
    {
        private Button createWeddingCardBtn;
        private EditText sender_weddingTxt, brideTxt, groomTxt;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.addWeddingCard);
            // Create your application here
            Init();
        }
        public void Init()
        {
            createWeddingCardBtn = FindViewById<Button>(Resource.Id.createWeddingCardBtn);
            sender_weddingTxt = FindViewById<EditText>(Resource.Id.sender_weddingTxt);
            brideTxt = FindViewById<EditText>(Resource.Id.brideTxt);
            groomTxt = FindViewById<EditText>(Resource.Id.groomTxt);

            createWeddingCardBtn.Click += CreateWeddingCard_Click;
        }

        private void CreateWeddingCard_Click(object sender, EventArgs e)
        {
            string[] newWGCard = { sender_weddingTxt.Text, brideTxt.Text, groomTxt.Text };
            Intent backIntent = new Intent();
            backIntent.PutExtra("newWeddingCard", newWGCard);
            SetResult(Result.Ok, backIntent);
            this.Finish();
        }
    }
}