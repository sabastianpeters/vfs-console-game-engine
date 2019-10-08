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
		private static char[][] buffer;			// a buffer of what to draw at end of frame
		private static Color.Forground[][] fgColorbuffer;	// foreground color buffer
		private static Color.Background[][] bgColorbuffer;	// background color buffer
		private static StreamWriter stream;	// console output (more control)

		public static int Width { get; private set; }	/// width of console renderer in columns
		public static int Height { get; private set; }  /// height of console renderer in rows


		private const char borderChar = '░';    /// what character do we surround screen with?
		private const Color.Forground borderFG = Color.Forground.DarkGray;			/// border foreground
		private const Color.Background borderBG = Color.Background.Black;	/// border background
		private static string borderString;	/// string pf 1 cell of border
		private static string borderRow;	/// string of 1 row of border char w/ styling


		public static void Update ()
		{
			Console.CursorVisible = false; /// prevents users from seeing cursor drawing

			_UpdateSize ();

			// Initializes array of rows
			buffer = new char[Height][];
			fgColorbuffer = new Color.Forground[Height][];
			bgColorbuffer = new Color.Background[Height][];


			for (int row = 0; row < buffer.Length; row++)
			{
				
				// Initializes each row
				buffer[row] = new char[Width];
				fgColorbuffer[row] = new Color.Forground[Width];
				bgColorbuffer[row] = new Color.Background[Width];

				// sets defualt values to each position
				for (int column = 0; column < buffer[row].Length; column++)
				{
					buffer[row][column] = ' ';
					fgColorbuffer[row][column] = Color.Forground.Red;
					bgColorbuffer[row][column] = Color.Background.Black;
				}
			}

		}

		// sets the forground color at given position
		public static void SetColor (int x, int y, Color.Forground fgColor)
		{
			if (fgColor == Color.Forground.None)
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
			Console.SetCursorPosition(0, 0); /// draws from top-left
			Console.Write(borderRow); /// draws top border


			StringBuilder rowOutput = new StringBuilder(); // output of each row

			for (int row = 0; row < buffer.Length; row++)
			{
				
				rowOutput.Append(borderString); /// draws left border

				/// adds row content to row output
				for (int col = 0; col < buffer[row].Length; col++)
				{
					rowOutput.Append("\u001b[");
					rowOutput.Append((int)bgColorbuffer[row][col]);
					rowOutput.Append(";");
					rowOutput.Append((int)fgColorbuffer[row][col]);
					rowOutput.Append("m");
					rowOutput.Append(buffer[row][col]); /// draws the characters with specified fg and bg color
				}


				rowOutput.Append(borderString); /// draws right border

				// writes row
				Console.WriteLine(rowOutput.ToString());
				
				rowOutput.Clear(); /// clears row output for next use
			}

			Console.Write(borderRow); /// draws bottom border

			stream.Flush();
		}












		private static void _UpdateSize ()
		{
			// ensures window doesn't become larger than the maximum buffer
			Console.SetWindowSize(130, 50);
			Console.SetBufferSize(130, 50);

			Width = Console.WindowWidth - 2;
			Height = Console.WindowHeight - 2;
		}




		
		public static void Init()
		{
			stream = new StreamWriter(Console.OpenStandardOutput());
			stream.AutoFlush = false;
			Console.SetOut(stream);
			//Console.OutputEncoding = Encoding.GetEncoding(28591);
			Console.OutputEncoding = Encoding.UTF8;

			_UpdateSize();
			string stylePrefix = $"\u001b[{(int)borderBG};{(int)borderFG}m";
			borderString = stylePrefix + borderChar;
			borderRow = stylePrefix + new String(borderChar, Console.BufferWidth);
		}
	}
}
