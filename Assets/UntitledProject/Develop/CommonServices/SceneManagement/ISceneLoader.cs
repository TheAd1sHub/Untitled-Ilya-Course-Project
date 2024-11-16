using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.UntitledProject.Develop.CommonServices.SceneManagement
{
	public interface ISceneLoader
	{
		public IEnumerator LoadSceneAsync(SceneID sceneId, LoadSceneMode mode = LoadSceneMode.Single);
	}
}
