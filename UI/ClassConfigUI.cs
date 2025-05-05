using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria.ModLoader;

namespace test01.UI
{
    public class ClassConfigUI : UIState
    {
        private UIText toggleText;
        private bool someSetting = false;

        public override void OnInitialize()
        {
            var panel = new UIPanel();
            panel.Width.Set(300f, 0f);
            panel.Height.Set(150f, 0f);
            panel.Left.Set(400f, 0f);
            panel.Top.Set(200f, 0f);
            panel.BackgroundColor = new Color(73, 94, 171);
            Append(panel);

            var title = new UIText("Config TEST", 0.8f);
            title.Left.Set(10f, 0f);
            title.Top.Set(10f, 0f);
            panel.Append(title);

            var togglePanel = new UIPanel();
            togglePanel.Width.Set(200f, 0f);
            togglePanel.Height.Set(40f, 0f);
            togglePanel.Top.Set(50f, 0f);
            togglePanel.Left.Set(50f, 0f);
            togglePanel.BackgroundColor = new Color(100, 100, 200);
            panel.Append(togglePanel);

            toggleText = new UIText("Test: Close", 0.7f);
            toggleText.HAlign = 0.5f;
            toggleText.VAlign = 0.5f;
            togglePanel.Append(toggleText);

            togglePanel.OnLeftClick += (evt, el) =>
            {
                someSetting = !someSetting;
                toggleText.SetText("Test: " + (someSetting ? "Open" : "Close"));
            };

            var closePanel = new UIPanel();
            closePanel.Width.Set(100f, 0f);
            closePanel.Height.Set(40f, 0f);
            closePanel.Top.Set(100f, 0f);
            closePanel.Left.Set(100f, 0f);
            closePanel.BackgroundColor = new Color(200, 50, 50);
            panel.Append(closePanel);

            var closeText = new UIText("Close", 0.7f);
            closeText.HAlign = 0.5f;
            closeText.VAlign = 0.5f;
            closePanel.Append(closeText);

            closePanel.OnLeftClick += (evt, el) =>
            {
                ModContent.GetInstance<UIManagerSystem>().HideUI();
            };
        }
    }
}
