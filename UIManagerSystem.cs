using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.UI;
using test01.UI;
using Terraria;
using System.Collections.Generic;

namespace test01
{
    public class UIManagerSystem : ModSystem
    {
        internal UserInterface configInterface;
        internal ClassConfigUI configUI;

        public override void Load()
        {
            if (!Main.dedServ)
            {
                configUI = new ClassConfigUI();
                configUI.Activate();
                configInterface = new UserInterface();
            }
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (configInterface?.CurrentState != null)
            {
                configInterface.Update(gameTime);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int index = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (index != -1 && configInterface?.CurrentState != null)
            {
                layers.Insert(index, new LegacyGameInterfaceLayer(
                    "test01: Config UI",
                    () =>
                    {
                        configInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI
                ));
            }
        }

        public void ShowUI()
        {
            configInterface?.SetState(configUI);
        }

        public void HideUI()
        {
            configInterface?.SetState(null);
        }
    }
}
