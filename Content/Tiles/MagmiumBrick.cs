using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HellPlus.Content.Tiles
{
	public class MagmiumBrick : ModTile
	{
		public override void SetStaticDefaults() {
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;

			AddMapEntry(new Color(69, 0, 0));
		}
	}
}