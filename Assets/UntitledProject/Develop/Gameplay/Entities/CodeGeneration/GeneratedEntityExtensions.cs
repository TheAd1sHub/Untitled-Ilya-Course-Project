public static class EntityExtensionsGenerated
{
	public static Assets.UntitledProject.Develop.Gameplay.Entities.Entity AddMoveSpeed(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity) => entity.AddValue(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.MoveSpeed, new Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<System.Single>());
	public static Assets.UntitledProject.Develop.Gameplay.Entities.Entity AddMoveSpeed(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity, Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<System.Single> value) => entity.AddValue(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.MoveSpeed, value);
	public static Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<System.Single> GetMoveSpeed(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity) => entity.GetValue<Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<System.Single>>(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.MoveSpeed);
	public static System.Boolean TryGetMoveSpeed(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity, out Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<System.Single> value) => entity.TryGetValue<Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<System.Single>>(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.MoveSpeed, out value);
	public static Assets.UntitledProject.Develop.Gameplay.Entities.Entity AddMoveDirection(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity) => entity.AddValue(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.MoveDirection, new Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3>());
	public static Assets.UntitledProject.Develop.Gameplay.Entities.Entity AddMoveDirection(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity, Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3> value) => entity.AddValue(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.MoveDirection, value);
	public static Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3> GetMoveDirection(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity) => entity.GetValue<Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3>>(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.MoveDirection);
	public static System.Boolean TryGetMoveDirection(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity, out Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3> value) => entity.TryGetValue<Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3>>(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.MoveDirection, out value);
	public static Assets.UntitledProject.Develop.Gameplay.Entities.Entity AddRotationSpeed(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity) => entity.AddValue(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.RotationSpeed, new Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<System.Single>());
	public static Assets.UntitledProject.Develop.Gameplay.Entities.Entity AddRotationSpeed(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity, Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<System.Single> value) => entity.AddValue(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.RotationSpeed, value);
	public static Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<System.Single> GetRotationSpeed(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity) => entity.GetValue<Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<System.Single>>(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.RotationSpeed);
	public static System.Boolean TryGetRotationSpeed(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity, out Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<System.Single> value) => entity.TryGetValue<Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<System.Single>>(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.RotationSpeed, out value);
	public static Assets.UntitledProject.Develop.Gameplay.Entities.Entity AddRotationDirection(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity) => entity.AddValue(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.RotationDirection, new Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3>());
	public static Assets.UntitledProject.Develop.Gameplay.Entities.Entity AddRotationDirection(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity, Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3> value) => entity.AddValue(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.RotationDirection, value);
	public static Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3> GetRotationDirection(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity) => entity.GetValue<Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3>>(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.RotationDirection);
	public static System.Boolean TryGetRotationDirection(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity, out Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3> value) => entity.TryGetValue<Assets.UntitledProject.Develop.Utils.Reactive.ReactiveVariable<UnityEngine.Vector3>>(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.RotationDirection, out value);
	public static Assets.UntitledProject.Develop.Gameplay.Entities.Entity AddTransform(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity, UnityEngine.Transform value) => entity.AddValue(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.Transform, value);
	public static UnityEngine.Transform GetTransform(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity) => entity.GetValue<UnityEngine.Transform>(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.Transform);
	public static System.Boolean TryGetTransform(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity, out UnityEngine.Transform value) => entity.TryGetValue<UnityEngine.Transform>(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.Transform, out value);
	public static Assets.UntitledProject.Develop.Gameplay.Entities.Entity AddCharacterController(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity, UnityEngine.CharacterController value) => entity.AddValue(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.CharacterController, value);
	public static UnityEngine.CharacterController GetCharacterController(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity) => entity.GetValue<UnityEngine.CharacterController>(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.CharacterController);
	public static System.Boolean TryGetCharacterController(this Assets.UntitledProject.Develop.Gameplay.Entities.Entity entity, out UnityEngine.CharacterController value) => entity.TryGetValue<UnityEngine.CharacterController>(Assets.UntitledProject.Develop.Gameplay.Entities.EntityValue.CharacterController, out value);
}
