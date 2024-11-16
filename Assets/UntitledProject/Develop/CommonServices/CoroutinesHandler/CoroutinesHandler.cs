using System.Collections;
using UnityEngine;

namespace Assets.UntitledProject.Develop.CommonServices.CoroutinesHandler
{
	public sealed class CoroutinesHandler : MonoBehaviour, ICoroutinesHandler
	{
		public Coroutine StartRoutine(IEnumerator coroutineFunction)
			=> StartCoroutine(coroutineFunction);

		public void StopRoutine(Coroutine coroutine)
			=> StopCoroutine(coroutine);

		private void Awake()
		{
			DontDestroyOnLoad(this);
		}
	}
}
