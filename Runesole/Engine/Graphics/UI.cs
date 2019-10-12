using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runesole.Engine.Graphics;

/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino
*/

namespace Runesole.Engine.Graphics
{
	static class UI
	{
		
		private static Action drawQueue;

		public static int promptWidth = 40;
		
		// ## CONST UTILITY VARIABLES ## // Make it easier to change values
		private const Color.Foreground DEFAULT_FG = Color.Foreground.White;
		private const Color.Background DEFAULT_BG = Color.Background.None;


		// ## PUBLIC METHODS ##

		// Draws queued up draw calls
		public static void Draw ()
		{		
			/// draws any queued calls and clears list
			if (drawQueue != null)
				drawQueue();
			drawQueue = null;
		}


		// ## PUBLIC DRAW METHODS ## // These add draw calls to the UI queue

		// draws a string starting from left of string
		public static void StringLeft (Coord pos, string s, Color.Foreground fg = DEFAULT_FG, Color.Background bg = DEFAULT_BG)
		{
			drawQueue += () => {                /// adds draw call to queue
				_drawString(pos, s, fg, bg);
			};
		}

		// draws a string starting from center of string
		public static void StringCenter(Coord pos, string s, Color.Foreground fg = DEFAULT_FG, Color.Background bg = DEFAULT_BG)
		{
			pos.x -= (s.Length / 2);            /// draws from center of string
			drawQueue += () => {                /// adds draw call to queue
				_drawString(pos, s, fg, bg);
			};
		}

		// draws a string starting from right of string
		public static void StringRight(Coord pos, string s, Color.Foreground fg = DEFAULT_FG, Color.Background bg = DEFAULT_BG)
		{
			pos.x -= s.Length;					/// draws from right of string
			drawQueue += () => {				/// adds draw call to queue
				_drawString(pos, s, fg, bg);
			};
		}

		// asks user for an input, callback is returned with result
		public static void Prompt (string question, Action<int> callback, params string[] options)
		{
			drawQueue += () => CoroutineManager.Call(_prompt(question, callback, options));
		}


		// ## PRIVATE UTITLITY METHODS ## // Things to make drawing easier

		// draws a string with left formatting at the given position
		private static void _drawString(Coord pos, string s, Color.Foreground fg, Color.Background bg)
		{
			// Exits if y is out of range
			if(!(0 <= pos.y && pos.y < ConsoleRenderer.Height))
				return;

			int x = pos.x;
			foreach (char c in s)
			{
				if (ConsoleRenderer.Width <= x)
					break;
				ConsoleRenderer.SetChar(x, pos.y, c);
				ConsoleRenderer.SetColor(x, pos.y, fg);
				ConsoleRenderer.SetColor(x, pos.y, bg);
				x++;
			}
		}

		// Prompt Coroutine
		private static IEnumerator _prompt (string question, Action<int> callback, params string[] options)
		{
			GameManager.PauseGame();

			

			Sprite promptSprite = _generatePromptSprite(options.Length);

			while (!Input.GetKeyDown(System.Windows.Input.Key.L))
			{
				promptSprite.Draw(Coord.TopLeft);
				Debug.Log("YO");
				yield return null;
			}

			GameManager.UnpauseGame();
		}

		private static void _drawPrompt (string[] promptDrawList)
		{
			int halfHeight = promptDrawList.Length / 2; /// prompt list of rows, half length is half height
			for(int i = 0, y = -halfHeight; y < halfHeight; y++, i++)
			{
				StringCenter(Coord.Center + Coord.Down * y, promptDrawList[i], Color.Foreground.White, Color.Background.Black);
			}
		}


		//private static string[] _generatePromptStrings (string str)
		//{
		//	string[] words = str.Split(' ');               // a list of words to write to screen

		//	StringBuilder currentLine = new StringBuilder();    /// a string builder holding current line (starts with left border)
		//	currentLine.Append('║');
		//	int spaceRemaining = textWidth - currentLine.Length; /// how much space is left in prompt line
		//	for (int i = 0; i < words.Length; i++)
		//	{


		//		// adds the words if they can fit
		//		if (words[i].Length < spaceRemaining)
		//		{
		//			currentLine.Append(words[i]);
		//		}
		//		else // adds spaces if it can't fit
		//		{
		//			currentLine.Insert(0, new String(' ', spaceRemaining / 2)); /// adds remaining spaces
		//			currentLine.Append(new String(' ', spaceRemaining / 2 + 1));
		//			currentLine.Append('║'); /// add right border
		//			promptDrawList.Add(currentLine.ToString()); /// adds string builder data and resets it
		//			currentLine.Clear();
		//			currentLine.Append('║'); /// add left border
		//		}

		//		spaceRemaining = textWidth - currentLine.Length + 1;
		//	}
		//}

		private static Sprite _generatePromptSprite (int height)
		{
			int textWidth = promptWidth - 2;	/// how much space text can take up
			int promptHeight = height + 2;		/// overall prompt height

			Sprite promptSprite = new Sprite(promptWidth, promptHeight, new Coord(promptWidth/2, promptHeight/2), new Spit(' ', Color.Background.Black));

			Spit xBarSpit = new Spit('═', Color.Foreground.White, Color.Background.Black);
			Spit yBarSpit = new Spit('║', Color.Foreground.White, Color.Background.Black);

			// draws top and bottom bars
			for (int x = 1; x < promptWidth; x++)
			{
				promptSprite.SetSpit(x, 0, xBarSpit);
				promptSprite.SetSpit(x, promptHeight-1, xBarSpit);
			}

			// draws left and right bars
			for (int y = 1; y < promptHeight; y++)
			{
				promptSprite.SetSpit(0, y, xBarSpit);
				promptSprite.SetSpit(promptWidth-1, y, xBarSpit);
			}


			// sets corners
			promptSprite.SetSpit(0, 0, new Spit('╔', Color.Foreground.White, Color.Background.Black));
			promptSprite.SetSpit(promptWidth-1, 0, new Spit('╗', Color.Foreground.White, Color.Background.Black));
			promptSprite.SetSpit(0, promptHeight-1, new Spit('╚', Color.Foreground.White, Color.Background.Black));
			promptSprite.SetSpit(promptWidth-1, promptHeight-1, new Spit('╝', Color.Foreground.White, Color.Background.Black));

			return promptSprite;
		}
	}
}
