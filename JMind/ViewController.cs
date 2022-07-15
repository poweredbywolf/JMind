using System;
using System.Collections.Generic;


using AppKit;
using Foundation;

namespace JMind
{

	public partial class ViewController : NSViewController
	{

		public override NSObject RepresentedObject
		{
			get
			{
				return base.RepresentedObject;
			}
			set
			{
				base.RepresentedObject = value;
				// Update the view, if already loaded.
			}
		}


		public ViewController(IntPtr handle) : base(handle)
		{
		}


		

	

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Do any additional setup after loading the view.

			//int ReturnNumberFromColour(string col)
			//{

			//	switch (col)
			//	{
			//		case blue:
			//			return 0;
			//			break;
			//		case red:
			//			return 1;
			//			break;
			//		case yellow:
			//			return 2;
			//			break;
			//		case green:
			//			return 3;
			//			break;


			//	}

			//}




		}

		//    partial void A3(NSButton sender) => A3.background(NSColor.Blue);


		//}
		//}



		public bool[] RowsConfirmed = { false };

		public int Counter = 0;


		public int ReturnRowsConfirmed()
        {
			int Count = 0;
			foreach (bool r in RowsConfirmed)
            {
				if (r == false)
						{
							Count++;

                }
            }
			Console.WriteLine($"Conter is {Counter}");
			return Count;

			
        }



        partial void ConfirmRow(NSObject sender)
        {
			Counter++;
            Console.WriteLine($"Counter is {Counter} ");
        }


		// returns the button of the relevant row
		public AppKit.NSButton ReturnButton(string Column)
        {
			NSButton Button;

			NSColor Colour = NSColor.Red;

			if (Column == "A")
            {
				switch (Counter)
				{
					case 1:
						Button = A1;
		
						Colour = ReturnColor(A1);
						Button.BezelColor = Colour;
						break;
					case 2:
						Console.Write("A2 ");
						Button = A2;
						A2.BezelColor = NSColor.Purple;


						break;
					case 3:
						Console.Write("A2 ");
						Button = A3;
						break;
					case 4:
						Console.Write("A4 ");
						Button = A4;
						break;
					case 5:
						Console.Write("A5");
						Button = A5;
						break;
					default:
						Button = A5;
						break;

				}

				
				
			}
			else
			{
				Button = A5;
			}
			


			return Button;



		}

		public NSColor ReturnColor(NSButton Button)
        {
			NSColor Colour = Button.BezelColor;

			if (Colour == NSColor.Red)
			{
				Colour = NSColor.Blue;
			}
			else if (Colour == NSColor.Blue)
			{
				Colour = NSColor.Black;
			}

			else if (Colour == NSColor.Black)
			{
				Colour = NSColor.Yellow;
			}

			else if (Colour == NSColor.Yellow)
			{
				Colour = NSColor.Orange;
			}
			else if (Colour == NSColor.Orange)
			{
				Colour = NSColor.Brown;
			}

			else
            {
				Colour = NSColor.Red;
            }

			Console.WriteLine(Colour);


			return Colour;
			
        }


		partial void A(NSObject sender)
		{


			NSButton Button = ReturnButton("A");

	



			
        }



    }
}

