using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

/*
	Copyright (C) 2019 Sabastian Peters, Yuya Yoshino
*/

namespace Runesole
{
	static class Controls
	{
		public static Key moveLeft = Key.A; //sets A to left move
		public static Key moveRight = Key.D; //sets D to right move
        public static Key moveUp = Key.W; //sets W to up move
        public static Key moveDown = Key.S; //sets S to down move

        public static Key attack = Key.Up; //sets Up to attack

		public static Key pauseGame = Key.Escape;
	}
}
