using HellPlus.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Armor
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Legs value here will result in TML expecting a X_Legs.png file to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Legs)]
    public class CooledMagmiumLeggings : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 18; 
            Item.height = 18; 

            Item.value = Item.sellPrice(gold: 1, silver: 83); 
            Item.rare = ItemRarityID.Cyan; 

            Item.defense = 11; 
        }

        public override void UpdateEquip(Player player)
        {
            
            player.moveSpeed += 0.05f;
            player.GetCritChance(DamageClass.Generic) += 6;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<CooledMagmiumBar>(), 15)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}