using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino
*/

// Thank you https://www.jerriepelser.com/blog/using-ansi-color-codes-in-net-console-apps/
/// Thank you https://stackoverflow.com/questions/13656846/how-to-programmatic-disable-c-sharp-console-applications-quick-edit-mode

namespace Runesole.Engine
{
	static class NativeFunctions
	{
		public enum StdHandle : int
		{
			STD_INPUT_HANDLE = -10,
			STD_OUTPUT_HANDLE = -11,
			STD_ERROR_HANDLE = -12,
		}

		public enum ConsoleMode : uint
		{
			ENABLE_ECHO_INPUT = 0x0004,
			ENABLE_EXTENDED_FLAGS = 0x0080,
			ENABLE_INSERT_MODE = 0x0020,
			ENABLE_LINE_INPUT = 0x0002,
			ENABLE_MOUSE_INPUT = 0x0010,
			ENABLE_PROCESSED_INPUT = 0x0001,
			ENABLE_QUICK_EDIT_MODE = 0x0040,
			ENABLE_WINDOW_INPUT = 0x0008,
			ENABLE_VIRTUAL_TERMINAL_INPUT = 0x0200,

			//screen buffer handle
			ENABLE_PROCESSED_OUTPUT = 0x0001,
			ENABLE_WRAP_AT_EOL_OUTPUT = 0x0002,
			ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004,
			DISABLE_NEWLINE_AUTO_RETURN = 0x0008,
			ENABLE_LVB_GRID_WORLDWIDE = 0x0010
		}


		// Imports methods from dll (typically used in c++)

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr GetStdHandle(int nStdHandle); //returns Handle

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

		[DllImport("kernel32.dll")]
		public static extern uint GetLastError();






		// Sets up console for use
		public static void InitializeConsole()
		{
			/// gets a reference to console
			IntPtr consoleHandle = GetStdHandle(-11);
			uint outConsoleMode;

			// tries to get the console mode
			if (!GetConsoleMode(consoleHandle, out outConsoleMode))
			{
				Console.WriteLine("failed to get output console mode");
				Console.ReadKey();
				return;
			}


			//outConsoleMode |= ((uint)ConsoleMode.ENABLE_EXTENDED_FLAGS) | ((uint)ConsoleMode.DISABLE_NEWLINE_AUTO_RETURN) | ((uint)ConsoleMode.ENABLE_VIRTUAL_TERMINAL_PROCESSING);
			//outConsoleMode |= 0x0004 | 0x0008;
			outConsoleMode |= ((uint)ConsoleMode.DISABLE_NEWLINE_AUTO_RETURN) | ((uint)ConsoleMode.ENABLE_VIRTUAL_TERMINAL_PROCESSING);
			outConsoleMode &= ~((uint)ConsoleMode.ENABLE_QUICK_EDIT_MODE);

			SetConsoleMode(consoleHandle, outConsoleMode);
		}

	}
}
