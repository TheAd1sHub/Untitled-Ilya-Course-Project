using Assets.UntitledProject.Develop.CommonServices.SceneManagement;
using Assets.UntitledProject.Develop.DI;
using System.Collections;
using UnityEngine;

namespace Assets.UntitledProject.Develop.Gameplay.Infrastructure
{
	public sealed class GameplayBootstrap : MonoBehaviour
	{
	    private DIContainer _container;

	    public IEnumerator Run(DIContainer container, InputGameplayArgs inputArgs)
	    {
	        _container = container;

	        ProcessRegistrations();

	        Debug.Log($"Loading resources for Level {inputArgs.LevelNumber}");

	        yield return new WaitForSeconds(1.0f); // TODO: Replace with real awaiting 
	    }

		private void ProcessRegistrations()
		{
			// ...

			_container.Initialize();
		}
	}
}
