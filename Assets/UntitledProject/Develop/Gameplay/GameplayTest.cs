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

			Debug.Log($"Ghost's speed: {_ghost.GetMoveSpeed().Value}");
		}

		private void Update()
		{
			Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

			if (_ghost != null)
			{
				_ghost.GetMoveDirection().Value = input;
				_ghost.GetRotationDirection().Value = input;

				if (Input.GetKeyDown(KeyCode.F) && _ghost.TryGetHealth(out ReactiveVariable<float> health))
				{
					health.Value -= 100;
					Debug.Log($"Health: {health.Value}");
				}
			}
		}
	}
}
