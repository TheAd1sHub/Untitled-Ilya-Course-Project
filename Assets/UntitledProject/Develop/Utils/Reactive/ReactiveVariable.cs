using System;

namespace Assets.UntitledProject.Develop.Utils.Reactive
{
	public class ReactiveVariable<T> : IReadOnlyVariable<T> where T : IEquatable<T> 
	{
		public event Action<T, T> Changed;

		private T _value;

		public ReactiveVariable(T value) => _value = value;

		public ReactiveVariable() : this(default)
		{
		}

		public T Value
		{
			get => _value;
			set
			{
				T oldValue = _value;

				_value = value;

				if (_value.Equals(oldValue) == false)
					Changed?.Invoke(oldValue, value);	
			}
		}
    }
}
