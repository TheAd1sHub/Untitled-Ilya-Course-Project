using Assets.UntitledProject.Develop.Gameplay.Entities;
using Assets.UntitledProject.Develop.Gameplay.Entities.Behaviors;
using Assets.UntitledProject.Develop.Utils.Conditions;
using Assets.UntitledProject.Develop.Utils.Reactive;
using UnityEngine;

namespace Assets.UntitledProject.Develop.Gameplay.Features.DeathFeature
{
	public class DeathBehavior : IEntityInitialize, IEntityUpdate
	{
		private ReactiveVariable<bool> _isDead;
		private ICondition _condition;

		public void OnInitialize(Entity entity)
		{
			_isDead = entity.GetIsDead();
			_condition = entity.GetDeathCondition();
		}

		public void OnUpdate(float deltaTime)
		{
			if (_isDead.Value)
				return;

			if (_condition.Evaluate())
			{
				_isDead.Value = true;
				Debug.Log("The entity is dead");
			}
		}
	}
} 