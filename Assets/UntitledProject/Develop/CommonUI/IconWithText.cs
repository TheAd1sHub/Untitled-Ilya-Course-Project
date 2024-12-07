using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UntitledProject.Develop.CommonUI
{
	public sealed class IconWithText : MonoBehaviour
	{
		[SerializeField] private TMP_Text _text;
		[SerializeField] private Image _icon;

		public void SetText(string text) => _text.text = text;

		public void SetIcon(Sprite sprite) => _icon.sprite = sprite;
	}
}
