using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino
*/

namespace Runesole.Engine.Graphics
{
	static class ConsoleRenderer
	{

		// ## PUBLIC MEMBERS ##

		public static int Width { get; private set; }   /// width of console renderer in columns
		public static int Height { get; private set; }  /// height of console renderer in rows


		// ## PRIVATE MEMBERS ##

		// Buffer
		private static char[][] buffer;			// a buffer of what to draw at end of frame
		private static Color.Foreground[][] fgColorbuffer;	// foreground color buffer
		private static Color.Background[][] bgColorbuffer;	// background color buffer

		// Console
		private static string borderStringCol;	/// string pf 1 cell of border
		private static string borderStringRow;	/// string of 1 row of border char w/ styling
		private static StreamWriter stream; /// console output (more control)


		// ## CONST UTILITY VARIABLES ## // make it easier to change values
		private const char BORDER_CHAR = '░';                                   /// what character do we surround screen with?
		private const Color.Foreground BORDER_FG = Color.Foreground.DarkGray;   /// border foreground
		private const Color.Background BORDER_BG = Color.Background.Black;      /// border background



		// ## PUBLIC METHODS ##

		// Updates the Renderer and prepares it to be used for the frame
		public static void Update ()
		{
			Console.CursorVisible = false; /// prevents users from seeing cursor drawing

			_UpdateSize ();

			// Initializes array of rows
			buffer = new char[Height][];
			fgColorbuffer = new Color.Foreground[Height][];
			bgColorbuffer = new Color.Background[Height][];


			for (int row = 0; row < buffer.Length; row++)
			{
				
				// Initializes each row
				buffer[row] = new char[Width];
				fgColorbuffer[row] = new Color.Foreground[Width];
				bgColorbuffer[row] = new Color.Background[Width];

				// sets defualt values to each position
				for (int column = 0; column < buffer[row].Length; column++)
				{
					buffer[row][column] = ' ';
					fgColorbuffer[row][column] = Color.Foreground.Red;
					bgColorbuffer[row][column] = Color.Background.Black;
				}
			}

		}

		// sets the forground color at given position
		public static void SetColor (int x, int y, Color.Foreground fgColor)
		{
			if (fgColor == Color.Foreground.None)
				return; /// doesn't set color if none is provided
			fgColorbuffer[y][x] = fgColor;
		}

		// sets the background color at given position
		public static void SetColor(int x, int y, Color.Background bgColor)
		{
			if(bgColor == Color.Background.None)
				return;	/// doesn't set color if none is provided
			bgColorbuffer[y][x] = bgColor;
		}

		// sets the character to draw at given position
		public static void SetChar (int x, int y, char c)
		{
			buffer[y][x] = c;
		}


		// Render to console, row by row
		public static void Render()
		{
			// doesn't render if no width or height - Console.SetCursorPosition(0, 0) crashed program otherwise
			if(Width <= 0 || Height <= 0)
				return;

			Console.SetCursorPosition(0, 0); /// draws from top-left
			Console.WriteLine(borderStringRow); /// draws top border

			StringBuilder rowOutput = new StringBuilder(); // output of each row

			// runs through each row in buffer (like old tvs)
			for (int row = 0; row < buffer.Length; row++)
			{
				
				rowOutput.Append(borderStringCol); /// draws left border

				/// adds buffer row to row output
				for (int col = 0; col < buffer[row].Length; col++)
				{
					/// draws the characters with specified fg and bg color
					rowOutput.Append("\u001b[");					/// ansi unicode start indicator
					rowOutput.Append((int)bgColorbuffer[row][col]);	/// ansi background color
					rowOutput.Append(";");							/// ansi seperator
					rowOutput.Append((int)fgColorbuffer[row][col]);	/// ansi foreground color
					rowOutput.Append("m");							/// ansi unicode end indicator
					rowOutput.Append(buffer[row][col]);				/// draws the character
                }

				rowOutput.Append(borderStringCol); /// draws right border


				// writes row
				Console.WriteLine(rowOutput.ToString());
				rowOutput.Clear(); /// clears row output for next use
			}

			Console.Write(borderStringRow); /// draws bottom border
			stream.Flush(); /// redraws screen
		}




		// ## PRIVATE UTILITY METHODS ##

		// updates the size of the buffer
		private static void _UpdateSize ()
		{
			/// sets console buffer (what we can draw to) to max size
			/// updating it each frame to match window size will crash program 
			/// as buffer can't change fast enough and console doesn't allow smaller buffers (crash)
			Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

			// sets renderer buffers to be slightly smaller that console window
			Width = Console.WindowWidth - 4;
			Height = Console.WindowHeight - 3;

			// prevents height or width from being negative
			if(Height < 0)
				Height = 0;
			if(Width < 0)
				Width = 0;

			// update border string
			string stylePrefix = $"\u001b[{(int)BORDER_BG};{(int)BORDER_FG}m";				/// ansi border styling
			borderStringCol = stylePrefix + BORDER_CHAR + BORDER_CHAR;						/// sets vertical border string
			borderStringRow = stylePrefix + new String(BORDER_CHAR, Console.WindowWidth);	/// sets horizontal border string
		}



		// ## INTITIALIZING ## // Gives more control over when this is called compared to a static constructor
		
		public static void Init()
		{
			// Creates a custom steam to write to (allows for control over refresh using .Flush())
			stream = new StreamWriter(Console.OpenStandardOutput());
			stream.AutoFlush = false;
			Console.SetOut(stream);
			Console.OutputEncoding = Encoding.UTF8;

			_UpdateSize();
		}
	}
}
