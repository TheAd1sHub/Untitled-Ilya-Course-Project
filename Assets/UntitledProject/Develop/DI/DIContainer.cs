using System;
using System.Collections.Generic;

namespace UntitledProject.Develop.DI
{
	public sealed class DIContainer
	{
		private readonly Dictionary<Type, Registration> _container = new();
		private readonly List<Type> _requests = new();

		private readonly DIContainer _parent;

        public DIContainer() : this(parent: null) { }
        public DIContainer(DIContainer parent) => _parent = parent;	

        public void RegisterAsSingle<T>(Func<DIContainer, T> creator)
		{
			if (_container.ContainsKey(typeof(T)))
				throw new InvalidOperationException($"An object of type {typeof(T)} is already registered as Single");

			Registration registration = new Registration(container => creator(container));
			_container.Add(typeof(T), registration);
		}

		public T Resolve<T>()
		{
			if (_requests.Contains(typeof(T)))
				throw new InvalidOperationException($"Cannot resolve. Cyclic dependency detected on {typeof(T)}");

			_requests.Add(typeof(T));

			try
			{
				if (_container.TryGetValue(typeof(T), out Registration registration))
					return CreateInstanceFrom<T>(registration);

				if (_parent != null)
					return _parent.Resolve<T>();
			}
			finally
			{
				_requests.Remove(typeof(T));
			}

			throw new InvalidOperationException($"A {nameof(Registration)} for {typeof(T)} does not exist");
		}

		private T CreateInstanceFrom<T>(Registration registration)
		{
			if (registration.Instance == null && registration.Creator != null)
				registration.Instance = registration.Creator(this);

			return (T)registration.Instance;
		}

		public sealed class Registration
		{
            public Registration(object instance) => Instance = instance;
            public Registration(Func<DIContainer, object> creator) => Creator = creator;

			public object Instance { get; set; }
			public Func<DIContainer, object> Creator { get; }
        }
	}
}
