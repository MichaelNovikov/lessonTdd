using lessonTdd.Coonverter;
using System;
using UIKit;

namespace lessonTdd.iOS
{
    public partial class ViewController : UIViewController
    {
        Presenter _presenter;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Code to start the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
            Xamarin.Calabash.Start();
#endif

            _presenter = new Presenter(new ConverterInteractor(new RatioSourceStub()));
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }

        async partial void _btnConvert_TouchUpInside(UIButton sender)
        {
            var res = "";
            try
            {
                res = await _presenter.GetAmount(_tfAmount.Text, _tfFrom.Text, _tfTo.Text);
            }
            catch (ArgumentException)
            {
                _tfAmount.TextColor = UIColor.Red;
                _tfFrom.TextColor = UIColor.Red;
                _tfTo.TextColor = UIColor.Red;
                return;
            }
            catch (ConvertException ex)
            {
                var okAlertController = UIAlertController.Create("Title", $"{ex.Message}", UIAlertControllerStyle.Alert);

                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                PresentViewController(okAlertController, true, null);
                return;
            }
            _tfAmount.TextColor = UIColor.Black;
            _tfFrom.TextColor = UIColor.Black;
            _tfTo.TextColor = UIColor.Black;

            _lblRes.Text = res;
        }
    }
}
