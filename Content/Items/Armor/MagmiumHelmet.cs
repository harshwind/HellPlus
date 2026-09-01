using HellPlus.Content.Items.Armor;
using HellPlus.Content.Items.Placeable;
using HellPlus.Content.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class MagmiumHelmet : ModItem
    {
        //public static readonly int extraDefense = 6;
        //public static readonly int extraCrit = 6;

        //public static LocalizedText SetBonusText { get; private set; }

        public override void SetStaticDefaults()
        {
            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false; // Don't draw the head at all. Used by Space Creature Mask
            //ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Draw hair as if a hat was covering the top. Used by Wizards Hat
            // ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; // Draw all hair as normal. Used by Mime Mask, Sunglasses
            // ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true;

            //SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs(ExtraDefense);
        }

        public override void SetDefaults()
        {
            Item.width = 18; 
            Item.height = 22; 
            Item.value = Item.sellPrice(gold: 1, silver: 22); // UPDATE!!!
            Item.rare = ModContent.RarityType<HellRarity>();
            Item.defense = 25;
        }

        public override void UpdateEquip(Player player)
        {
            //player.GetCritChance(DamageClass.Generic) += 6;
            //player.maxMinions += 1;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<MagmiumBreastplate>() && legs.type == ModContent.ItemType<MagmiumLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            //player.setBonus = extraCrit + "% increased critical strike chance"; // This is the setbonus tooltip
            //player.GetCritChance(DamageClass.Generic) += extraCrit; 
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<MagmiumBar>(), 10)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}