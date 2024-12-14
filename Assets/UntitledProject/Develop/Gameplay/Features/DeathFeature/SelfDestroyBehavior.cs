using Assets.UntitledProject.Develop.Gameplay.Entities;
using Assets.UntitledProject.Develop.Gameplay.Entities.Behaviors;
using Assets.UntitledProject.Develop.Utils.Conditions;
using UnityEngine;

namespace Assets.UntitledProject.Develop.Gameplay.Features.DeathFeature
{
	public sealed class SelfDestroyBehavior : IEntityInitialize, IEntityUpdate
	{
		private ICondition _selfDestroyCondition;
		private Transform _entityTransform;

		public void OnInitialize(Entity entity)
		{
			_entityTransform = entity.GetTransform();
			_selfDestroyCondition = entity.GetSelfDestroyCondition();
		}

		public void OnUpdate(float deltaTime)
		{
			if (_selfDestroyCondition.Evaluate())
				Object.Destroy((_entityTransform.gameObject));
		}
	}
}
