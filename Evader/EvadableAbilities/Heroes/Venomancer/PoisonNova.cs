﻿namespace Evader.EvadableAbilities.Heroes.Venomancer
{
    using System.Linq;

    using Base;
    using Base.Interfaces;

    using Ensage;
    using Ensage.Common.Extensions;

    using static Data.AbilityNames;

    internal sealed class PoisonNova : AOE, IParticle
    {
        #region Fields

        private readonly float projectileSize;

        private readonly float speed;

        private readonly float tavelTime;

        #endregion

        #region Constructors and Destructors

        public PoisonNova(Ability ability)
            : base(ability)
        {
            speed = ability.GetProjectileSpeed();
            tavelTime = GetRadius() / speed;
            projectileSize = Ability.AbilitySpecialData.First(x => x.Name == "start_radius").Value + 60;

            BlinkAbilities.AddRange(BlinkAbilityNames);

            CounterAbilities.Add(PhaseShift);
            CounterAbilities.Add(BallLightning);
            CounterAbilities.Add(Eul);
            CounterAbilities.AddRange(VsDamage);
            CounterAbilities.AddRange(VsMagic);
            CounterAbilities.Add(SnowBall);
        }

        #endregion

        #region Public Methods and Operators

        public void AddParticle(ParticleEffect particle)
        {
            if (Obstacle != null || !AbilityOwner.IsVisible)
            {
                return;
            }

            StartCast = Game.RawGameTime;
            StartPosition = AbilityOwner.NetworkPosition;
            EndCast = StartCast + tavelTime;
            Obstacle = Pathfinder.AddObstacle(StartPosition, GetRadius(), Obstacle);
        }

        public override bool CanBeStopped()
        {
            return false;
        }

        public override void Check()
        {
            if (StartCast > 0 && Game.RawGameTime > EndCast)
            {
                End();
            }
        }

        public override float GetRemainingTime(Hero hero = null)
        {
            if (hero == null)
            {
                hero = Hero;
            }

            if (hero.NetworkPosition.Distance2D(StartPosition) < projectileSize)
            {
                return 0;
            }

            return StartCast + (hero.NetworkPosition.Distance2D(StartPosition) - projectileSize) / speed
                   - Game.RawGameTime;
        }

        #endregion
    }
}