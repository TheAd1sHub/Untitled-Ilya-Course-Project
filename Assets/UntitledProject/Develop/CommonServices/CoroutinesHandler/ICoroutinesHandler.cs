using System.Collections;
using UnityEngine;

namespace Assets.UntitledProject.Develop.CommonServices.CoroutinesHandler
{
	public interface ICoroutinesHandler
	{
		public Coroutine StartRoutine(IEnumerator coroutineFunction);

		public void StopRoutine(Coroutine coroutine);
	}
}
