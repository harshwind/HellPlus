using HellPlus.Content.Items.Placeable;
using HellPlus.Content.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class MagmiumLeggings : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 22; 
            Item.height = 18; 

            Item.value = Item.sellPrice(gold: 1, silver: 83);  // UPDATE
            Item.rare = ModContent.RarityType<HellRarity>();

            Item.defense = 21; 
        }

        /*public override void UpdateEquip(Player player)
        {
            
            player.moveSpeed += 0.05f;
            player.GetCritChance(DamageClass.Generic) += 6;
        }*/

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<MagmiumBar>(), 15)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}