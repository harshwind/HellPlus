using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HellPlus.Content.Walls
{
    public class MagmiumBrickWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            Main.wallHouse[Type] = true;

            AddMapEntry(new Color(69, 0, 0));
        }
    }
}