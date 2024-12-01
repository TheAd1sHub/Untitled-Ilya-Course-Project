using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.UntitledProject.Develop.Configs.Gameplay
{
	[CreateAssetMenu(menuName = "Configs/Gameplay/Levels/NewLevelsListConfig", fileName = "LevelsListConfig")]
	public sealed class LevelsListConfig : ScriptableObject
	{
		[SerializeField] private List<LevelConfig> _levels;

		public IReadOnlyList<LevelConfig> Levels => _levels;

		public LevelConfig GetBy(int level)
		{
			int levelIndex = level - 1;

			if (level > _levels.Count)
				throw new ArgumentException($"Unable to get Level #{level}. Only {_levels.Count} levels registered.");

			return _levels[levelIndex];
		}
	}
}
