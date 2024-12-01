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
    internal class Adapter1 : BaseAdapter<GreetingCard>
    {
        private Context _context;
        private List<GreetingCard> _items;
        private GreetingCard tempGC;
        private Dialog selectedCardDialog;
        private LinearLayout currCardDialogLayout;

        public Adapter1(Context context, List<GreetingCard> items)
        {
            _context = context;
            _items = items;
        }

        public override GreetingCard this[int position]
        {
            get { return _items[position]; }
        }
        public override int Count
        {
            get { return _items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _items[position];

            var view = convertView;
            if (view == null)
                view = LayoutInflater.From(_context).Inflate(Resource.Layout.IndividualItem, parent, false);

            var imgItemImage = view.FindViewById<ImageView>(Resource.Id.imgItemImage);
            var txtItemProps = view.FindViewById<TextView>(Resource.Id.txtItemProps);
            Button showCardBtn = view.FindViewById<Button>(Resource.Id.showCardBtn); // set up the button which shows the card is selected
            showCardBtn.Tag = position;
            showCardBtn.Click += ShowCardBtn_Click;



            for (int i = 0; i < CardsList.cardsList.Count; i++)
            {
                if (CardsList.cardsList[i].ToString() == txtItemProps.Text) 
                {
                    if (CardsList.cardsList[i] is BirthdayCard)
                    {
                        imgItemImage.SetImageResource(Resource.Drawable.greeting_Card);
                        tempGC = CardsList.cardsList[i];

                    }
                    else
                    {
                        imgItemImage.SetImageResource(Resource.Drawable.weddingCard);
                        tempGC = CardsList.cardsList[i];
                    }
                }
            }
            
            txtItemProps.Text = item.ToString();

            return view;
        }

        private void ShowCardBtn_Click(object sender, EventArgs e)//AdapterView.ItemClickEventArgs e
        {
            //Dialog d = new Dialog(_context);
            //d.SetContentView(Resource.Layout.IndividualCard);
            //d.SetTitle("Reset");
            //d.SetCancelable(true);
            Button clickedBtn = (Button)sender;
            int position = (int)clickedBtn.Tag;
            ShowCurrentCard(position);

        }
        private void ShowCurrentCard(int position)
        {
            GreetingCard currentCard = CardsList.cardsList[position];
            selectedCardDialog = new Dialog(this._context);
            selectedCardDialog.SetContentView(Resource.Layout.IndividualCard);
            selectedCardDialog.SetCancelable(true);
            TextView greetingMsgTV = selectedCardDialog.FindViewById<TextView>(Resource.Id.content_txt);
            currCardDialogLayout = selectedCardDialog.FindViewById<LinearLayout>(Resource.Id.individual_card);

            if (currentCard != null)
            {
                if (currentCard is WeddingCard)
                {
                    currCardDialogLayout.SetBackgroundResource(Resource.Drawable.weddingCard);
                }
                if (currentCard is AdultBirthCard)
                {
                    currCardDialogLayout.SetBackgroundResource(Resource.Drawable.greeting_Card); 
                }
                if (currentCard is YouthBirthCard)
                {
                    currCardDialogLayout.SetBackgroundResource(Resource.Drawable.greeting_Card); // have to change
                }

                greetingMsgTV.Text = currentCard.GreetingMsg();
            }
            selectedCardDialog.Show();
        }

    }
}