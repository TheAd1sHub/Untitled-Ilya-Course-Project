using System.Collections.Generic;
using UnityEngine;

namespace Assets.UntitledProject.Develop.CommonUI
{
	public class IconsWithTextListView : MonoBehaviour
	{
		[SerializeField] private IconWithText _iconWithTextPrefab;
		[SerializeField] private Transform _parent;

		private List<IconWithText> _elements = new();

		public IconWithText SpawnElement()
		{
			IconWithText iconWithText = Instantiate(_iconWithTextPrefab, parent: _parent);
			_elements.Add(iconWithText);
			return iconWithText;
		}

		public void Remove(IconWithText iconWithText)
		{
			_elements.Remove(iconWithText);
			Destroy(iconWithText.gameObject);
		}
	}
}
