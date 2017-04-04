
using System;
using Android.Content;
using Android.Widget;

namespace SQliteTest.Droid
{
	public class InputTypeBuilder
	{
		int textSize = 18;
		Android.Graphics.Color textColor = Android.Graphics.Color.Aqua;
		Android.Graphics.Color labelColor = Android.Graphics.Color.Blue;
		void setTextProperties(EditText ed)
		{ 
			ed.TextSize = textSize;
			ed.SetTextColor(textColor);
			LinearLayout.LayoutParams param = new LinearLayout.LayoutParams(
	LinearLayout.LayoutParams.WrapContent,
	LinearLayout.LayoutParams.WrapContent,
	0.7f
);
			ed.LayoutParameters = param;
			ed.TextAlignment = Android.Views.TextAlignment.Center;
		}

		internal void createTextforString(Context context, LinearLayout l)
		{
			EditText ed = new EditText(context);
			ed.InputType = Android.Text.InputTypes.ClassText;
			setTextProperties(ed);

			l.AddView(ed);
		}

		internal void createCheckBox(Context context, LinearLayout l)
		{
			CheckBox ch = new CheckBox(context);
			l.AddView(ch);
			LinearLayout.LayoutParams param = new LinearLayout.LayoutParams(
	LinearLayout.LayoutParams.WrapContent,
	LinearLayout.LayoutParams.WrapContent,
	0.5f
);
			ch.LayoutParameters = param;
		}

		public InputTypeBuilder() { }

		public void createTextforInteger(Context context, LinearLayout l)
		{
			EditText ed = new EditText(context);
			ed.InputType = Android.Text.InputTypes.ClassNumber;
			setTextProperties(ed);
			//ed.setLayoutParams(param);
			l.AddView(ed);


		}

		public void createDatePicker(Context context, LinearLayout l)
		{
			DatePicker dp = new DatePicker(context);
			l.AddView(dp);
			LinearLayout.LayoutParams param = new LinearLayout.LayoutParams(
	LinearLayout.LayoutParams.WrapContent,
	LinearLayout.LayoutParams.WrapContent,
	0.5f
	);
			dp.LayoutParameters = param;


		}
		public void createLabel(Context context, LinearLayout l, string name)
		{
			TextView label = new TextView(context);
			label.Text = name;
			label.TextSize = textSize;
			label.SetTextColor ( labelColor);
			LinearLayout.LayoutParams param = new LinearLayout.LayoutParams(
	LinearLayout.LayoutParams.WrapContent,
	LinearLayout.LayoutParams.WrapContent,
	0.3f
);
			label.LayoutParameters = param;
			l.AddView(label);
		}
	}
}
