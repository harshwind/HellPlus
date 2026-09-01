using Terraria;
using Terraria.ModLoader;
using Terraria.IO;
using Terraria.WorldBuilding;
using HellPlus.Content.Tiles;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using System;

namespace HellPlus.Common.Systems.GenPasses
{
    internal class HellPlusOreGenPass : GenPass
    {
        public HellPlusOreGenPass(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Spawning Magmium Ore";

            // ~~~~~~~~~~~~~~~~~~~~~~~~MAGMIUM ORE~~~~~~~~~~~~~~~~~~~~~~~~
            int maxToSpawn = Main.maxTilesX;
            long attempts = 0;
            long maxAttempts = 1000000000000;
            for (int i=0; i<maxToSpawn; i++) {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);  // Can spawn wherever on x-axis

                int maxDec = 1000000000;
                double r1 = WorldGen.genRand.Next(1, maxDec);  
                r1 = r1 / maxDec;  // decimal between 0.0 and 1.0
                r1 = Math.Sqrt(Math.Sqrt(Math.Sqrt(r1)));  // shift towards values of 1.0
                r1 = 1 - r1;  // 'swap'
                r1 = Math.Ceiling(r1 * 1000);  // convert the decimal into a whole number, this will be the y position the ore will attempt to spawn (from the bottom y-layer upwards)
                int y = Main.maxTilesY - Convert.ToInt32(r1);                              

                Tile potentialMagmiumTile = Framing.GetTileSafely(x, y);

                if ((Framing.GetTileSafely(x + 1, y).LiquidType == LiquidID.Lava && potentialMagmiumTile.LiquidType != LiquidID.Lava) ||
                    (Framing.GetTileSafely(x, y + 1).LiquidType == LiquidID.Lava && potentialMagmiumTile.LiquidType != LiquidID.Lava) ||
                    (Framing.GetTileSafely(x - 1, y).LiquidType == LiquidID.Lava && potentialMagmiumTile.LiquidType != LiquidID.Lava) ||
                    (Framing.GetTileSafely(x, y - 1).LiquidType == LiquidID.Lava && potentialMagmiumTile.LiquidType != LiquidID.Lava) ||
                    (Framing.GetTileSafely(x + 1, y + 1).LiquidType == LiquidID.Lava && potentialMagmiumTile.LiquidType != LiquidID.Lava) ||
                    (Framing.GetTileSafely(x + 1, y - 1).LiquidType == LiquidID.Lava && potentialMagmiumTile.LiquidType != LiquidID.Lava) ||
                    (Framing.GetTileSafely(x - 1, y + 1).LiquidType == LiquidID.Lava && potentialMagmiumTile.LiquidType != LiquidID.Lava) ||
                    (Framing.GetTileSafely(x - 1, y + 1).LiquidType == LiquidID.Lava && potentialMagmiumTile.LiquidType != LiquidID.Lava))
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(1, 4), WorldGen.genRand.Next(2, 5), ModContent.TileType<MagmiumOre>());
                }
                attempts++;
                               
                if (attempts > maxAttempts)
                {
                    i = maxToSpawn;
                }
            }
        }
    }
}
