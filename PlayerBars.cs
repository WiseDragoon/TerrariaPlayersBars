using ReLogic.Content.Sources;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace PlayerBars {
	public class PlayerBars : Mod {

		public static PlayerBars Instance {  get; set; }
		public PlayerBars() => Instance = this;

        public override IContentSource CreateDefaultContentSource() {
			return base.CreateDefaultContentSource();
		}
    }
}