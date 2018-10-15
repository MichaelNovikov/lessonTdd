using Android.App;
using Android.OS;
using Android.Widget;
using lessonTdd.Coonverter;
using System;

namespace lessonTdd.Droid
{
    [Activity(Label = "lessonTdd", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        Presenter _presenter;
        EditText inputAmount;
        EditText inputFrom;
        EditText inputTo;
        Button btnCalt;
        TextView viewResult;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _presenter = new Presenter(new ConverterInteractor(new RatioSourceStub()));

            inputAmount = FindViewById<EditText>(Resource.Id.editTxtAmount);
            inputFrom = FindViewById<EditText>(Resource.Id.editTxtFrom);
            inputTo = FindViewById<EditText>(Resource.Id.editTxtTo);
            btnCalt = FindViewById<Button>(Resource.Id.btnCalc);
            viewResult = FindViewById<TextView>(Resource.Id.viewVResult);

            btnCalt.Click += btnResult_Click;
        }

        private async void btnResult_Click(object sender, EventArgs e)
        {
            var res = "";

            try
            {
                res = await _presenter.GetAmount(inputAmount.Text, inputFrom.Text, inputTo.Text);
            }
            catch (ArgumentException)
            {
                inputAmount.SetTextColor(Android.Graphics.Color.Red);
                inputFrom.SetTextColor(Android.Graphics.Color.Red);
                inputTo.SetTextColor(Android.Graphics.Color.Red);
                return;
            }
            catch (ConvertException)
            {
                Toast toast = Toast.MakeText(this,"ConvertException", ToastLength.Long);
                toast.Show();
                return;
            }

            inputAmount.SetTextColor(Android.Graphics.Color.Black);
            inputFrom.SetTextColor(Android.Graphics.Color.Black);
            inputTo.SetTextColor(Android.Graphics.Color.Black);

            viewResult.Text = res;
        }
    }
}

