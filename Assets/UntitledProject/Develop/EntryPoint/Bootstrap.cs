using UnityEngine;
using Assets.UntitledProject.Develop.DI;
using System.Collections;
using Assets.UntitledProject.Develop.CommonServices.LoadingScreen;
using Assets.UntitledProject.Develop.CommonServices.SceneManagement;
using Assets.UntitledProject.Develop.CommonServices.DataManagement.DataProviders;
using Assets.UntitledProject.Develop.CommonServices.ConfigsManagement;

namespace Assets.UntitledProject.Develop.EntryPoint
{
	public sealed class Bootstrap : MonoBehaviour
	{
		public IEnumerator Run(DIContainer container)
		{
			// TODO: Start a Loading Animation
			ILoadingCurtain loadingCurtain = container.Resolve<ILoadingCurtain>();
			SceneChangeHandler sceneChanger = container.Resolve<SceneChangeHandler>();

			loadingCurtain.Show();

			Debug.Log("Initializing services...");

			// TODO: Initialize All the Data, Configs, Services, etc.
			container.Resolve<ConfigsProviderService>().LoadAll();
			container.Resolve<PlayerDataProvider>().Load();

			yield return null;

			// TODO: Finish the Loading Animation
			loadingCurtain.Hide();

			Debug.Log("Initialization finished; Opening the next scene.");

			IInputSceneArgs inputMenuArgs = new InputMainMenuArgs();
			sceneChanger.SwitchSceneFor(new OutputBootstrapArgs(inputMenuArgs));
		}
	}
}
