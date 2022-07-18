using System;
using System.Collections.Generic;


using AppKit;
using Foundation;

namespace JMind
{
//NSViewController is Apples class to manage view
// Loaded from a nib file
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

		
		
		public NSColor[] ChosenColours;

		// initialising an object to provide me with random numbers
		public Random rand = new Random();


		//Counter for Game
		// This is a critical variable in the game as it tracks the row the user is on
		public int Counter = 0;


		// MARK: DECLARED PUBLIC LISTS

		// I had a problem when I declared lists : public int[] PC; or public int[]PC = new int[]();
		//it needed me to provide values for the list

		//List of correct positions and colours for each row
		public int[] PC = { 0, 0, 0, 0,0,0,0,0,0 };

		//List of colours in each row
		public int[] ColOnly = {0,0,0,0,0,0,0,0};

		//created a list so that I could allocated a numeric number to each
		//Apple colour object
		//initially did this as a enum but had issues to reverted to a list

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

		//Again had to initialise with values otherwise it gave me issues
		public NSColor[] Solution = { NSColor.Black, NSColor.Black, NSColor.Black, NSColor.Black, }  ;
		public NSColor[] Row1 = { NSColor.Black, NSColor.Black, NSColor.Black, NSColor.Black, };
		public NSColor[] Row2 = { NSColor.Black, NSColor.Black, NSColor.Black, NSColor.Black, };
		public NSColor[] Row3 = { NSColor.Black, NSColor.Black, NSColor.Black, NSColor.Black, };

		//----------------------------------------------

		// MARK: DECLARED FUNCTIONS


	// Function at start of game to choose the colour combination of the solution
	//

		public void ChooseColorSelection()
		{
			//Fussy needs me to initialise with values - I used 7 because at this
			//stage there are no colours in the list at position 7
			// Should use a try catch statement to catch if one of the 7 values are being inserted

			int[] NumberSelection = { 7, 7, 7, 7 };

			//initialise a counter for the while loop 
			int t = 0;
			while (t < 4)
			{
			//Random number gets chosen
				int number = rand.Next(6);

	// test to determine if the random generator is choosing the same number again
	// This is very likely as it is choosing 4 numbers out of 6
				bool test = true;


	//Loops through the numbers already selected if no correlation
	//then test remains true and the next number can be used
				foreach (int n in NumberSelection)
				{
					if (n == number)
					{
						test = false;
						break;
					}
				}

				if (test == true)
				{
					NumberSelection[t] = number;
					t++;
				}
			}


	//Take the random number generated and correlate them with NSObject colour
	//From the ColourOptions list, place them into the top NSButtons on the UI


            Console.WriteLine($"Color Options are {ChosenColours}");
			ATop.BezelColor = ColorOptions[NumberSelection[0]];
			BTop.BezelColor = ColorOptions[NumberSelection[1]];
			CTop.BezelColor = ColorOptions[NumberSelection[2]];
			DT.BezelColor = ColorOptions[NumberSelection[3]];
		}



//A verbose method of determining which button needs to change colour by the user selection
//The Colour Selector button at the bottom sends a string parameter of with the letters
// A B C D representing the Columns, this is filtered through an if statement
// The row is determined by the counter number declared above and is filtered by the switch statement
// 
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


//Function to alter the colour when you click on the button that chooses colours
// Simple if statements if the button is currently a certain colour it must change to the next
// colour in the order
//You can use this function to add more colour. This will make the puzzle harder

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
			int ColurSubtract = 0; // Was going to initially report colours excluding the ones that were already in the right position, abandoned this decision


//Created a list to hold the colours of the current row
			//List<NSColor> CurrentSolution = new List<NSColor>();
			NSColor[] CurrentSolution = { NSColor.Black, NSColor.Black, NSColor.Black, NSColor.Black };

			Console.WriteLine($"Checking Row {Counter}");

	// Place the Colour combination for the solution in a
    // Public List defined for global scope containing
	//NSColor objects

            Solution[0] = ATop.BezelColor;
            Solution[1] = BTop.BezelColor;
            Solution[2] = CTop.BezelColor;
            Solution[3] = DT.BezelColor;

            Console.WriteLine(ATop.BezelColor);

			//Place the guess for each row in a local scoped List which will later
			//be used to output the results
			//Cases refer to the rows of guesses handles by a public int variable Counter


