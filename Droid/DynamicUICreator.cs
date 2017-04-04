using System;
using System.Collections.Generic;
using Android.Content;
using Android.Widget;

namespace SQliteTest.Droid
{
	public class DynamicUICreator
	{
		InputTypeBuilder builder = new InputTypeBuilder();
		public DynamicUICreator()
		{
		}
		public LinearLayout createDynamicUI(Context context, List<TableInfo> columns)
		{
			var scrollView = new ScrollView(context);

 			var layout = new LinearLayout(context);
			layout.Orientation = Orientation.Vertical;
			layout.Id = 1;
			layout.AddView(scrollView);
			foreach (var c in columns)
			{
				var childUI = getLinearUI(context, c);
				layout.AddView(childUI);

			}
			return layout;

		}

		LinearLayout getLinearUI(Context context, TableInfo c)
		{
			LinearLayout l = new LinearLayout(context);
			l.Orientation = Orientation.Horizontal;


			matchUI(context,l, c);
			return l;




		}

		void matchUI(Context context, LinearLayout l, TableInfo c)
		{
			
			switch (c.type)
			{
				case "integer":
				case "INT":
					builder.createLabel(context, l, c.name);
					builder.createTextforInteger(context,l);
					break;
				case "String":
				case "TEXT":
				case "text":	
					builder.createLabel(context, l, c.name);
					builder.createTextforString(context, l);
					break;
				//case "Double":
				//	builder.createTextforDouble(view);
				//	break;
				case "Boolean":
				case "BOOLEAN": 
					builder.createLabel(context, l, c.name);
					builder.createCheckBox(context, l); 
								break;
				//case "List": break;
				case "Date":
					builder.createLabel(context, l, c.name);
					builder.createDatePicker(context, l);
					break;

			}

		}


	}
}
