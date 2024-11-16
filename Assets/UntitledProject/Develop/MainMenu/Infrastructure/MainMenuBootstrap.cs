using Assets.UntitledProject.Develop.CommonServices.SceneManagement;
using Assets.UntitledProject.Develop.DI;
using System.Collections;
using UnityEngine;

namespace Assets.UntitledProject.Develop.MainMenu.Infrastructure
{
	public sealed class MainMenuBootstrap : MonoBehaviour
	{
		private DIContainer _container;

		public IEnumerator Run(InputMainMenuArgs inputArgs)
		{
			Debug.Log($"Loading resources for Level");

			ProcessRegistrations();

			yield return new WaitForSeconds(1.0f); // TODO: Replace with real awaiting 
		}

		private void ProcessRegistrations()
		{
			// ...
		}
	}
}
