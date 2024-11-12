using UnityEngine;
using Assets.UntitledProject.Develop.DI;
using System.Collections;

namespace Assets.UntitledProject.Develop.EntryPoint
{
	public sealed class EntryPoint : MonoBehaviour
	{
		[SerializeField] private Bootstrap _gameBootstrap;

		private void SetupAppSettings()
		{
			QualitySettings.vSyncCount = 0;

#if UNITY_EDITOR
			Application.targetFrameRate = 144;
#else
			Application.targetFrameRate = 60;
#endif
		}

		private void Awake()
		{
			SetupAppSettings();

			DIContainer projectContainer = new DIContainer();

			// TODO: Register Global Services 

			// TODO: Run Game Bootstrap with Global Project Container
		}
	}
}
