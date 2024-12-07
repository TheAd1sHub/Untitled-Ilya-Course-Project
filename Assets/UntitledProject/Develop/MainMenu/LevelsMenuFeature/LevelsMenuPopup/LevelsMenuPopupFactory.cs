using Assets.UntitledProject.Develop.CommonServices.AssetsManagement;
using Assets.UntitledProject.Develop.CommonServices.ConfigsManagement;
using Assets.UntitledProject.Develop.CommonServices.LevelsManagement;
using Assets.UntitledProject.Develop.CommonServices.SceneManagement;
using Assets.UntitledProject.Develop.Configs.Gameplay;
using Assets.UntitledProject.Develop.DI;
using Assets.UntitledProject.Develop.MainMenu.UI;

namespace Assets.UntitledProject.Develop.MainMenu.LevelsMenuFeature.LevelsMenuPopup
{
	public sealed class LevelsMenuPopupFactory
	{
		private readonly DIContainer _container;
		private readonly ResourcesAssetLoader _resourcesAssetLoader;
		private readonly MainMenuUIRoot _mainMenuUIRoot;

		public LevelsMenuPopupFactory(DIContainer container)
		{
			_container = container;

			_resourcesAssetLoader = _container.Resolve<ResourcesAssetLoader>();
			_mainMenuUIRoot = container.Resolve<MainMenuUIRoot>();
		}

		public LevelTilePresenter CreateLevelTilePresenter(LevelTileView view, int levelNumber)
		{
			CompletedLevelsService completedLevelsService = _container.Resolve<CompletedLevelsService>();
			SceneChangeHandler sceneChanger = _container.Resolve<SceneChangeHandler>();

			return new LevelTilePresenter(completedLevelsService, sceneChanger, levelNumber, view);
		}

		public LevelTilesListPresenter CreateLevelTilesListPresenter(LevelTilesListView view)
		{
			LevelsListConfig config = _container.Resolve<ConfigsProviderService>().LevelsListConfig;

			return new LevelTilesListPresenter(config, this, view);
		}

		public LevelsMenuPopupPresenter CreateLevelsMenuPopupPresenter()
		{
			LevelsMenuPopupView levelsMenuPopupViewPrefab = _resourcesAssetLoader.LoadResource<LevelsMenuPopupView>(MainMenuAssetPaths.LevelsMenuPopupViewPath);
			LevelsMenuPopupView levelsMenuPopupView = UnityEngine.Object.Instantiate(levelsMenuPopupViewPrefab, _mainMenuUIRoot.PopupsLayer);

			return new LevelsMenuPopupPresenter(this, levelsMenuPopupView);
		}
	}
}
