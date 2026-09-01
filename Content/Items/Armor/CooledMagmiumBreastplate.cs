using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using HellPlus.Content.Items.Placeable;

namespace HellPlus.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    internal class CooledMagmiumBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 1;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;

            Item.value = Item.buyPrice(gold: 2, silver: 44);
            Item.rare = ItemRarityID.Cyan;

            Item.defense = 15;
        }

        public override void UpdateEquip(Player player)
        {
            player.buffImmune[BuffID.Bleeding] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
            
            player.GetCritChance(DamageClass.Generic) += 6;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<CooledMagmiumBar>(), 20)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}