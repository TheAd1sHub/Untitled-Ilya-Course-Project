using System;
using UnityEngine;

namespace Assets.UntitledProject.Develop.CommonServices.AssetsManagement
{
	public sealed class ResourcesAssetLoader 
	{
		public T LoadResource<T>(string resourcePath) where T : UnityEngine.Object
		{
			T loadedResource = Resources.Load<T>(resourcePath);

			if (loadedResource is null)
				throw new NullReferenceException($"Resource not found at {resourcePath}");

			return loadedResource;
		}
	}
}
