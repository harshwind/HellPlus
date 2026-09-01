using HellPlus.Content.Rarities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Items
{
	public class DemonFin : ModItem
	{
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 25;
        }

        public override void SetDefaults() {
			Item.width = 26;
			Item.height = 18;
			Item.maxStack = 9999;
            Item.value = Item.sellPrice(copper: 66);
            Item.rare = ModContent.RarityType<HellRarity>();
            ItemID.Sets.IsLavaImmuneRegardlessOfRarity[Item.type] = true;
        }
	}
}