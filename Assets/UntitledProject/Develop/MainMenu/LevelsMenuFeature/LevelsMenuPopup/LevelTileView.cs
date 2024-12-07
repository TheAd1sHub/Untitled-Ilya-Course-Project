using Assets.UntitledProject.Develop.CommonServices.LevelsManagement;
using Assets.UntitledProject.Develop.CommonServices.SceneManagement;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UntitledProject.Develop.MainMenu.LevelsMenuFeature.LevelsMenuPopup
{
	public sealed class LevelTileView : MonoBehaviour
	{
		public event Action Clicked;
		
		[SerializeField] private Image _background;
		[SerializeField] private TMP_Text _levelNumberText;
		[SerializeField] private Button _button;

		[SerializeField] private Color _activeColor;
		[SerializeField] private Color _completedColor;
		[SerializeField] private Color _blockedColor;

		public void SetLevel(string level) => _levelNumberText.text = level;

		public void SetBlocked() => _background.color = _blockedColor;
		public void SetCompleted() => _background.color = _completedColor;
		public void SetActive() => _background.color = _activeColor;

		private void OnClick() => Clicked?.Invoke();

		private void OnEnable() => _button.onClick.AddListener(OnClick);

		private void OnDisable() => _button.onClick.RemoveListener(OnClick);
	}
}
