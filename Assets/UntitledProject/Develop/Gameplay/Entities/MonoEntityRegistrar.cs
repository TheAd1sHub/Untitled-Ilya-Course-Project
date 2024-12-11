using UnityEngine;

namespace Assets.UntitledProject.Develop.Gameplay.Entities
{
	public abstract class MonoEntityRegistrar : MonoBehaviour
	{
		public abstract void Register(Entity entity);
	}
}
