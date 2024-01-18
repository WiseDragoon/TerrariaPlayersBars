using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.UI;

namespace PlayerBars.UI {
    internal class ManaBar : UIElement {
        private Texture2D hbTexture1 = Terraria.GameContent.TextureAssets.Hb1.Value;
        private Texture2D hbTexture2 = Terraria.GameContent.TextureAssets.Hb2.Value;

        public override void Draw(SpriteBatch spriteBatch) {
            if (!BarsContainer.ShowManaBar)
                return;

            Player player = Main.LocalPlayer;

            if (player.statLife <= 0)
                return;

            float manaPercentage = (float)player.statMana / (float)player.statManaMax2;
            manaPercentage = Utils.Clamp(manaPercentage, 0f, 1f);

            if (BarsContainer.AutoHideOnFull && manaPercentage >= 1f)
                return;

            float zoom = Main.GameZoomTarget;

            Vector2 playerPos = player.Center.ToScreenPosition();

            float xPos = playerPos.X - (hbTexture1.Width / 2f * BarsContainer.Scale);
            float yPos = playerPos.Y;

            if (player.gravDir == -1f) {
                yPos -= BarsContainer.Offset * zoom - 1f - hbTexture1.Height * BarsContainer.Scale;
            } else {
                yPos += BarsContainer.Offset * zoom + 1f + hbTexture1.Height * BarsContainer.Scale;
            }

            Color color = new Color(100, 130, 210, 200);

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
                new Rectangle?(new Rectangle(0, 0, (int)(hbTexture1.Width * manaPercentage), hbTexture1.Height)),
                color,
                0f,
                new Vector2(0f, 0f),
                BarsContainer.Scale,
                SpriteEffects.None,
                0f);
        }

    }
}
