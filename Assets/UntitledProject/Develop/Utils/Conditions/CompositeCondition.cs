using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.UntitledProject.Develop.Utils.Conditions
{
	public class CompositeCondition : ICompositeCondition
	{
		// A default logic operation used to reduce the conditions list to a single result
		protected readonly Func<bool, bool, bool> DefaultPredicate; 

		protected List<(ICondition, Func<bool, bool, bool>)> Conditions = new();

		public CompositeCondition(Func<bool, bool, bool> defaultPredicate)
		{
			DefaultPredicate = defaultPredicate;
		}

		public CompositeCondition(ICondition condition, Func<bool, bool, bool> defaultPredicate)
			: this(defaultPredicate)
		{
			Conditions.Add((condition, defaultPredicate));
		}

		public virtual bool Evaluate()
		{
			if (Conditions.Count == 0)
				return false;

			bool result = Conditions[0].Item1.Evaluate();

			for (int i = 1; i < Conditions.Count; i++)
			{
				(ICondition, Func<bool, bool, bool>) currentCondition = Conditions[i];

				if (currentCondition.Item2 != null)
					result = currentCondition.Item2.Invoke(result, currentCondition.Item1.Evaluate());
				else
					result = DefaultPredicate.Invoke(result, currentCondition.Item1.Evaluate());
			}

			return result;
		}

		public ICompositeCondition Add(ICondition condition, Func<bool, bool, bool> predicate = null)
		{
			Conditions.Add((condition, predicate));

			return this;
		}

		public ICompositeCondition Remove(ICondition condition)
		{
			(ICondition, Func<bool, bool, bool>) conditionPair = Conditions.First(conditionData => conditionData.Item1 == condition);
			Conditions.Remove(conditionPair);

			return this;
		}
	}
}
