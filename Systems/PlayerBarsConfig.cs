using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader.Config;

namespace PlayerBars.Systems {
    internal class PlayerBarsConfig : ModConfig {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(true)]
        public bool ShowHealthBar;

        [DefaultValue(true)]
        public bool ShowManaBar;

        [DefaultValue(false)]
        public bool AutoHideWhenFull;

        [Increment(0.1f)]
        [Range(0.5f, 3f)]
        [DefaultValue(1.2f)]
        [Slider]
        public float Scale;

        [Increment(1)]
        [Range(0, 150)]
        [DefaultValue(28)]
        [Slider]
        public int Offset;

        public override void OnChanged() {
            UI.BarsContainer.Scale = Scale;
            UI.BarsContainer.Offset = Offset;
            UI.BarsContainer.AutoHideOnFull = AutoHideWhenFull;
            UI.BarsContainer.ShowHealthBar = ShowHealthBar;
            UI.BarsContainer.ShowManaBar = ShowManaBar;
        }
    }
}
