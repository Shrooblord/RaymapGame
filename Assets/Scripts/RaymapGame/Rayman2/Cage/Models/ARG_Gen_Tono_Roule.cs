//================================
//  By: Adsolution
//================================

namespace RaymapGame.Rayman2.Persos {
    /// <summary>
    /// Rolling Barrel Dispenser
    /// </summary>
    public partial class ARG_Gen_Tono_Roule : Cage {
        public override float activeRadius => 40;
        public float spawnDelay = 10;
        public float tonMoveSpeed = 1;

        public void DumpBarrel() {
            var ton = Clone<ARG_Tonneau_DonkeyKong>(pos + forward - upward);
            ton.moveSpeed = tonMoveSpeed;
            ton.SetRule("Rolling");

            anim.Set(0);
            anim.Set(Anim.BarrelDispenserFlap);
            Timers("FlapStop").Start(2, () => anim.Set(Anim.BarrelDispenserIdle));
        }

        protected override void OnStart() {
            spawnDelay = (float)GetDsgVar<int>("Int_0") / 1000;
            tonMoveSpeed = GetDsgVar<float>("Float_2");
            SetRule("DumpingBarrels");
        }

        protected void Rule_DumpingBarrels() {
            Timers("Sponneau").Start(spawnDelay, DumpBarrel, false);
        }
    }
}