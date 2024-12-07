using Assets.UntitledProject.Develop.CommonServices.ConfigsManagement;
using Assets.UntitledProject.Develop.CommonServices.LevelsManagement;
using Assets.UntitledProject.Develop.CommonServices.SceneManagement;
using Assets.UntitledProject.Develop.Configs.Gameplay;
using Assets.UntitledProject.Develop.DI;
using System.Collections.Generic;

namespace Assets.UntitledProject.Develop.MainMenu.LevelsMenuFeature.LevelsMenuPopup
{
	public sealed class LevelTilesListPresenter
	{
		private readonly LevelsListConfig _levelsListConfig;
		private readonly LevelsMenuPopupFactory _factory;

		private readonly LevelTilesListView _view;

		private List<LevelTilePresenter> _levelTilePresenters = new();

		public LevelTilesListPresenter(LevelsListConfig levelsListConfig, LevelsMenuPopupFactory factory, LevelTilesListView view)
		{
			_levelsListConfig = levelsListConfig;
			_factory = factory;
			_view = view;
		}

		public void Enable()
		{
			for (int i = 0; i < _levelsListConfig.Levels.Count; i++)
			{
				int levelNumber = i + 1;

				LevelTileView levelTileView = _view.SpawnElement();

				LevelTilePresenter levelTilePresenter = _factory.CreateLevelTilePresenter(levelTileView, levelNumber);
				levelTilePresenter.Enable();

				_levelTilePresenters.Add(levelTilePresenter);
			}
		}

		public void Disable()
		{
			foreach (LevelTilePresenter levelTilePresenter in _levelTilePresenters)
			{
				levelTilePresenter.Disable();
				_view.Remove(levelTilePresenter.View);
			}

			_levelTilePresenters.Clear();
		}
	}
}
