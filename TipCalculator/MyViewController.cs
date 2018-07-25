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
        UITextField totalAmount;
        UIButton calcButton;
        UILabel resultLabel;
        UISegmentedControl tipAmount;
        double percentage = 10;

		public override void ViewDidLoad()
		{
            base.ViewDidLoad();

            // set background color
            this.View.BackgroundColor = UIColor.Yellow;

            // Create the text field or edit text - set size 
            totalAmount = new UITextField(
                    new CGRect(20, 35, View.Bounds.Width - 40, 35))
            {
                KeyboardType = UIKeyboardType.DecimalPad,
                BorderStyle = UITextBorderStyle.RoundedRect,
                Placeholder = "Ingrese el total"
            };

            //create a Button
            calcButton = new UIButton(UIButtonType.Custom)
            {
                Frame = new CGRect(20 //left and right edges of the screen (pts)
                                                                 , 80, //top (pts)
                                                                 View.Bounds.Width - 40, // You will need to use the View.Bounds.Width to stretch this across the view.
                                                                 45),//height (pts)
                BackgroundColor = UIColor.FromRGB(0, 0.5f, 0),
            };
            calcButton.SetTitle("Calcular", UIControlState.Normal);

            //create percent table
            tipAmount = new UISegmentedControl(new CGRect(20, 125, View.Bounds.Width - 40, 40));
            tipAmount.InsertSegment("10%", 0, false);
            tipAmount.InsertSegment("15%", 1, false);
            tipAmount.InsertSegment("20%", 2, false);
            tipAmount.InsertSegment("25%", 3, false);
            tipAmount.SelectedSegment = 1;

            //create a Label
            resultLabel = new UILabel(new CGRect(20, 200, View.Bounds.Width - 40, 40))
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
            View.AddSubviews(totalAmount, calcButton, tipAmount, resultLabel);

            calcButton.TouchUpInside += CalcButton_TouchUpInside;
            tipAmount.ValueChanged += TipAmount_ValueChanged;
        }

        void CalcButton_TouchUpInside(object sender, EventArgs e)
        {
            totalAmount.ResignFirstResponder();
            double value = 0;
            Double.TryParse(totalAmount.Text, out value);
            resultLabel.Text = string.Format("Tip is {0:C}", TipCalculator.GetTip(value, percentage));
        }

        void TipAmount_ValueChanged(object sender, EventArgs e)
        {
            var index = tipAmount.SelectedSegment;
            switch (index)
            {
                case 0: percentage = 10;
                    break;
                case 1:
                    percentage = 15;
                    break;
                case 2:
                    percentage = 20;
                    break;
                case 3:
                    percentage = 25;
                    break;
                default:
                    percentage = 10;
                    break;
            }
        }

	}
}
