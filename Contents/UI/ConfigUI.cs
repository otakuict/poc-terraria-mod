using Terraria.UI;
using Terraria.ModLoader.UI.Elements;
using Microsoft.Xna.Framework;
using Terraria.GameContent.UI.Elements;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.Audio; // เพิ่มการใช้ SoundEngine
using Terraria.ID;
using System;

namespace test01.UI
{
    public class ConfigUI : UIState
    {
        private UIPanel panel;
        private UIText text;
        private UIPanel togglePanel;
        private UIText toggleText;
        private bool someSetting = false;
        private UIPanel closeButtonPanel;
        private UIText closeButtonText;

        public override void OnInitialize()
        {
            panel = new UIPanel();
            panel.Width.Set(300f, 0f);
            panel.Height.Set(150f, 0f);
            panel.Left.Set(400f, 0f);
            panel.Top.Set(200f, 0f);
            panel.BackgroundColor = new Color(73, 94, 171);

            text = new UIText("Config TEST", 0.8f);
            text.Left.Set(10f, 0f);
            text.Top.Set(10f, 0f);
            panel.Append(text);

            // สร้าง panel ปุ่ม toggle
            togglePanel = new UIPanel();
            togglePanel.Width.Set(200f, 0f);
            togglePanel.Height.Set(40f, 0f);
            togglePanel.Top.Set(50f, 0f);
            togglePanel.Left.Set(50f, 0f);
            togglePanel.BackgroundColor = new Color(100, 100, 200);

            toggleText = new UIText("Open: Close", 0.7f);
            toggleText.HAlign = 0.5f;
            toggleText.VAlign = 0.5f;
            togglePanel.Append(toggleText);

            // กำหนดการคลิก
            togglePanel.OnLeftClick += ToggleSetting;

            panel.Append(togglePanel);

            // สร้างปุ่มปิด
            closeButtonPanel = new UIPanel();
            closeButtonPanel.Width.Set(100f, 0f);
            closeButtonPanel.Height.Set(50f, 0f);
            closeButtonPanel.Top.Set(100f, 0f);
            closeButtonPanel.Left.Set(100f, 0f);
            closeButtonPanel.BackgroundColor = new Color(200, 50, 50);

            closeButtonText = new UIText("Close", 0.7f);
            closeButtonText.HAlign = 0.5f;
            closeButtonText.VAlign = 0.5f;
            closeButtonPanel.Append(closeButtonText);

            // เมื่อคลิกปุ่มปิด
            closeButtonPanel.OnLeftClick += CloseUI;

            panel.Append(closeButtonPanel);

            Append(panel);
        }

        private void ToggleSetting(UIMouseEvent evt, UIElement listeningElement)
        {
            someSetting = !someSetting;
            toggleText.SetText("Test: " + (someSetting ? "Open" : "Close"));
            // เพิ่ม logic เก็บค่าตั้งค่าไว้ในระบบอื่นๆ ได้ที่นี่
        }

        private void CloseUI(UIMouseEvent evt, UIElement listeningElement)
        {
            Console.WriteLine("Close button clicked!");

        }
    }
}
