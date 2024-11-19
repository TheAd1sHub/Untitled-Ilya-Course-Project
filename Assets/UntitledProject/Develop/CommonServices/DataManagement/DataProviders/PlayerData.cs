
using System;
using System.Collections.Generic;

namespace Assets.UntitledProject.Develop.CommonServices.DataManagement.DataProviders
{
	[Serializable]
	public class PlayerData : ISaveData
	{
		public int Money;
		public List<int> CompletedLevels;
	}
}
