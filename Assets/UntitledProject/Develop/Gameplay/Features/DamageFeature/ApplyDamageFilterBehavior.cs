using Assets.UntitledProject.Develop.Gameplay.Entities;
using Assets.UntitledProject.Develop.Gameplay.Entities.Behaviors;
using Assets.UntitledProject.Develop.Utils.Conditions;
using Assets.UntitledProject.Develop.Utils.Reactive;
using System;

namespace Assets.UntitledProject.Develop.Gameplay.Features.DamageFeature
{
	public sealed class ApplyDamageFilterBehavior : IEntityInitialize, IEntityDispose
	{
		private ReactiveEvent<float> _takeDamageEvent;
		private ReactiveEvent<float> _takeDamageRequest;
		private ICondition _takeDamageCondition;

		private IDisposable _disposableTakeDamageRequest;

		public void OnInitialize(Entity entity)
		{
			_takeDamageEvent = entity.GetTakeDamageEvent();
			_takeDamageRequest = entity.GetTakeDamageRequest();
			_takeDamageCondition = entity.GetTakeDamageCondition();

			_disposableTakeDamageRequest = _takeDamageRequest.Subscribe(OnTakeDamageRequest);
		}

		private void OnTakeDamageRequest(float damageAmount)
		{
			if (damageAmount < 0)
				throw new ArgumentOutOfRangeException($"Non-negative damage amount expected. Got {damageAmount}");

			if (_takeDamageCondition.Evaluate())
				_takeDamageEvent?.Invoke(damageAmount);
		}

		public void OnDispose() => _disposableTakeDamageRequest?.Dispose();
	}
}
