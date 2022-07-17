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
		}

//---------------------------------------------------------------------
		// Unique to application


		// MARK: DECLARED PUBLIC VARIABLES

		public bool[] RowsConfirmed = { false };

		public NSColor[] ChosenColours;


		public Random rand = new Random();


		//Counter for Game
		public int Counter = 0;


		// MARK: DECLARED PUBLIC LISTS

		//List of correct positions and colours for each row
		public List<int> PC;
		//List of colours in each row
		public List<int> ColOnly;

		public NSColor[] ColorOptions =
			{
				NSColor.Red,
				NSColor.Blue,
				NSColor.Black,
				NSColor.Yellow,
				NSColor.Orange,
				NSColor.Brown
			};


	// Lists for various Rows to keep track of user guesses
		public List<NSColor> Solution;
		public List<NSColor> Row1;
		public List<NSColor> Row2;
		public List<NSColor> Row3;

//----------------------------------------------

		// MARK: DECLARED FUNCTIONS

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


		public void ChooseColorSelection()
		{
			int[] NumberSelection = { 7, 7, 7, 7 };

			int t = 0;
			while (t < 4)
			{
				//Random number gets chosen
				int number = rand.Next(6);

				// test to see 
				bool test = false;

				foreach (int n in NumberSelection)
				{
					if (n == number)
					{
						test = true;
						break;
					}
				}

				if (test == false)
				{
					NumberSelection[t] = number;
					t++;
				}
			}

            Console.WriteLine($"Color Options are {ChosenColours}");
			ATop.BezelColor = ColorOptions[NumberSelection[0]];
			BTop.BezelColor = ColorOptions[NumberSelection[1]];
			CTop.BezelColor = ColorOptions[NumberSelection[2]];
			DT.BezelColor = ColorOptions[NumberSelection[3]];
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
						Button = A2;
						Button.BezelColor = ReturnColor(A2);
						break;

					case 3:
						Button = A3;
						Button.BezelColor = ReturnColor(A3);
						break;
					case 4:
						Button = A4;
						Button.BezelColor = ReturnColor(A4);
						break;
					case 5:
						Button = A5;
						Button.BezelColor = ReturnColor(A5);
						break;
					default:
						Button = A5;
						break;

				}
            }

			else if (Column == "B")
			{
				switch (Counter)
				{
					case 1:
						Button = B1;
						Colour = ReturnColor(B1);
						Button.BezelColor = Colour;
						break;
					case 2:
						Button = B2;
						Button.BezelColor = ReturnColor(B2);
						break;

					case 3:
						Button = B3;
						Button.BezelColor = ReturnColor(B3);
						break;
					case 4:
						Button = B4;
						Button.BezelColor = ReturnColor(B4);
						break;
					case 5:
						Button = B5;
						Button.BezelColor = ReturnColor(B5);
						break;
					default:
						Button = B5;
						break;

				}
			}

			else if (Column == "C")
			{
				switch (Counter)
				{
					case 1:
						Button = C1;
						Colour = ReturnColor(C1);
						Button.BezelColor = Colour;
						break;
					case 2:
						Button = C2;
						Button.BezelColor = ReturnColor(C2);
						break;

					case 3:
						Button = C3;
						Button.BezelColor = ReturnColor(C3);
						break;
					case 4:
						Button = C4;
						Button.BezelColor = ReturnColor(C4);
						break;
					case 5:
						Button = C5;
						Button.BezelColor = ReturnColor(C5);
						break;
					default:
						Button = C5;
						break;

				}
			}

			else if (Column == "D")
			{
				switch (Counter)
				{
					case 1:
						Button = D1;
						Colour = ReturnColor(D1);
						Button.BezelColor = Colour;
						break;
					case 2:
						Button = D2;
						Button.BezelColor = ReturnColor(D2);
						break;

					case 3:
						Button = D3;
						Button.BezelColor = ReturnColor(D3);
						break;
					case 4:
						Button = D4;
						Button.BezelColor = ReturnColor(D4);
						break;
					case 5:
						Button = D5;
						Button.BezelColor = ReturnColor(D5);
						break;
					default:
						Button = D5;
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



		// Records the results of the row
		// Checks if the row solves the puzzle
		// Checks to see the results of the row
		// Outputs score to result area
		public void CheckRow()
        {

			int PositionsColours = 0;
			int ColoursOnly = 0;
			int ColurSubtract = 0;
			List<NSColor> CurrentSolution = new List<NSColor>();

			Console.WriteLine($"Checking Row {Counter}");

			Solution[0] = A1.BezelColor;
			Solution[1] = B1.BezelColor;
			Solution[2] = C1.BezelColor;
			Solution[3] = D1.BezelColor;

			switch (Counter)
            {
				case 1:
					Row1[0] = A1.BezelColor;
					Row1[1] = B1.BezelColor;
					Row1[2] = C1.BezelColor;
					Row1[3] = D1.BezelColor;

					CurrentSolution[0] = A1.BezelColor;
					CurrentSolution[1] = B1.BezelColor;
					CurrentSolution[2] = C1.BezelColor;
					CurrentSolution[3] = D1.BezelColor;
					break;

				case 2:
					Row2[0] = A2.BezelColor;
					Row2[1] = B2.BezelColor;
					Row2[2] = C2.BezelColor;
					Row2[3] = D2.BezelColor;
					break;
				case 3:
					Row3[0] = A3.BezelColor;
					Row3[1] = B3.BezelColor;
					Row3[2] = C3.BezelColor;
					Row3[3] = D3.BezelColor;
					break;
			}

			
			for (int i = 0; i <4; i++)
            {
				if (CurrentSolution[i] ==  Solution[i])

                {
					PositionsColours++;
					ColurSubtract++;

					foreach (NSColor C in CurrentSolution)
                    {
						if (C == Solution[i])
                        {
							ColoursOnly++;
                        }
                    }


                }
				
            }


			PC[Counter] = PositionsColours;
			ColOnly[Counter] = ColoursOnly - ColurSubtract;

			P1.StringValue = PositionsColours.ToString();
        }



	//MARK: EVENTS BUTTON ACTIONS


		//Start Game

		partial void Start(NSObject sender)
		{
				Counter = 1;
				ChooseColorSelection();

		}

		// Confirm Row

		partial void ConfirmRow(NSObject sender)
		{
			CheckRow();
				Counter++;
				Console.WriteLine($"Counter is {Counter} ");
		}

		partial void A(NSObject sender)
		{
			NSButton Button = ReturnButton("A");		
        }

		partial void B(NSObject sender)
		{
			NSButton Button = ReturnButton("B");
		}

		partial void C(NSObject sender)
		{
			NSButton Button = ReturnButton("C");
		}
		partial void D(NSObject sender)
		{
			NSButton Button = ReturnButton("D");
		}
	}
}

