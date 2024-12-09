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
        private TabHost _tabHost;

        // Elements for the Birthday tab
        private Button createBirthdayCardBtn;
        private EditText sender_birthdayTxt, recipientTxt, ageTxt;

        // Elements for wedding tab
        private Button createWeddingCardBtn;
        private EditText sender_weddingTxt, brideTxt, groomTxt;

        // Elements for Show All Cards tab
        private Button backBtn;
        private ListView listView1;
        private List<GreetingCard> _cardsList;

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
            // initialize the TabHost
            _tabHost = FindViewById<TabHost>(Resource.Id.tabHost);
            _tabHost.Setup();

            //set up Tab 1 (Add Birthday Card)
            var tab1 = _tabHost.NewTabSpec("tab1");
            tab1.SetIndicator("Tab 1");
            tab1.SetContent(Resource.Id.Birthday);
            _tabHost.AddTab(tab1);

            //set up Tab 2 (Add Birthday Card)
            var tab2 = _tabHost.NewTabSpec("tab1");
            tab1.SetIndicator("Tab 2");
            tab1.SetContent(Resource.Id.Wedding);
            _tabHost.AddTab(tab1);

            //set up Tab 3 (Add Birthday Card)
            var tab3 = _tabHost.NewTabSpec("tab1");
            tab1.SetIndicator("Tab 3");
            tab1.SetContent(Resource.Id.ShowAll);
            _tabHost.AddTab(tab1);
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