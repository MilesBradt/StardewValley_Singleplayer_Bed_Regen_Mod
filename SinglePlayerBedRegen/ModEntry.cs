using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SinglePlayerBedRegen {
    public class ModEntry : Mod {
        public override void Entry(IModHelper helper) {
            helper.Events.GameLoop.UpdateTicked += this.UpdateTicked;
        }

        private void UpdateTicked(object sender, UpdateTickedEventArgs e) {
            if (!Context.IsPlayerFree || Game1.paused || Game1.IsMultiplayer)
                return;

           
            if (e.IsMultipleOf(30)) {

                if (Game1.player.isInBed)
                {
                    //Health
                    if (Game1.player.health < Game1.player.maxHealth)
                        Game1.player.health = Math.Min(Game1.player.maxHealth, Game1.player.health + 1);
                    //Stamina
                    if (Game1.player.Stamina < Game1.player.MaxStamina)
                        Game1.player.Stamina = Math.Min(Game1.player.MaxStamina, Game1.player.Stamina + 1);
                }
            } 
        }
    }
}
