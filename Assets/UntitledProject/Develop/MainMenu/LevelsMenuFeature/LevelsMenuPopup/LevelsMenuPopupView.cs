using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UntitledProject.Develop.MainMenu.LevelsMenuFeature.LevelsMenuPopup
{
	public sealed class LevelsMenuPopupView : MonoBehaviour
	{
		public event Action CloseRequest;

		[SerializeField] private Button _closeButton;
		[SerializeField] private TMP_Text _title;
		[SerializeField] private LevelTilesListView _levelTileListView;

		public LevelTilesListView LevelTileListView => _levelTileListView;

		public void SetTitle(string title) => _title.text = title;

		private void OnCloseButtonClick() => CloseRequest?.Invoke();

		private void OnEnable() => _closeButton.onClick.AddListener(OnCloseButtonClick);

		private void OnDisable() => _closeButton.onClick.RemoveListener(OnCloseButtonClick);
	}
}
