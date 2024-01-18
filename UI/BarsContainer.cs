using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.UI;

namespace PlayerBars.UI {
    internal class BarsContainer : UIState {
        public HealthBar HealthBar;
        public ManaBar ManaBar;

        public static float Scale { set; get; } = 1.2f;
        public static int Offset { set; get; } = 28;
        public static bool AutoHideOnFull { get; set; } = false;
        public static bool ShowHealthBar { get; set; } = true;
        public static bool ShowManaBar { get; set; } = true;

        public override void OnInitialize() {
            HealthBar = new HealthBar();
            ManaBar = new ManaBar();

            Append(HealthBar);
            Append(ManaBar);
        }
    }
}
