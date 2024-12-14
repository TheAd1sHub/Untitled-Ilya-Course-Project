using Assets.UntitledProject.Develop.Gameplay.Entities;
using Assets.UntitledProject.Develop.Gameplay.Entities.Behaviors;
using Assets.UntitledProject.Develop.Utils.Conditions;
using Assets.UntitledProject.Develop.Utils.Reactive;
using UnityEngine;

namespace Assets.UntitledProject.Develop.Gameplay.Features.MovementFeature
{
	public sealed class CharacterControllerMovementBehavior : IEntityInitialize, IEntityUpdate
	{
		private CharacterController _characterController;

		private IReadOnlyVariable<float> _speed;
		private IReadOnlyVariable<Vector3> _direction;

		private ICondition _condition;

		public void OnInitialize(Entity entity)
		{
			_speed = entity.GetMoveSpeed();
			_direction = entity.GetMoveDirection();
			_characterController = entity.GetCharacterController();
			_condition = entity.GetMoveCondition();
		}

		public void OnUpdate(float deltaTime)
		{
			if (_condition.Evaluate() == false)
				return;

			Vector3 velocity = _direction.Value.normalized * _speed.Value;

			_characterController.Move(velocity * deltaTime);
		}
	}
}