			//The switch codition is to ensure we are getting the colours from the current row which is determined by the
			//Counter variable
			switch (Counter)
            {
				case 1:
					CurrentSolution[0] = A1.BezelColor;
					CurrentSolution[1] = B1.BezelColor;
					CurrentSolution[2] = C1.BezelColor;
					CurrentSolution[3] = D1.BezelColor;
					break;

				case 2:
					CurrentSolution[0] = A2.BezelColor;
					CurrentSolution[1] = B2.BezelColor;
					CurrentSolution[2] = C2.BezelColor;
					CurrentSolution[3] = D2.BezelColor;
					break;
				case 3:
					CurrentSolution[0] = A3.BezelColor;
					CurrentSolution[1] = B3.BezelColor;
					CurrentSolution[2] = C3.BezelColor;
					CurrentSolution[3] = D3.BezelColor;
					break;
				case 4:
					CurrentSolution[0] = A4.BezelColor;
					CurrentSolution[1] = B4.BezelColor;
					CurrentSolution[2] = C4.BezelColor;
					CurrentSolution[3] = D4.BezelColor;
					break;
				case 5:
					CurrentSolution[0] = A5.BezelColor;
					CurrentSolution[1] = B5.BezelColor;
					CurrentSolution[2] = C5.BezelColor;
					CurrentSolution[3] = D5.BezelColor;
					break;

				default:
					CurrentSolution[0] = A5.BezelColor;
					CurrentSolution[1] = B5.BezelColor;
					CurrentSolution[2] = C5.BezelColor;
					CurrentSolution[3] = D5.BezelColor;
					break;
			}


		//MARK: Working out the results for each row

		
			for (int i = 0; i <4; i++)
            {
				if (CurrentSolution[i] ==  Solution[i])

                {
					PositionsColours++;
					ColurSubtract++;
					Console.WriteLine($"The Positions are {PositionsColours}, for Row {Counter}");

                }
			}

			for (int j = 0; j < 4; j++)
			{
				foreach (NSColor C in CurrentSolution)
				{
					Console.WriteLine($"Colour {C} in Guesses for Row {Counter}");
					Console.WriteLine($"Does it match the actual Solution Color {Solution[j]}");
					if (C == Solution[j])
					{
						ColoursOnly++;
					}
				}
			}

			PC[Counter] = PositionsColours;
			ColOnly[Counter] = ColoursOnly;

			if (PositionsColours == 4)
            {
				YouWin();
            }

		//OUTPUTING THE RESULTS TO GUI
			switch (Counter)
            {
				case 1:
					P1.StringValue = PositionsColours.ToString();
					CO1.StringValue = ColOnly[Counter].ToString();
					Console.WriteLine(ColOnly[Counter].ToString());
					break;
				case 2:
					P2.Title = PositionsColours.ToString();
					CO2.Title = ColOnly[Counter].ToString();

					//P1.StringValue = PositionsColours.ToString();
					//CO1.StringValue = ColOnly[Counter].ToString();
					Console.WriteLine(ColOnly[Counter].ToString());
					break;
				case 3:
					P3.Title = PositionsColours.ToString();
					CO3.Title = ColOnly[Counter].ToString();

					//P1.StringValue = PositionsColours.ToString();
					//CO1.StringValue = ColOnly[Counter].ToString();
					Console.WriteLine(ColOnly[Counter].ToString());
					break;
				case 4:
					P4.Title = PositionsColours.ToString();
					CO4.Title = ColOnly[Counter].ToString();

					//P1.StringValue = PositionsColours.ToString();
					//CO1.StringValue = ColOnly[Counter].ToString();
					Console.WriteLine(ColOnly[Counter].ToString());
					break;
				case 5:
					P5.Title = PositionsColours.ToString();
					CO5.Title = ColOnly[Counter].ToString();

					//P1.StringValue = PositionsColours.ToString();
					//CO1.StringValue = ColOnly[Counter].ToString();
					Console.WriteLine(ColOnly[Counter].ToString());
					break;

				default:
					P5.Title = PositionsColours.ToString();
					CO5.Title = ColOnly[Counter].ToString();

					//P1.StringValue = PositionsColours.ToString();
					//CO1.StringValue = ColOnly[Counter].ToString();
					Console.WriteLine(ColOnly[Counter].ToString());
					break;
			}

			
		}


		public void YouWin()
        {
			UserOutput.Title = "YOU WIN!!!";
			UserOutput.TextColor = NSColor.Red;
			Reveal.Hidden = true;


		}




	//MARK: EVENTS BUTTON ACTIONS


		//Start Game

		partial void Start(NSObject sender)
		{
			UserOutput.Title = "Welcome to our mind game";
			UserOutput.TextColor = NSColor.Blue;
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

        partial void RevealButton(NSObject sender)
        {
			Reveal.BackgroundColor = NSColor.Clear;
			Reveal.Hidden = true;

        }


    }
}

// TO DO:
// Check to see colour is not selected twice in row
// Better response to user when he wins game, maybe an animation
//

