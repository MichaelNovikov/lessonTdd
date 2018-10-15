// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace lessonTdd.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _btnConvert { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _lblRes { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _tfAmount { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _tfFrom { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField _tfTo { get; set; }

        [Action ("_btnConvert_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void _btnConvert_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (_btnConvert != null) {
                _btnConvert.Dispose ();
                _btnConvert = null;
            }

            if (_lblRes != null) {
                _lblRes.Dispose ();
                _lblRes = null;
            }

            if (_tfAmount != null) {
                _tfAmount.Dispose ();
                _tfAmount = null;
            }

            if (_tfFrom != null) {
                _tfFrom.Dispose ();
                _tfFrom = null;
            }

            if (_tfTo != null) {
                _tfTo.Dispose ();
                _tfTo = null;
            }
        }
    }
}