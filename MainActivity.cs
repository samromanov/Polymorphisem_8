using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.Collections.Generic;

namespace Polymorphism_ex._8
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private Button addWeddingBtn, addBirthdayBtn, showAllBtn;
        //private ListView listView1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Init();
        }
        public void Init()
        {
            addWeddingBtn = FindViewById<Button>(Resource.Id.addWeddingBtn);
            addBirthdayBtn = FindViewById<Button>(Resource.Id.addBirthdayBtn);
            showAllBtn = FindViewById<Button>(Resource.Id.showAllBtn);

            addWeddingBtn.Click += AddWeddingBtn_Click;
            addBirthdayBtn.Click += AddBirthdayBtn_Click;
            showAllBtn.Click += ShowAllBtn_Click;

            
        }

        private void ShowAllBtn_Click(object sender, System.EventArgs e)
        {
            Intent showCards_intent = new Intent(this, typeof(ShowAllCradsActivity));
            StartActivity(showCards_intent);
        }

        private void AddBirthdayBtn_Click(object sender, System.EventArgs e)
        {
            Intent addBirthday_intent = new Intent(this, typeof(AddBirthdayActivity));
            StartActivityForResult(addBirthday_intent, 1);
        }

        private void AddWeddingBtn_Click(object sender, System.EventArgs e)
        {
            Intent addWedding_intent = new Intent(this, typeof(AddWeddingActivity));
            StartActivityForResult(addWedding_intent, 2);
        }


        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 1) // if birthday
            {
                if (resultCode == Result.Ok)
                {
                    string[] newBirthdayCard = data.Extras.GetStringArray("newBirthdayCard");
                    if (int.Parse(newBirthdayCard[2]) < 18) // if the recipient is young
                    {
                        YouthBirthCard newYouthBDCard = new YouthBirthCard(newBirthdayCard[1], newBirthdayCard[0], int.Parse(newBirthdayCard[2]));
                        CardsList.cardsList.Add(newYouthBDCard);
                    }
                    else // if the recipient is an adult
                    {
                        AdultBirthCard newAdultBDCard = new AdultBirthCard(newBirthdayCard[1], newBirthdayCard[0], int.Parse(newBirthdayCard[2]));
                        CardsList.cardsList.Add(newAdultBDCard);
                    }
                }
                
            }
            else // if wedding
            {
                if (resultCode == Result.Ok)
                {
                    string[] newWeddingCard = data.Extras.GetStringArray("newWeddingCard");
                    WeddingCard newWGCard = new WeddingCard(newWeddingCard[1], newWeddingCard[2], newWeddingCard[0]);
                    CardsList.cardsList.Add(newWGCard);
                }
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}