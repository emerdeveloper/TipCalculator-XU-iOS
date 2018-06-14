namespace TipCalculator
{
    using System;
    using CoreGraphics;
    using UIKit;

    //All view controller need to derive from 

    /*
     * iOS provides several implementations of UIViewController to manage different UI
    styles and behaviors such as navigation, alerts and tables.
    **/
    public class MyViewController : UIViewController
    {
        public MyViewController()
        {
        }

		public override void ViewDidLoad()
		{
            base.ViewDidLoad();

            // set background color
            this.View.BackgroundColor = UIColor.Yellow;

            // Create the text field or edit text - set size 
            UITextField totalAmount = new UITextField(
                    new CGRect(35, 28, View.Bounds.Width - 40, 35))
            {
                KeyboardType = UIKeyboardType.DecimalPad,
                BorderStyle = UITextBorderStyle.RoundedRect,
                Placeholder = "Ingrese el total"
            };

            //create a Button
            UIButton calcButton = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(20 //left and right edges of the screen (pts)
                                                                 , 71, //top (pts)
                                                                 View.Bounds.Width - 40, // You will need to use the View.Bounds.Width to stretch this across the view.
                                                                 45),//height (pts)
                BackgroundColor = UIColor.FromRGB(0, 0.5f, 0),
            };
            calcButton.SetTitle("Calcular", UIControlState.Normal);

            //create a Label
            UILabel resultLabel = new UILabel(new CGRect(20, 124, View.Bounds.Width - 40, 40))
            {
                TextColor = UIColor.Blue,
                TextAlignment = UITextAlignment.Center,
                Font = UIFont.SystemFontOfSize(24),
                Text = "Resultado es: $0.00",
            };

            /*
             * Now we need to add all these child views into our screen. You can add them individually (View.Add or View.AddSubview), 
             * or add them as an array of UIView objects using View.AddSubviews.
             */
            View.AddSubviews(totalAmount, calcButton, resultLabel);
        }
	}
}
