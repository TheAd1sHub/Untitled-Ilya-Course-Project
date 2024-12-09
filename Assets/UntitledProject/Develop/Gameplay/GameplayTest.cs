using Assets.UntitledProject.Develop.DI;
using Assets.UntitledProject.Develop.Gameplay.Entities;
using Assets.UntitledProject.Develop.Utils.Reactive;
using UnityEngine;

namespace Assets.UntitledProject.Develop.Gameplay
{
	public class GameplayTest : MonoBehaviour
	{
		private DIContainer _container;

		private Entity _ghost;

		public void StartProcess(DIContainer container)
		{
			_container = container;

			_ghost = _container.Resolve<EntityFactory>().CreateGhost(Vector3.zero);

			_ghost.TryGetValue(EntityValue.MoveSpeed, out ReactiveVariable<float> moveSpeed);
			Debug.Log($"Ghost' speed: {moveSpeed.Value}");
		}

		private void Update()
		{
			Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

			if (_ghost != null)
			{
				_ghost.TryGetValue(EntityValue.MoveDirection, out ReactiveVariable<Vector3> moveDirection);
				_ghost.TryGetValue(EntityValue.RotationDirection, out ReactiveVariable<Vector3> rotationDirection);

				moveDirection.Value = input;
				rotationDirection.Value = input;
			}
		}
	}
}
