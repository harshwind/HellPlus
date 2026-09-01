using Terraria.ModLoader;
using Terraria.WorldBuilding;
using System.Collections.Generic;
using HellPlus.Common.Systems.GenPasses;
using rail;

namespace HellPlus.Common.Systems
{
    internal class WorldSystem : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int underworldIndex = tasks.FindIndex(t => t.Name.Equals("Hellforge"));
            if (underworldIndex != -1)
            {
                tasks.Insert(underworldIndex + 1, new HellPlusOreGenPass("Magmium Ore Pass", 320f));
            }
        }
    }
}
