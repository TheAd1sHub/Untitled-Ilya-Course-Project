using System;

namespace Assets.UntitledProject.Develop.Utils.Reactive
{
	public interface IReadOnlyVariable<T>
	{
		public event Action<T, T> Changed;

		T Value { get; }
	}
}
