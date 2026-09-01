using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HellPlus.Content.Tiles
{
    public class Krullkite : ModTile
    {
        public override void SetStaticDefaults()
        {
            
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;

            AddMapEntry(new Color(110, 113, 116));
        }
    }
}