namespace Assets.UntitledProject.Develop.CommonServices.SceneManagement
{
	public sealed class InputGameplayArgs : IInputSceneArgs
	{
        public InputGameplayArgs(int levelNumber)
        {
            LevelNumber = levelNumber;
        }

		public int LevelNumber { get; }
    }
}
