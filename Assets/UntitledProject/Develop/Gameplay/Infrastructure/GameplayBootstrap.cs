using Assets.UntitledProject.Develop.CommonServices.SceneManagement;
using Assets.UntitledProject.Develop.DI;
using Assets.UntitledProject.Develop.Gameplay.Entities;
using System.Collections;
using UnityEngine;

namespace Assets.UntitledProject.Develop.Gameplay.Infrastructure
{
	public sealed class GameplayBootstrap : MonoBehaviour
	{
	    private DIContainer _container;

		// TODO: Remove it after testing all the logic
		[SerializeField] private GameplayTest _gameplayTest;

	    public IEnumerator Run(DIContainer container, InputGameplayArgs inputArgs)
	    {
	        _container = container;

	        ProcessRegistrations();

	        Debug.Log($"Loading resources for Level {inputArgs.LevelNumber}");

			_gameplayTest.StartProcess(container);

	        yield return new WaitForSeconds(1.0f); // TODO: Replace with real awaiting 
	    }

		private void ProcessRegistrations()
		{
			// ...
			_container.RegisterAsSingle(container => new EntityFactory(container));

			_container.Initialize();
		}
	}
}
