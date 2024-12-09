using Assets.UntitledProject.Develop.CommonServices.AssetsManagement;
using Assets.UntitledProject.Develop.DI;
using Assets.UntitledProject.Develop.Gameplay.Features.MovementFeature;
using Assets.UntitledProject.Develop.Utils.Reactive;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.UntitledProject.Develop.Gameplay.Entities
{
	public class EntityFactory
	{
		private DIContainer _container;
		private ResourcesAssetLoader _assetLoader;

		public EntityFactory(DIContainer container)
		{
			_container = container;
			_assetLoader = container.Resolve<ResourcesAssetLoader>();
		}

		public Entity CreateGhost(Vector3 position)
		{
			Entity prefab = _assetLoader.LoadResource<Entity>(EntitiesAssetsPaths.GhostPrefabPath);
			Entity instance = Object.Instantiate(prefab, position, Quaternion.identity);

			instance
				.AddValue(EntityValue.MoveDirection, new ReactiveVariable<Vector3>())
				.AddValue(EntityValue.MoveSpeed, new ReactiveVariable<float>(10))
				.AddValue(EntityValue.RotationDirection, new ReactiveVariable<Vector3>())
				.AddValue(EntityValue.RotationSpeed, new ReactiveVariable<float>(900))
				.AddValue(EntityValue.Transform, instance.transform) // TODO: Get transform in a more sane way
				.AddValue(EntityValue.CharacterController, instance.GetComponent<CharacterController>());

			instance
				.AddBehavior(new CharacterControllerMovementBehavior())
				.AddBehavior(new RotationBehavior());

			instance.Initialize();

			return instance;
		}
	}
}
