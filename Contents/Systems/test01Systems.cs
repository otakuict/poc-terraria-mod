using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace test01.Systems
{
    public class YourModSystem : ModSystem
    {
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int index = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
            if (index != -1 && ModContent.GetInstance<test01>().configInterface?.CurrentState != null)
            {
                layers.Insert(index, new LegacyGameInterfaceLayer(
                    "YourMod: Config UI",
                    delegate
                    {
                        ModContent.GetInstance<test01>().configInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI));
            }
        }

        public override void UpdateUI(GameTime gameTime)
        {
            ModContent.GetInstance<test01>().configInterface?.Update(gameTime);
        }
    }
}
