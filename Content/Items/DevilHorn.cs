using HellPlus.Content.Rarities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Items
{
	public class DevilHorn : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 2; 
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.maxStack = 9999;
            Item.value = Item.sellPrice(silver: 5);  // was 1g66s
            Item.rare = ModContent.RarityType<HellRarity>();
		}
	}
}