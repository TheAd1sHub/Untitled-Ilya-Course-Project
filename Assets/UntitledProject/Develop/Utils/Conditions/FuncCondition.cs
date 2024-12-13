using System;

namespace Assets.UntitledProject.Develop.Utils.Conditions
{
	public sealed class FuncCondition : ICondition
	{
		private readonly Func<bool> _predicate;

		public FuncCondition(Func<bool> predicate)
		{
			_predicate = predicate;
		}

		public bool Evaluate() => _predicate();
	}
}
