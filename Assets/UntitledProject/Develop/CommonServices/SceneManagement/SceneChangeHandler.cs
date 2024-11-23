using Assets.UntitledProject.Develop.CommonServices.CoroutinesHandler;
using Assets.UntitledProject.Develop.CommonServices.LoadingScreen;
using Assets.UntitledProject.Develop.DI;
using Assets.UntitledProject.Develop.Gameplay.Infrastructure;
using Assets.UntitledProject.Develop.MainMenu.Infrastructure;
using System;
using System.Collections;

namespace Assets.UntitledProject.Develop.CommonServices.SceneManagement
{
	public sealed class SceneChangeHandler
	{
		private const string SceneTransitionErrorMessage = "This transition is impossible";

		private readonly DIContainer _projectContainer;
		private readonly ICoroutinesHandler _coroutinesHandler;
		private readonly ILoadingCurtain _loadingCurtain;
		private readonly ISceneLoader _sceneLoader;

		private DIContainer _currentSceneContainer;

		public SceneChangeHandler(DIContainer projectContainer, ICoroutinesHandler coroutinesHandler,
			ILoadingCurtain loadingCurtain, ISceneLoader sceneLoader)
		{
			_projectContainer = projectContainer;
			_coroutinesHandler = coroutinesHandler;
			_loadingCurtain = loadingCurtain;
			_sceneLoader = sceneLoader;
		}

		public void SwitchSceneFor(IOutputSceneArgs outputSceneArgs)
		{
			switch (outputSceneArgs)
			{
				case OutputBootstrapArgs outputArgs:
					_coroutinesHandler.StartRoutine(ProcessSwitchFromBootstrapScene(outputArgs));
					break;

				case OutputGameplayArgs outputArgs:
					_coroutinesHandler.StartRoutine(ProcessSwitchFromGameplayScene(outputArgs));
					break;

				case OutputMainMenuArgs outputArgs:
					_coroutinesHandler.StartRoutine(ProcessSwitchFromMainMenuScene(outputArgs));
					break;

				default:
					throw new ArgumentException(SceneTransitionErrorMessage);
			}
		}

		private IEnumerator ProcessSwitchFromBootstrapScene(OutputBootstrapArgs outputArgs)
		{
			switch (outputArgs.NextSceneInputArgs)
			{
				case InputMainMenuArgs inputArgs:
					yield return ProcessSwitchToMainMenuScene(inputArgs);
					break;

				default:
					throw new ArgumentException(SceneTransitionErrorMessage);
			}
		}

		private IEnumerator ProcessSwitchFromMainMenuScene(OutputMainMenuArgs outputArgs)
		{
			switch (outputArgs.NextSceneInputArgs)
			{
				case InputGameplayArgs inputArgs:
					yield return ProcessSwitchToGameplayScene(inputArgs);
					break;

				default:
					throw new ArgumentException(SceneTransitionErrorMessage);
			}
		}

		private IEnumerator ProcessSwitchFromGameplayScene(OutputGameplayArgs outputArgs)
		{
			switch (outputArgs.NextSceneInputArgs)
			{
				case InputMainMenuArgs inputArgs:
					yield return ProcessSwitchToMainMenuScene(inputArgs);
					break;

				default:
					throw new ArgumentException(SceneTransitionErrorMessage);
			}
		}

		private IEnumerator ProcessSwitchToMainMenuScene(InputMainMenuArgs inputArgs)
		{
			_loadingCurtain.Show();

			yield return _sceneLoader.LoadSceneAsync(SceneID.Empty);
			yield return _sceneLoader.LoadSceneAsync(SceneID.MainMenu);

			MainMenuBootstrap bootstrap = UnityEngine.Object.FindAnyObjectByType<MainMenuBootstrap>();

			if (bootstrap == null)
				throw new NullReferenceException($"Bootstrap not found");

			_currentSceneContainer = new DIContainer(_projectContainer);

			yield return bootstrap.Run(_currentSceneContainer, new InputMainMenuArgs());

			_loadingCurtain.Hide();
        }

		private IEnumerator ProcessSwitchToGameplayScene(InputGameplayArgs inputArgs)
		{
			_loadingCurtain.Show();

			yield return _sceneLoader.LoadSceneAsync(SceneID.Empty);
			yield return _sceneLoader.LoadSceneAsync(SceneID.Gameplay);

			GameplayBootstrap bootstrap = UnityEngine.Object.FindAnyObjectByType<GameplayBootstrap>();

			if (bootstrap == null)
				throw new NullReferenceException($"Bootstrap not found");

			_currentSceneContainer = new DIContainer(_projectContainer);

			yield return bootstrap.Run(_currentSceneContainer, inputArgs);

			_loadingCurtain.Hide();
		}
	}
}
