namespace Assets.UntitledProject.Develop.CommonServices.SceneManagement
{
	public abstract class OutputSceneArgs : IOutputSceneArgs
	{
		protected OutputSceneArgs(IInputSceneArgs nextSceneInputArgs)
		{
			NextSceneInputArgs = nextSceneInputArgs;
		}

		public IInputSceneArgs NextSceneInputArgs { get; }
	}
}
