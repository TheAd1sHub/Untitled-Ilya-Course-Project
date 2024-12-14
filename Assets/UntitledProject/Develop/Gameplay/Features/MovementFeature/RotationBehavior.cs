using Assets.UntitledProject.Develop.Gameplay.Entities;
using Assets.UntitledProject.Develop.Gameplay.Entities.Behaviors;
using Assets.UntitledProject.Develop.Utils.Conditions;
using Assets.UntitledProject.Develop.Utils.Reactive;
using UnityEngine;

namespace Assets.UntitledProject.Develop.Gameplay.Features.MovementFeature
{
	public sealed class RotationBehavior : IEntityInitialize, IEntityUpdate
	{
		private Transform _transform;

		private IReadOnlyVariable<float> _speed;
		private IReadOnlyVariable<Vector3> _direction;

		private ICondition _condition;

		public void OnInitialize(Entity entity)
		{
			_speed = entity.GetRotationSpeed();
			_direction = entity.GetRotationDirection();
			_transform = entity.GetTransform();
			_condition = entity.GetRotationCondition();
		}

		public void OnUpdate(float deltaTime)
		{
			if (_condition.Evaluate() == false)
				return;

			if (_direction.Value == Vector3.zero)
				return;

			Quaternion lookRotation = Quaternion.LookRotation(_direction.Value.normalized);
			float step = _speed.Value * deltaTime;

			_transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);
		}
	}
}
