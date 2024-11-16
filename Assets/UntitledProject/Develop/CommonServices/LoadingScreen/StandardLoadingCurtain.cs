using UnityEngine;

namespace Assets.UntitledProject.Develop.CommonServices.LoadingScreen
{
	public sealed class StandardLoadingCurtain : MonoBehaviour, ILoadingCurtain
	{
		public bool IsShown => gameObject.activeSelf;

		public void Hide()
		{
			gameObject.SetActive(false);
		}

		public void Show()
		{
			gameObject.SetActive(true);
		}

		private void Awake()
		{
			Hide();
			DontDestroyOnLoad(this);
		}
	}
}
