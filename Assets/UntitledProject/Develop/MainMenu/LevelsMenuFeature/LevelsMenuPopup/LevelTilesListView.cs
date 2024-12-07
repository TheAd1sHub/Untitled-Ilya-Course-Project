using System.Collections.Generic;
using UnityEngine;

namespace Assets.UntitledProject.Develop.MainMenu.LevelsMenuFeature.LevelsMenuPopup
{
	public sealed class LevelTilesListView : MonoBehaviour
	{
		[SerializeField] private LevelTileView _levelTileViewPrefab;
		[SerializeField] private Transform _parent;

		private List<LevelTileView> _elements = new();

		public LevelTileView SpawnElement()
		{
			LevelTileView levelTileView = Instantiate(_levelTileViewPrefab, parent: _parent);
			_elements.Add(levelTileView);
			return levelTileView;
		}

		public void Remove(LevelTileView levelTileView)
		{
			_elements.Remove(levelTileView);
			Destroy(levelTileView.gameObject);
		}
	}
}
