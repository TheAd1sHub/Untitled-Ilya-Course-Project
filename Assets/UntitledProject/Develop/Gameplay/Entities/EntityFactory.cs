using Assets.UntitledProject.Develop.CommonServices.AssetsManagement;
using Assets.UntitledProject.Develop.DI;
using Assets.UntitledProject.Develop.Gameplay.Features.DamageFeature;
using Assets.UntitledProject.Develop.Gameplay.Features.DeathFeature;
using Assets.UntitledProject.Develop.Gameplay.Features.MovementFeature;
using Assets.UntitledProject.Develop.Utils.Conditions;
using Assets.UntitledProject.Develop.Utils.Extensions;
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
				.AddMoveDirection()
				.AddMoveSpeed(new ReactiveVariable<float>(10))
				.AddRotationDirection()
				.AddRotationSpeed(new ReactiveVariable<float>(900))
				.AddHealth(new ReactiveVariable<float>(400))
				.AddMaxHealth(new ReactiveVariable<float>(400))
				.AddIsDead()
				.AddTakeDamageRequest()
				.AddTakeDamageEvent();

			instance
				.AddBehavior(new CharacterControllerMovementBehavior())
				.AddBehavior(new RotationBehavior())
				.AddBehavior(new ApplyDamageBehavior())
				.AddBehavior(new ApplyDamageFilterBehavior())
				.AddBehavior(new DeathBehavior())
				.AddBehavior(new SelfDestroyBehavior());

			ICompositeCondition moveCondition = new CompositeCondition(defaultPredicate: LogicOperations.And)
				.Add(new FuncCondition(() => instance.GetIsDead().Value == false));

			ICompositeCondition rotationCondition = new CompositeCondition(defaultPredicate: LogicOperations.And)
				.Add(new FuncCondition(() => instance.GetIsDead().Value == false));

			ICompositeCondition deathCondition = new CompositeCondition(defaultPredicate: LogicOperations.And)
				.Add(new FuncCondition(() => instance.GetHealth().Value <= 0));

			ICompositeCondition takeDamageCondition = new CompositeCondition(defaultPredicate: LogicOperations.And)
				.Add(new FuncCondition(() => instance.GetIsDead().Value == false));

			ICompositeCondition selfDestroyCondition = new CompositeCondition(defaultPredicate: LogicOperations.And)
				.Add(new FuncCondition(() => instance.GetIsDead().Value));

			instance
				.AddMoveCondition(moveCondition)
				.AddRotationCondition(rotationCondition)
				.AddDeathCondition(deathCondition)
				.AddTakeDamageCondition(takeDamageCondition)
				.AddSelfDestroyCondition(selfDestroyCondition);

			instance.Initialize();

			return instance;
		}
	}
}
