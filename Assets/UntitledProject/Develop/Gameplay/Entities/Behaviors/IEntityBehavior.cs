namespace Assets.UntitledProject.Develop.Gameplay.Entities.Behaviors
{
	public interface IEntityBehavior
	{

	}

	public interface IEntityUpdate : IEntityBehavior
	{
		public void OnUpdate(float deltaTime);
	}

	public interface IEntityInitialize : IEntityBehavior
	{
		public void OnInitialize(Entity entity);
	}

	public interface IEntityDispose : IEntityBehavior
	{
		public void OnDispose();
	}
}
