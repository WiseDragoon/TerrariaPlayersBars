using Microsoft.Xna.Framework;
using PlayerBars.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace PlayerBars.Systems {
    [Autoload(Side = ModSide.Client)]
    internal class PlayerBarsUI : ModSystem {
        internal BarsContainer BarsContainer;
        private UserInterface _BarsContainerUserInterface;

        public override void Load() {
            BarsContainer = new BarsContainer();
            BarsContainer.Activate();
            _BarsContainerUserInterface = new UserInterface();
            _BarsContainerUserInterface.SetState(BarsContainer);
        }

        public override void UpdateUI(GameTime gameTime) {
            _BarsContainerUserInterface?.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers) {
            int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Interface Logic 2"));
            int MouseIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Cursor"));

            layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
                "Player Bars: Bars Container",
                delegate {
                    _BarsContainerUserInterface.Draw(Main.spriteBatch, new GameTime());
                    return true;
                },
                InterfaceScaleType.UI)
            );
        }
    }
}
