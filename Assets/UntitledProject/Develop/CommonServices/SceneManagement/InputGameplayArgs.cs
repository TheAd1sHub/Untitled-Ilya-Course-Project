namespace Assets.UntitledProject.Develop.CommonServices.SceneManagement
{
	public sealed class InputGameplayArgs : IInputSceneArgs
	{
		public int LevelNumber { get; }

        public InputGameplayArgs(int levelNumber)
        {
            LevelNumber = levelNumber;
        }
    }
}
