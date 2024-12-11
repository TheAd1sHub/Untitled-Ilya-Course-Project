﻿using Assets.UntitledProject.Develop.Gameplay.Entities;
using Assets.UntitledProject.Develop.Gameplay.Entities.Behaviors;
using Assets.UntitledProject.Develop.Utils.Reactive;
using UnityEngine;

namespace Assets.UntitledProject.Develop.Gameplay.Features.MovementFeature
{
	public sealed class CharacterControllerMovementBehavior : IEntityInitialize, IEntityUpdate
	{
		private CharacterController _characterController;

		private IReadOnlyVariable<float> _speed;
		private IReadOnlyVariable<Vector3> _direction;

		public void OnInitialize(Entity entity)
		{
			_speed = entity.GetValue<ReactiveVariable<float>>(EntityValue.MoveSpeed);
			_direction = entity.GetValue<ReactiveVariable<Vector3>>(EntityValue.MoveDirection);
			_characterController = entity.GetValue<CharacterController>(EntityValue.CharacterController);
		}

		public void OnUpdate(float deltaTime)
		{
			Vector3 velocity = _direction.Value.normalized * _speed.Value;

			_characterController.Move(velocity * deltaTime);
		}
	}
}