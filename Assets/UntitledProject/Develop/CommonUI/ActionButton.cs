using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UntitledProject.Develop.CommonUI
{
	public sealed class ActionButton : MonoBehaviour
	{
		[SerializeField] private Button _button;

		public void Initialize(Action onClickAction) => _button.onClick.AddListener(() => onClickAction?.Invoke());
	}
}
