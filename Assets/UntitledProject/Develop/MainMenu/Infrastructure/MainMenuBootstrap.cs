using Assets.UntitledProject.Develop.CommonServices.AssetsManagement;
using Assets.UntitledProject.Develop.CommonServices.DataManagement;
using Assets.UntitledProject.Develop.CommonServices.DataManagement.DataProviders;
using Assets.UntitledProject.Develop.CommonServices.SceneManagement;
using Assets.UntitledProject.Develop.CommonServices.Wallet;
using Assets.UntitledProject.Develop.CommonUI.Wallet;
using Assets.UntitledProject.Develop.DI;
using Assets.UntitledProject.Develop.MainMenu.LevelsMenuFeature.LevelsMenuPopup;
using Assets.UntitledProject.Develop.MainMenu.UI;
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

			InitializeUI();

			yield return new WaitForSeconds(1.0f); // TODO: Replace with real awaiting 
		}

		private void InitializeUI()
		{
			MainMenuUIRoot mainMenuUIRoot = _container.Resolve<MainMenuUIRoot>();

			mainMenuUIRoot.OpenLevelsMenuButton.Initialize(() =>
			{
				LevelsMenuPopupPresenter levelsMenuPopupPresenter = _container.Resolve<LevelsMenuPopupFactory>().CreateLevelsMenuPopupPresenter();
				levelsMenuPopupPresenter.Enable();
			});
		}

		private void ProcessRegistrations()
		{
			_container.RegisterAsSingle(container => new LevelsMenuPopupFactory(container));
			_container.RegisterAsSingle(container => new WalletPresenterFactory(container));

			_container.RegisterAsSingle(container =>
			{
				ResourcesAssetLoader resourcesAssetLoader = container.Resolve<ResourcesAssetLoader>();
				MainMenuUIRoot mainMenuUIRootPrefab = resourcesAssetLoader.LoadResource<MainMenuUIRoot>(MainMenuAssetPaths.UIRootPath);

				return Instantiate(mainMenuUIRootPrefab);
			}).NonLazy();

			_container.RegisterAsSingle(container =>
			{
				WalletPresenterFactory factory = container.Resolve<WalletPresenterFactory>();
				MainMenuUIRoot mainMenuUIRoot = container.Resolve<MainMenuUIRoot>();

				return factory.CreateWalletPresenter(mainMenuUIRoot.WalletView);
			}).NonLazy();

			_container.Initialize();
		}

#if UNITY_EDITOR // In case I forget to remove this debug logic from the final build
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				_container.Resolve<SceneChangeHandler>().SwitchSceneFor(new OutputMainMenuArgs(new InputGameplayArgs(1)));
			}

			if (Input.GetKeyDown(KeyCode.F))
			{
				WalletService wallet = _container.Resolve<WalletService>();
				wallet.Add(CurrencyType.Gold, 1);
				Debug.Log($"Gold in wallet: {wallet.GetCurrencyAmount(CurrencyType.Gold).Value}");
			}

			if (Input.GetKeyDown(KeyCode.S))
			{
				PlayerDataProvider saveLoadService = _container.Resolve<PlayerDataProvider>();
				saveLoadService.Save();
            }
		}
#endif
	}
}
