using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria.GameContent;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics.PackedVector;

namespace PlayerBars.UI {
    internal class HealthBar : UIElement {
        private Texture2D hbTexture1 = Terraria.GameContent.TextureAssets.Hb1.Value;
        private Texture2D hbTexture2 = Terraria.GameContent.TextureAssets.Hb2.Value;

        public override void Draw(SpriteBatch spriteBatch) {
            if (!BarsContainer.ShowHealthBar) 
                return;

            Player player = Main.LocalPlayer;
            
            if (player.statLife <= 0)
                return;

            float healthPercentage = (float)player.statLife / (float)player.statLifeMax2;
            healthPercentage = Utils.Clamp(healthPercentage, 0f, 1f);

            if (BarsContainer.AutoHideOnFull && healthPercentage >= 1f)
                return;

            float zoom = Main.GameZoomTarget;

            Vector2 playerPos = player.Center.ToScreenPosition();

            float xPos = playerPos.X - (hbTexture1.Width / 2f * BarsContainer.Scale);
            float yPos = playerPos.Y;

            if (player.gravDir == -1f) {
                yPos -= BarsContainer.Offset * zoom;
            } else {
                yPos += BarsContainer.Offset * zoom;
            }

            float R = 255f;
            float G = 255f;
            if (healthPercentage > 0.9f) {
                R = 10f;
                G = 245f;
            } else if (healthPercentage > 0.5f) {
                R = 200f;
                G = 200f;
            } else if (healthPercentage > 0.15f) {
                R = 200f;
                G = 100f;
            } else {
                R = 245f;
                G = 10f;
            }
            float B = 0;
            float A = 200f;

            Color color = new Color((int)R, (int)G, (int)B, (int)A);

            // The small bar that doesn't decrease
            Main.spriteBatch.Draw(
                hbTexture2,
                new Vector2(xPos, yPos),
                new Rectangle?(new Rectangle(0, 0, hbTexture2.Width, hbTexture2.Height)),
                color,
                0f,
                new Vector2(0f, 0f),
                BarsContainer.Scale,
                SpriteEffects.None,
                0f);
            // The big bar that decreases with hp
            Main.spriteBatch.Draw(
                hbTexture1,
                new Vector2(xPos, yPos),
                new Rectangle?(new Rectangle(0, 0, (int)(hbTexture1.Width * healthPercentage), hbTexture1.Height)),
                color,
                0f,
                new Vector2(0f, 0f),
                BarsContainer.Scale,
                SpriteEffects.None,
                0f);

        }
    }

}

