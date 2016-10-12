﻿namespace Evader.EvadableAbilities.Heroes
{
    using Ensage;

    using static Core.Abilities;

    using LinearProjectile = Base.LinearProjectile;

    internal class WildAxes : LinearProjectile
    {
        #region Fields

        private readonly float speed;

        #endregion

        #region Constructors and Destructors

        public WildAxes(Ability ability)
            : base(ability)
        {
            CounterAbilities.Add(PhaseShift);
            CounterAbilities.Add(Eul);
            CounterAbilities.AddRange(VsDamage);
            CounterAbilities.AddRange(VsPhys);

            speed = 800;
        }

        #endregion

        #region Public Methods and Operators

        public override float GetProjectileSpeed()
        {
            return speed;
        }

        #endregion

        #region Methods

        protected override float GetCastRange()
        {
            return base.GetCastRange() - 150;
        }

        #endregion
    }
}