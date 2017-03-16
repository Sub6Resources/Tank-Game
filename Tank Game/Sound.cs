using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tank_Game
{
    class Sound
    {
        private SoundEffect derpSound;
        private SoundEffect derp2Sound;
        private SoundEffect derpDeathSound;
        private SoundEffect derpHurtSound;
        private SoundEffect kamiAngerSound;
        private SoundEffect kamiChargeSound;
        private SoundEffect kamiDeathSound;
        private SoundEffect kamiHurtSound;
        private SoundEffect laserShootSound;
        public enum Sounds { DERP, DERP2, DERPDEATH, DERPHURT, KAMIANGER, KAMICHARGE, KAMIDEATH, KAMIHURT, LASERSHOOT }
        public Sound(Game1 game) {
            derpSound = game.Content.Load<SoundEffect>("Derp");
            derp2Sound = game.Content.Load<SoundEffect>("Derp2");
            derpDeathSound = game.Content.Load<SoundEffect>("derpDeath");
            derpHurtSound = game.Content.Load<SoundEffect>("DerpHurt");
            kamiAngerSound = game.Content.Load<SoundEffect>("KamiAnger");
            kamiChargeSound = game.Content.Load<SoundEffect>("KamiCharge");
            kamiDeathSound = game.Content.Load<SoundEffect>("KamiDeath");
            kamiHurtSound = game.Content.Load<SoundEffect>("KamiHurt");
            laserShootSound = game.Content.Load<SoundEffect>("KamiHurt");
        }
        public void PlaySound(Sounds sound)
        {
            switch(sound)
            {
                case Sounds.DERP:
                    break;
                case Sounds.DERP2:
                    break;
                case Sounds.DERPDEATH:
                    break;
                case Sounds.DERPHURT:
                    break;
                case Sounds.KAMIANGER:
                    break;
                case Sounds.KAMICHARGE:
                    break;
                case Sounds.KAMIDEATH:
                    break;
                case Sounds.KAMIHURT:
                    break;
                case Sounds.LASERSHOOT:
                    break;
            }
        }

    }
}
