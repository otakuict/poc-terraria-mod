using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace test01.Contents.NPCs
{
    [AutoloadHead]
    public class GuildMaster : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Guide];
        }

        public override void SetDefaults()
        {
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = -1;
            NPC.friendly = true;
            NPC.townNPC = true;
            NPC.dontTakeDamage = true;
            NPC.lifeMax = 250;
            NPC.knockBackResist = 0f;
        }

        public override string GetChat()
        {
            return "I am the Guild Master. You can talk to me for help or information about the game.";
        }

        public override bool CanChat() => true;

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Class";
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton && Main.LocalPlayer.whoAmI == Main.myPlayer)
            {
                ModContent.GetInstance<UIManagerSystem>().ShowUI();
            }
        }

        public override void AI()
        {
            NPC.velocity = Vector2.Zero;
        }
    }
}
