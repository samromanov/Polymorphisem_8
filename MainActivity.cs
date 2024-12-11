using Android.App;
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
        private Adapter1 _adapter;

        private TabHost _tabHost; // the tab host
        private TabWidget _tabs;
        private FrameLayout _tabContent;

        // Elements for the Birthday tab
        private Button createBirthdayCardBtn;
        private EditText sender_birthdayTxt, recipientTxt, ageTxt;

        // Elements for wedding tab
        private Button createWeddingCardBtn;
        private EditText sender_weddingTxt, brideTxt, groomTxt;

        // Elements for Show All Cards tab
        private ListView listView1;
        private List<GreetingCard> _cardsList;
        private Spinner _filterSpinner;

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

            //set up Tab 1 (Show All Cards)
            var showAllTab = _tabHost.NewTabSpec("tab1");
            showAllTab.SetIndicator("Show all cards");
            showAllTab.SetContent(Resource.Id.ShowAll);
            _tabHost.AddTab(showAllTab);


            //set up Tab 2 (Add Wedding Card)
            var weddingTab = _tabHost.NewTabSpec("tab2");
            weddingTab.SetIndicator("Add wedding card");
            weddingTab.SetContent(Resource.Id.Wedding);
            _tabHost.AddTab(weddingTab);

            //set up Tab 3 (Add Birthday Card)
            var birthdayTab = _tabHost.NewTabSpec("tab3");
            birthdayTab.SetIndicator("Add birthday card");
            birthdayTab.SetContent(Resource.Id.Birthday);
            _tabHost.AddTab(birthdayTab);

            _tabHost.CurrentTab = 0;

            //------------------------------------------------------

            // Add birthday card
            createBirthdayCardBtn = FindViewById<Button>(Resource.Id.createBirthdayCardBtn);
            sender_birthdayTxt = FindViewById<EditText>(Resource.Id.sender_birthdayTxt);
            recipientTxt = FindViewById<EditText>(Resource.Id.recipientTxt);
            ageTxt = FindViewById<EditText>(Resource.Id.ageTxt);

            createBirthdayCardBtn.Click += CreateBirthdayCardBtn_Click;

            // Add wedding card
            createWeddingCardBtn = FindViewById<Button>(Resource.Id.createWeddingCardBtn);
            sender_weddingTxt = FindViewById<EditText>(Resource.Id.sender_weddingTxt);
            brideTxt = FindViewById<EditText>(Resource.Id.brideTxt);
            groomTxt = FindViewById<EditText>(Resource.Id.groomTxt);

            createWeddingCardBtn.Click += CreateWeddingCardBtn_Click;

            // Show all cards
            _filterSpinner = FindViewById<Spinner>(Resource.Id.filterSpinner);
            listView1 = FindViewById<ListView>(Resource.Id.listView1); // Get reference to the ListView 
            _adapter = new Adapter1(this, CardsList.cardsList); // Create an instance of the adapter   
            listView1.Adapter = _adapter; // Set the adapter to the ListView

            var options = new string[] { "Adult Birthday Cards", "Youth Birthday Cards", "Wedding Cards", "All Cards" }; // filter spinner options

            // Create an adapter with the string array
            ArrayAdapter<string> arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, options);
            _filterSpinner.Adapter = arrayAdapter; // Set the adapter for the spinner

            //------------------------------------------------------

            Filter();

        }


        // Add birthday card tab
        private void CreateBirthdayCardBtn_Click(object sender, System.EventArgs e)
        {
            if (recipientTxt.Text == "" || sender_birthdayTxt.Text == "" || ageTxt.Text == "")
            {
                Toast.MakeText(this, "Empty fields detected!", ToastLength.Short).Show();
            }
            else if (int.Parse(ageTxt.Text) <= 0 || int.Parse(ageTxt.Text) > 126)
            {
                Toast.MakeText(this, "Are you sure this is the correct age?!", ToastLength.Short).Show();
            }
            else
            {
                if (int.Parse(ageTxt.Text) < 18) // if the recipient isn't an adult
                {
                    YouthBirthCard newYouthBDCard = new YouthBirthCard(recipientTxt.Text, sender_birthdayTxt.Text, int.Parse(ageTxt.Text));
                    CardsList.cardsList.Add(newYouthBDCard);
                }
                else // if the recipient is an adult
                {
                    AdultBirthCard newAdultBDCard = new AdultBirthCard(recipientTxt.Text, sender_birthdayTxt.Text, int.Parse(ageTxt.Text));
                    CardsList.cardsList.Add(newAdultBDCard);
                }

                _tabHost.CurrentTab = 0;

                recipientTxt.Text = "";
                sender_birthdayTxt.Text = "";
                ageTxt.Text = "";
            }
        }


        // Add wedding card tab
        private void CreateWeddingCardBtn_Click(object sender, System.EventArgs e)
        {
            if (groomTxt.Text == "" || brideTxt.Text == "" || sender_weddingTxt.Text == "")
            {
                Toast.MakeText(this, "Empty fields detected!", ToastLength.Short).Show();
            }
            else
            {
                WeddingCard newWGCard = new WeddingCard(brideTxt.Text, groomTxt.Text, sender_weddingTxt.Text);
                CardsList.cardsList.Add(newWGCard);

                _tabHost.CurrentTab = 0;

                brideTxt.Text = "";
                groomTxt.Text = "";
                sender_weddingTxt.Text = "";
            }
        }



        // Show all cards tab

        public void Filter() // options - "Adult Birthday Cards", "Youth Birthday Cards" , "Wedding Cards" , "All Cards"
        {
            string selectedOption = _filterSpinner.SelectedItem.ToString();


            if (selectedOption == "Adult Birthday Cards")
            {
                int index = 0;
                foreach (var card in CardsList.cardsList)
                {
                    if (!(card is AdultBirthCard)) // not a birthday card
                    {
                        _adapter.HideItemAt(index);
                    }
                    if (card is AdultBirthCard)
                    {
                        _adapter.ShowItemAt(index);
                    }
                    index++;
                }
            }
            else if (selectedOption == "Youth Birthday Cards")
            {
                int index = 0;
                foreach (var card in CardsList.cardsList)
                {
                    if (!(card is YouthBirthCard))
                    {
                        _adapter.HideItemAt(index);
                    }
                    if (card is YouthBirthCard)
                    {
                        _adapter.ShowItemAt(index);
                    }
                    index++;
                }
            }
            else if (selectedOption == "Wedding Cards")
            {
                int index = 0;
                foreach (var card in CardsList.cardsList)
                {
                    if (!(card is WeddingCard))
                    {
                        _adapter.HideItemAt(index);
                    }
                    if (card is WeddingCard)
                    {
                        _adapter.ShowItemAt(index);
                    }
                    index++;
                }
            }
            else // if (selectedOption == "All Cards")
            {
                int index = 0;
                foreach (var card in CardsList.cardsList)
                {
                    _adapter.ShowItemAt(index);
                    index++;
                }
            }
            _adapter.NotifyDataSetChanged();



        }




        //protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        //{
        //    base.OnActivityResult(requestCode, resultCode, data);
        //    if (requestCode == 1) // if birthday
        //    {
        //        if (resultCode == Result.Ok)
        //        {
        //            string[] newBirthdayCard = data.Extras.GetStringArray("newBirthdayCard");
        //            if (int.Parse(newBirthdayCard[2]) < 18) // if the recipient is young
        //            {
        //                YouthBirthCard newYouthBDCard = new YouthBirthCard(newBirthdayCard[1], newBirthdayCard[0], int.Parse(newBirthdayCard[2]));
        //                CardsList.cardsList.Add(newYouthBDCard);
        //            }
        //            else // if the recipient is an adult
        //            {
        //                AdultBirthCard newAdultBDCard = new AdultBirthCard(newBirthdayCard[1], newBirthdayCard[0], int.Parse(newBirthdayCard[2]));
        //                CardsList.cardsList.Add(newAdultBDCard);
        //            }
        //        }

        //    }
        //    else // if wedding
        //    {
        //        if (resultCode == Result.Ok)
        //        {
        //            string[] newWeddingCard = data.Extras.GetStringArray("newWeddingCard");
        //            WeddingCard newWGCard = new WeddingCard(newWeddingCard[1], newWeddingCard[2], newWeddingCard[0]);
        //            CardsList.cardsList.Add(newWGCard);
        //        }
        //    }
        //}
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}