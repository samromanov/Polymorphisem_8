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
    [Activity(Label = "ShowAllCradsActivity")]
    public class ShowAllCradsActivity : Activity
    {
        private Button backBtn;
        private ListView listView1;
        //private ScrollView scrollView1;
        private List<GreetingCard> _cardsList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //SetContentView(Resource.Layout.showAllCards);

            // Create your application here
            Init();
        }
        
        public void Init()
        {
            backBtn = FindViewById<Button>(Resource.Id.backBtn);

            //scrollView1 = FindViewById<ScrollView>(Resource.Id.scrollView1);

            backBtn.Click += BackBtn_Click;

            //var items = CardsList.cardsList;


            // Get reference to the ListView
            listView1 = FindViewById<ListView>(Resource.Id.listView1);

            // Create an instance of the adapter
            Adapter1 adapter = new Adapter1(this, CardsList.cardsList);

            // Set the adapter to the ListView
            listView1.Adapter = adapter;

        }
       // private void Listview2_ItemClick(object sender, AdapterView.ItemClickEventArgs e)

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Intent backIntent = new Intent();
            SetResult(Result.Ok, backIntent);
            this.Finish();
        }
    }
}