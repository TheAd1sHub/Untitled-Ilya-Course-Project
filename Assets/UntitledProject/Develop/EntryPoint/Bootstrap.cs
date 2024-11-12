using UnityEngine;
using Assets.UntitledProject.Develop.DI;
using System.Collections;

namespace Assets.UntitledProject.Develop.EntryPoint
{
	public sealed class Bootstrap : MonoBehaviour
	{
		public IEnumerator Run(DIContainer container)
		{
			// TODO: Start a Loading Animation

			// TODO: Initialize All the Data, Configs, Services, etc.

			yield return null;

			// TODO: Finish the Loading Animation

			// TODO: Change Active Scene
		}
	}
}
