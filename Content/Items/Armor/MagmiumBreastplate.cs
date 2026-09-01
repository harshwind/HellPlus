using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using HellPlus.Content.Items.Placeable;
using HellPlus.Content.Rarities;

namespace HellPlus.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    internal class MagmiumBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 1;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;

            Item.value = Item.buyPrice(gold: 2, silver: 44);  // UPDATE
            Item.rare = ModContent.RarityType<HellRarity>();

            Item.defense = 33;
        }

        public override void UpdateEquip(Player player)
        {
            /*player.buffImmune[BuffID.Bleeding] = true;
            player.buffImmune[BuffID.BrokenArmor] = true;
            
            player.GetCritChance(DamageClass.Generic) += 6;*/
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<MagmiumBar>(), 20)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}