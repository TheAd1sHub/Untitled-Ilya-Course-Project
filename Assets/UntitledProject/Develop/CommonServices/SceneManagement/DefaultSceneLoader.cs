using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.UntitledProject.Develop.CommonServices.SceneManagement
{
	public sealed class DefaultSceneLoader : ISceneLoader
	{
		public IEnumerator LoadSceneAsync(SceneID sceneId, LoadSceneMode mode = LoadSceneMode.Single)
		{
			AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(sceneId.ToString(), mode);

			while (sceneLoading.isDone == false)
				yield return null;
		}
	}
}
