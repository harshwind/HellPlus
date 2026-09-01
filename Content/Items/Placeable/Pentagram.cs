using HellPlus.Content.Rarities;
using HellPlus.Content.Tiles;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;

namespace HellPlus.Content.Items.Placeable
{
    public class Pentagram : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Item.ResearchUnlockCount = 100;
            //ItemID.Sets.SortingPriorityMaterials[Item.type] = 59;
        }

        public override void SetDefaults()
        {            
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.CooledMagmiumBrick>());
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<PentagramPlaced>();
			Item.rare = ModContent.RarityType<HellRarity>();
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        /*public override void AddRecipes()
        {
            CreateRecipe(5)
                .AddIngredient(ModContent.ItemType<CooledMagmiumOre>())
                .AddIngredient(ItemID.StoneBlock, 5)
                .AddTile(TileID.Furnaces)
                .Register();

            /*CreateRecipe() // Add multiple recipes set to one Item.
                .AddIngredient<ExampleWall>(4)
                .AddTile<Tiles.Furniture.ExampleWorkbench>()
                .Register();

            CreateRecipe()
                .AddIngredient<ExamplePlatform>(2)
                .AddTile<Tiles.Furniture.ExampleWorkbench>()
                .Register();
        }*/


    }
}