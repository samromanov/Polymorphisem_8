using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace Polymorphism_ex._8
{
    [Activity(Label = "AddBirthdayActivity")]
    public class AddBirthdayActivity : Activity
    {
        private Button createBirthdayCardBtn;
        private EditText sender_birthdayTxt, recipientTxt, ageTxt;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //SetContentView(Resource.Layout.addBirthdayCard);

            // Create your application here
            Init();
        }
        public void Init()
        {
            createBirthdayCardBtn = FindViewById<Button>(Resource.Id.createBirthdayCardBtn);
            sender_birthdayTxt = FindViewById<EditText>(Resource.Id.sender_birthdayTxt);
            recipientTxt = FindViewById<EditText>(Resource.Id.recipientTxt);
            ageTxt = FindViewById<EditText>(Resource.Id.ageTxt);

            createBirthdayCardBtn.Click += CreateBirthdayCard_Click;

        }

        private void CreateBirthdayCard_Click(object sender, EventArgs e)
        {
            string[] newBDCard = { sender_birthdayTxt.Text, recipientTxt.Text, ageTxt.Text };
            Intent backIntent = new Intent();
            backIntent.PutExtra("newBirthdayCard", newBDCard);
            SetResult(Result.Ok, backIntent);
            this.Finish();
        }
    }
}