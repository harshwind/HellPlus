using HellPlus.Content.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace HellPlus.Content.NPCs.Enemies
{
    public class DemonDolphin : ModNPC
    {
        
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Shark];
        }

        public override void SetDefaults()
        {
            NPC.width = 108;
            NPC.height = 42;
            NPC.damage = 88;
            NPC.defense = 15;
            NPC.lifeMax = 200;
            NPC.HitSound = SoundID.Zombie7;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 43f;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 16;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            AIType = NPCID.SandShark;
            AnimationType = NPCID.Shark;
            //NPC.ai[0]=0;
        //    NPC.ai[1] = 0f;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)  // can only spawn in hell + not on obsidian/hellstone brick
        {            
            return spawnInfo.Player.ZoneUnderworldHeight && spawnInfo.SpawnTileType != TileID.ObsidianBrick && spawnInfo.SpawnTileType != TileID.HellstoneBrick ? .11f : 0f;
        }

        public override void AI()
        {
            /*if (NPC.ai[1] <= 0f)  DELETE.....  dumb as fuck
            { 
                NPC.ai[1] = 1f;
                int npcX = (int) (NPC.Center.X / 16f);
                int npcY = (int) (NPC.Center.Y / 16f);

                for (int x = npcX-5; x <= npcX+5; x++)
                {
                    for (int y = npcY-5; y <= npcY+5; y++)
                    {
                        if (WorldGen.InWorld(x, y) && Main.tile[x, y] == TileID))
                }

            }  */

            if (Main.rand.NextBool(200) && NPC.lavaWet)  // Diving out of lava
            {

                //Main.NewText("oldVel: " + NPC.velocity);
                int randInt;
                if (Main.rand.NextBool(10))  
                    randInt = Main.rand.Next(6, 8);  // 'Super' dive
                else  
                    randInt = Main.rand.Next(2, 6);  // Normal dive

                float newY = randInt + Main.rand.NextFloat();
                Vector2 newVel = new Vector2(NPC.velocity.X, -newY);
                NPC.velocity = newVel;
                //Main.NewText("newVel: " + NPC.velocity);
            }

            /*if (NPC.ai[0]>=180)  // NPC out of lava (on land)    ALSO DELETE... PROBS
            {
                
                if (Main.rand.NextBool(50))
                {
                    NPC.lavaWet = true;
                    
                    //Main.NewText("oldVel: " + NPC.velocity);
                    // Random movements
                    float newX = Main.rand.Next(1, 4) + Main.rand.NextFloat();
                    float newY = Main.rand.Next(1, 4) + Main.rand.NextFloat();

                    Vector2 newVel;
                    if (Main.rand.NextBool())
                        newVel = new Vector2(newX, -newY);
                    else         
                        newVel = new Vector2(newX, newY);
                    NPC.velocity = newVel;
                    
                    //Main.NewText("newVel: " + NPC.velocity);

                    // Damage npc
                    int strikeDirection;
                    if (Main.rand.NextBool())
                        strikeDirection = -1;
                    else
                        strikeDirection = 1;

                    NPC.SimpleStrikeNPC(Main.rand.Next(2, 7), strikeDirection, false, Main.rand.NextFloat());
                }

            }

            if (!NPC.lavaWet)
                NPC.ai[0]++;
            else
                NPC.ai[0] = 0f;

            Main.NewText(NPC.lavaWet);
            Main.NewText(NPC.ai[0]);*/
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            target.AddBuff(BuffID.Bleeding, Main.rand.Next(5, 8));
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DemonFin>(), 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StraySoul>(), 100));
        }
    }
}
