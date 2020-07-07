using System;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace FirstAApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button _addButton;
        EditText _getValue;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.activity_main);

                var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
                SetSupportActionBar(toolbar);

                var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
                fab.Click += FabOnClick;

                _addButton = FindViewById<Button>(Resource.Id.btnSubmit);
                _addButton.Click += btnSubmitOnClick;

                var listView = FindViewById<ListView>(Resource.Id.listView1);
                listView.Adapter = new ArrayAdapter<string>(this, Resource.Layout.ListViewItem, Resource.Id.label);


            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }


        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            var view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        private void btnSubmitOnClick(object sender, EventArgs eventArgs)
        {
            var txtText = FindViewById<EditText>(Resource.Id.editText1);
            var adapter = (ArrayAdapter<string>)FindViewById<ListView>(Resource.Id.listView1).Adapter;
            adapter.Add(txtText.Text);
            txtText.Text = "";
        }
    }
}

