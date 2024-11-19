using Assets.UntitledProject.Develop.CommonServices.DataManagement.DataProviders;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.UntitledProject.Develop.CommonServices.DataManagement
{
	public interface IDataSerializer
	{
		public string Serialize<T>(T @object);
		public T Deserialize<T>(string serializedObject);
	}
}