using UnityEngine;

namespace Assets.UntitledProject.Develop.CommonServices.LoadingScreen
{
	public interface ILoadingCurtain
	{
		public bool IsShown { get; }

		public void Show();
		public void Hide();
	}
}
