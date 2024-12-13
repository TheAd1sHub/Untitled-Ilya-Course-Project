using Assets.UntitledProject.Develop.Gameplay.Entities;
using Assets.UntitledProject.Develop.Gameplay.Entities.Behaviors;
using Assets.UntitledProject.Develop.Utils.Reactive;
using UnityEngine;

namespace Assets.UntitledProject.Develop.Gameplay.Features.DeathFeature
{
	public class DeathBehavior : IEntityInitialize, IEntityUpdate
	{
		private ReactiveVariable<float> _health;
		private ReactiveVariable<bool> _isDead;

		public void OnInitialize(Entity entity)
		{
			_health = entity.GetHealth();
			_isDead = entity.GetIsDead();
		}

		public void OnUpdate(float deltaTime)
		{
			if (_isDead.Value)
				return;

			if (_health.Value <= 0)
			{
				_isDead.Value = true;
				Debug.Log("The entity is dead");
			}
		}
	}
}
