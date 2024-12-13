using System;

namespace Assets.UntitledProject.Develop.Utils.Conditions
{
	public interface ICompositeCondition : ICondition
	{
		public ICompositeCondition Add(ICondition condition, Func<bool, bool, bool> predicate = null);

		public ICompositeCondition Remove(ICondition condition);
	}
}
