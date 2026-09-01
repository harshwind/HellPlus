using HellPlus.Content.Buffs;
using HellPlus.Content.Rarities;
using System.Numerics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Accessories
{
    //[AutoloadEquip(EquipType.Shield)]
    public class PendantOfHellfire : ModItem
    {

        public static int burnTime = 9;

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ModContent.RarityType<HellRarity>();
            //Item.defense = 6;
            //Item.value = Item.buyPrice(0, 30, 0, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(ModContent.BuffType<PureHellfire>(), burnTime);
        }
    }
}