using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Tank_Game
{
    public class Sound
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
            derpDeathSound = game.Content.Load<SoundEffect>("eenewDerpDeath");
            derpHurtSound = game.Content.Load<SoundEffect>("DerpHurt");
            kamiAngerSound = game.Content.Load<SoundEffect>("KamiAnger");
            kamiChargeSound = game.Content.Load<SoundEffect>("KamiCharge");
            kamiDeathSound = game.Content.Load<SoundEffect>("eenewKamiDeath");
            kamiHurtSound = game.Content.Load<SoundEffect>("KamiHurt");
            laserShootSound = game.Content.Load<SoundEffect>("Laser_Shoot");
        }
        public void PlaySound(Sounds sound)
        {
            switch(sound)
            {
                case Sounds.DERP:
                    derpSound.Play();
                    break;
                case Sounds.DERP2:
                    derp2Sound.Play();
                    break;
                case Sounds.DERPDEATH:
                    derpDeathSound.Play();
                    break;
                case Sounds.DERPHURT:
                    derpHurtSound.Play();
                    break;
                case Sounds.KAMIANGER:
                    kamiAngerSound.Play();
                    break;
                case Sounds.KAMICHARGE:
                    kamiChargeSound.Play();
                    break;
                case Sounds.KAMIDEATH:
                    kamiDeathSound.Play();
                    break;
                case Sounds.KAMIHURT:
                    kamiHurtSound.Play();
                    break;
                case Sounds.LASERSHOOT:
                    laserShootSound.Play();
                    break;
            }
        }

    }
}
