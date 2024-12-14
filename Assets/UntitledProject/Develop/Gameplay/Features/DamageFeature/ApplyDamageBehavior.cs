using Assets.UntitledProject.Develop.Gameplay.Entities;
using Assets.UntitledProject.Develop.Gameplay.Entities.Behaviors;
using Assets.UntitledProject.Develop.Utils.Reactive;
using System;

namespace Assets.UntitledProject.Develop.Gameplay.Features.DamageFeature
{
	public sealed class ApplyDamageBehavior : IEntityInitialize, IEntityDispose
	{
		private ReactiveEvent<float> _takeDamageEvent;
		private ReactiveVariable<float> _health;

		private IDisposable _disposableTakeDamage;

		public void OnInitialize(Entity entity)
		{
			_takeDamageEvent = entity.GetTakeDamageEvent();
			_health = entity.GetHealth();

			_takeDamageEvent.Subscribe(OnTakeDamage);
		}

		private void OnTakeDamage(float damageAmount)
		{
			if (damageAmount < 0)
				throw new ArgumentOutOfRangeException($"Non-negative damage amount expected. Got {damageAmount}");

			float tempHealth = _health.Value - damageAmount;
			_health.Value = Math.Max(tempHealth, 0);
		}

		public void OnDispose()
		{
			_disposableTakeDamage?.Dispose();
		}
	}
}
