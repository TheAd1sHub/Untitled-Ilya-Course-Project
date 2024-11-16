using System;

namespace Assets.UntitledProject.Develop.CommonServices.SceneManagement
{
	public enum SceneID
	{
		[Obsolete(message: "Protective default value. Never use!", error: true)]
		None = 0,

		Bootstrap = 1,

		MainMenu = 2,

		Gameplay = 3,

		Empty = 4
	}
}
