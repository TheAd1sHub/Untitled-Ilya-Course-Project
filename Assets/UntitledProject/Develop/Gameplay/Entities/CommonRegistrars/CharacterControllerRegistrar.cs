using UnityEngine;

namespace Assets.UntitledProject.Develop.Gameplay.Entities.CommonRegistrars
{
	public sealed class CharacterControllerRegistrar : MonoEntityRegistrar
	{
		[SerializeField] private CharacterController _characterController;

		public override void Register(Entity entity)
		{
			entity.AddValue(EntityValue.CharacterController, _characterController);
		}
	}
}
