using Assets.UntitledProject.Develop.CommonUI;
using UnityEngine;

namespace Assets.UntitledProject.Develop.MainMenu.UI
{
	public sealed class MainMenuUIRoot : MonoBehaviour
	{
		[field: SerializeField] public IconsWithTextListView WalletView { get; private set; }

		[field: SerializeField] public Transform HUDLayer { get; private set; }
		[field: SerializeField] public Transform PopupsLayer { get; private set; }
		[field: SerializeField] public Transform VFXLayer { get; private set; }	
	}
}
