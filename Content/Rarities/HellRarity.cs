using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace HellPlus.Content.Rarities
{
    public class HellRarity : ModRarity
    {
        public override Color RarityColor => new Color((Main.DiscoR+100)/2, 0, 0);
    }
}