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
            UI.String(
                Coord.TopLeft + Coord.Down + Coord.Right * 2,
                "Level: " + player.level, ///TODO make yellow, background black
                Color.Forground.Magenta,
                Color.Background.Black
            );

            UI.String(
                Coord.TopLeft + Coord.Down + Coord.Down + Coord.Right *2, 
                "Health: " + Mathf.FloorToInt(player.health) + " / " + Mathf.FloorToInt(player.maxHealth), /// TODO make green, background black
                Color.Forground.Green,
                Color.Background.Black
            );

            UI.String(
                Coord.TopLeft + Coord.Down + Coord.Down + Coord.Down + Coord.Right * 2, 
                "Exp: " + Mathf.FloorToInt(player.experience) + " / " + Mathf.CeilToInt(player.maxExperience), ///TODO make yellow, background black
                Color.Forground.Yellow,
                Color.Background.Black
            );

            UI.String(
                Coord.TopLeft + Coord.Down + Coord.Down + Coord.Down + Coord.Down + Coord.Right * 2,
                "Str: " + player.attackDmg, ///TODO make yellow, background black
                Color.Forground.Red,
                Color.Background.Black
            );
        }
    }
}
