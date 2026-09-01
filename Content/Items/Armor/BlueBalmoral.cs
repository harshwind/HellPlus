using HellPlus.Content.Items.Armor;
using HellPlus.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class BlueBalmoral : ModItem
    {
        public static readonly int extraDefense = 3;

        public override void SetStaticDefaults()
        {
            ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 24; 
            Item.height = 22; 
            Item.value = Item.sellPrice(silver: 72);
            Item.rare = ItemRarityID.Cyan;
            Item.defense = 4;
            Item.accessory = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Generic) += 5;
            player.maxMinions += 3;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<CooledMagmiumBreastplate>() && legs.type == ModContent.ItemType<CooledMagmiumLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+" + extraDefense + " defense"; 
            player.statDefense += extraDefense;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<CooledMagmiumBar>(), 6)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}