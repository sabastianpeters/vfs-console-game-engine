using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Runesole.Engine;
using Runesole.Engine.Graphics;

namespace Runesole
{
    static class PlayerUI
    {
        public static void Draw(Player player)
        {
            //player.health 
            UI.StringLeft(
                Coord.TopLeft + Coord.Down + Coord.Right * 2,
                "Level: " + player.level,
                Color.Foreground.Magenta,
                Color.Background.Black
            );

            UI.StringLeft(
                Coord.TopLeft + Coord.Down * 2 + Coord.Right *2, 
                "Health: " + Mathf.FloorToInt(player.health) + " / " + Mathf.FloorToInt(player.maxHealth),
                Color.Foreground.Green,
                Color.Background.Black
            );

            UI.StringLeft(
                Coord.TopLeft + Coord.Down * 3 + Coord.Right * 2, 
                "Exp: " + Mathf.FloorToInt(player.experience) + " / " + Mathf.CeilToInt(player.maxExperience),
                Color.Foreground.Yellow,
                Color.Background.Black
            );

            UI.StringLeft(
                Coord.TopLeft + Coord.Down * 4 + Coord.Right * 2,
                "Str: " + player.attackDmg,
                Color.Foreground.Red,
                Color.Background.Black
            );


			UI.StringLeft(
				Coord.TopLeft + Coord.Down * 5 + Coord.Right * 2,
				(player.IsDead ? "U dead" : "u good"),
				player.IsDead ? Color.Foreground.BrightRed : Color.Foreground.BrightGreen,
				Color.Background.Black
			);
		}
    }
}
