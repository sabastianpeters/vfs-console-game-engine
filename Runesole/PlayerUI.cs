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
                Coord.TopLeft + Coord.Right *2, 
                "Health: " + player.health + " / " + player.maxHealth /// TODO make green, background black
            );

            UI.String(
                Coord.TopLeft + Coord.Down + Coord.Right * 2, 
                "Exp: " + player.experience + " / " + player.maxExperience ///TODO make yellow, background black
            );

            UI.String(
                Coord.TopLeft + Coord.Down + Coord.Down + Coord.Right * 2,
                "Str: " + player.attackDmg ///TODO make yellow, background black
            );
        }
    }
}
