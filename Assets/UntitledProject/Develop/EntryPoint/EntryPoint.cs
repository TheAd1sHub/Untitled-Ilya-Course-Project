using UnityEngine;
using Assets.UntitledProject.Develop.DI;
using Assets.UntitledProject.Develop.CommonServices.AssetsManagement;
using Assets.UntitledProject.Develop.CommonServices.CoroutinesHandler;
using Assets.UntitledProject.Develop.CommonServices.LoadingScreen;
using Assets.UntitledProject.Develop.CommonServices.SceneManagement;
using System;
using Assets.UntitledProject.Develop.CommonServices.DataManagement;
using Assets.UntitledProject.Develop.CommonServices.DataManagement.DataProviders;
using Assets.UntitledProject.Develop.CommonServices.Wallet;
using Assets.UntitledProject.Develop.CommonServices.ConfigsManagement;
using Assets.UntitledProject.Develop.CommonServices.LevelsManagement;

namespace Assets.UntitledProject.Develop.EntryPoint
{
	public sealed class EntryPoint : MonoBehaviour
	{
		[SerializeField] private Bootstrap _gameBootstrap;

		private void SetupAppSettings()
		{
			QualitySettings.vSyncCount = 0;

#if UNITY_EDITOR
			Application.targetFrameRate = 144;
#else
			Application.targetFrameRate = 60;
#endif
		}

		private void RegisterResourcesAssetLoader(DIContainer container)
			=> container.RegisterAsSingle(container => new ResourcesAssetLoader());

		private void RegisterCoroutinesHandler(DIContainer container)
		{
			container.RegisterAsSingle<ICoroutinesHandler>(container =>
			{
				ResourcesAssetLoader resourcesLoader = container.Resolve<ResourcesAssetLoader>();
				CoroutinesHandler coroutinesHandlerPrefab = resourcesLoader
					.LoadResource<CoroutinesHandler>(InfrastructureAssetsPaths.CoroutinesHandlerPath);

				return Instantiate(coroutinesHandlerPrefab);
			});
		}

		private void RegisterLoadingCurtain(DIContainer container)
		{
			container.RegisterAsSingle<ILoadingCurtain>(container =>
			{
				ResourcesAssetLoader resourcesLoader = container.Resolve<ResourcesAssetLoader>();
				StandardLoadingCurtain loadingCurtainPrefab = resourcesLoader
					.LoadResource<StandardLoadingCurtain>(InfrastructureAssetsPaths.LoadingCurtainPath);

				return Instantiate(loadingCurtainPrefab);
			});
		}

		private void RegisterSceneLoader(DIContainer container)
			=> container.RegisterAsSingle<ISceneLoader>(container => new DefaultSceneLoader());

		private void RegisterSceneChangeHandler(DIContainer container)
			=> container.RegisterAsSingle(container => new SceneChangeHandler(
				container,
				container.Resolve<ICoroutinesHandler>(),
				container.Resolve<ILoadingCurtain>(),
				container.Resolve<ISceneLoader>()
				)
			);

		private void RegisterSaveLoadService(DIContainer container)
			=> container.RegisterAsSingle<ISaveLoadService>(container => new SaveLoadService(new JsonSerializer(), new LocalDataRepository()));

		private void RegisterPlayerDataProvider(DIContainer container)
		{
			ISaveLoadService saveLoadService = container.Resolve<ISaveLoadService>();
			ConfigsProviderService configsProviderService = container.Resolve<ConfigsProviderService>();
			container.RegisterAsSingle(container => new PlayerDataProvider(saveLoadService, configsProviderService));
		}

		private void RegisterWalletService(DIContainer container)
		{
			PlayerDataProvider playerDataProvider = container.Resolve<PlayerDataProvider>();
			container.RegisterAsSingle(container => new WalletService(playerDataProvider)).NonLazy();
		}
		
		private void RegisterConfigsProviderService(DIContainer container)
		{
			ResourcesAssetLoader assetLoader = container.Resolve<ResourcesAssetLoader>();
			container.RegisterAsSingle(container => new ConfigsProviderService(assetLoader));
		}

		private void RegisterCompletedLevelsService(DIContainer container)
		{
			PlayerDataProvider playerDataProvider = container.Resolve<PlayerDataProvider>();
			container.RegisterAsSingle(container => new CompletedLevelsService(playerDataProvider));
		}

		private void Awake()
		{
			SetupAppSettings();

			DIContainer projectContainer = new DIContainer();

			// Register Global Services here
			RegisterResourcesAssetLoader(projectContainer);
			RegisterCoroutinesHandler(projectContainer);

			RegisterLoadingCurtain(projectContainer);
			RegisterSceneLoader(projectContainer);
			RegisterSceneChangeHandler(projectContainer);

			RegisterConfigsProviderService(projectContainer);

			RegisterSaveLoadService(projectContainer);
			RegisterPlayerDataProvider(projectContainer);
			RegisterWalletService(projectContainer);

			RegisterCompletedLevelsService(projectContainer);
			// End of field

			projectContainer.Initialize();

			projectContainer.Resolve<ICoroutinesHandler>()
				.StartRoutine(_gameBootstrap.Run(projectContainer));
		}
	}
}
