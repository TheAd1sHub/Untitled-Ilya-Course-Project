using System;

namespace Assets.UntitledProject.Develop.MainMenu.LevelsMenuFeature.LevelsMenuPopup
{
	public sealed class LevelsMenuPopupPresenter
	{
		//TODO: Add support for localization package (Via configs?)
		private const string TitleName = "Levels";

		private readonly LevelsMenuPopupFactory _factory;
		private LevelTilesListPresenter _levelTilesListPresenter;

		private readonly LevelsMenuPopupView _view;

		public LevelsMenuPopupPresenter(
			LevelsMenuPopupFactory factory,
			LevelsMenuPopupView view)
		{
			_factory = factory;
			_view = view;
		}

		public void Enable()
		{
			_view.SetTitle(TitleName);

			_levelTilesListPresenter = _factory.CreateLevelTilesListPresenter(_view.LevelTileListView);
			_levelTilesListPresenter.Enable();

			_view.CloseRequest += OnCloseRequest;
		}

		public void Disable()
		{
			_levelTilesListPresenter.Disable();	

			_view.CloseRequest -= OnCloseRequest;

			// HACK: These objects shall be destroyed in a separate object as their lifetime is unknown...
			//...unless it works fine this way
			UnityEngine.Object.Destroy(_view.gameObject);
		}

		private void OnCloseRequest()
		{
			Disable();
		}
	}
}
