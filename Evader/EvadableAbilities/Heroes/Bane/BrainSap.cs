﻿namespace Evader.EvadableAbilities.Heroes.Bane
{
    using Base;

    using Ensage;

    using static Data.AbilityNames;

    internal class BrainSap : LinearTarget
    {
        #region Constructors and Destructors

        public BrainSap(Ability ability)
            : base(ability)
        {
            CounterAbilities.Add(PhaseShift);
            CounterAbilities.Add(Manta);
            CounterAbilities.AddRange(VsDamage);
            CounterAbilities.AddRange(VsLowPureMagic);
            CounterAbilities.AddRange(Invul);
            CounterAbilities.Add(SnowBall);
            CounterAbilities.Add(Armlet);
            CounterAbilities.Add(Bloodstone);
            CounterAbilities.Add(Lotus);
            CounterAbilities.Add(NetherWard);
        }

        #endregion
    }
}