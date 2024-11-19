using Assets.UntitledProject.Develop.CommonServices.DataManagement;
using Assets.UntitledProject.Develop.CommonServices.DataManagement.DataProviders;
using Assets.UntitledProject.Develop.CommonServices.SceneManagement;
using Assets.UntitledProject.Develop.DI;
using System.Collections;
using UnityEditor;
using UnityEngine;

namespace Assets.UntitledProject.Develop.MainMenu.Infrastructure
{
	public sealed class MainMenuBootstrap : MonoBehaviour
	{
		private DIContainer _container;

		public IEnumerator Run(DIContainer container, InputMainMenuArgs inputArgs)
		{
			_container = container;

			Debug.Log($"Loading resources for Level");

			ProcessRegistrations();

			yield return new WaitForSeconds(1.0f); // TODO: Replace with real awaiting 
		}

		private void ProcessRegistrations()
		{
			// ...
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				_container.Resolve<SceneChangeHandler>().SwitchSceneFor(new OutputMainMenuArgs(new InputGameplayArgs(1)));
			}

			if (Input.GetKeyDown(KeyCode.S))
			{
				ISaveLoadService saveLoadService = _container.Resolve<ISaveLoadService>();

                if (saveLoadService.TryLoad(out PlayerData playerData))
                {
					playerData.Money++;
					playerData.CompletedLevels.Add(playerData.Money);

					saveLoadService.Save(playerData);
                }
				else
				{
					PlayerData defaultPlayerData = new PlayerData()
					{
						Money = 0,
						CompletedLevels = new()
					};

					saveLoadService.Save(defaultPlayerData);
				}
            }
		}
	}
}
