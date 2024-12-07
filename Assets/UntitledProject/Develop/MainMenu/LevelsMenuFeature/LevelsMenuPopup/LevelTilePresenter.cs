using Assets.UntitledProject.Develop.CommonServices.LevelsManagement;
using Assets.UntitledProject.Develop.CommonServices.SceneManagement;
using UnityEngine;

namespace Assets.UntitledProject.Develop.MainMenu.LevelsMenuFeature.LevelsMenuPopup
{
	public sealed class LevelTilePresenter
	{
		private const int FirstLevel = 1;

		private readonly CompletedLevelsService _levelsService;
		private readonly SceneChangeHandler _sceneChanger;

		private readonly int _levelNumber;
		private bool _isLevelBlocked;

		private LevelTileView _view;

		public LevelTilePresenter(
			CompletedLevelsService levelsService,
			SceneChangeHandler sceneChanger,
			int levelNumber,
			LevelTileView view)
		{
			_levelsService = levelsService;
			_sceneChanger = sceneChanger;
			_levelNumber = levelNumber;
			_view = view;
		}

		public LevelTileView View => _view;

		public void Enable()
		{
			_isLevelBlocked = _levelNumber != FirstLevel && IsPreviousLevelCompleted() == false;
			
			_view.SetLevel(_levelNumber.ToString());

			if (_isLevelBlocked)
				_view.SetBlocked();
			else if (_levelsService.IsLevelCompleted(_levelNumber))
				_view.SetCompleted();
			else
				_view.SetActive();

			_view.Clicked += OnViewClicked;
		}

		public void Disable()
		{
			_view.Clicked -= OnViewClicked;
		}

		private bool IsPreviousLevelCompleted() => _levelsService.IsLevelCompleted(_levelNumber - 1);

		private void OnViewClicked()
		{
			if (_isLevelBlocked)
			{
				Debug.Log("This level is blocked. Please, complete all the previous ones first.");
				return;
			}

			if (_levelsService.IsLevelCompleted(_levelNumber))
			{
				Debug.Log("This level was already completed");
				return;
			}

			_sceneChanger.SwitchSceneFor(new OutputMainMenuArgs(new InputGameplayArgs(_levelNumber)));
		}

	}
}
