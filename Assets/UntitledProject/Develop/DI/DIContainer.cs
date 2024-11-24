using System;
using System.Collections.Generic;

namespace Assets.UntitledProject.Develop.DI
{
	public sealed class DIContainer : IDisposable
	{
		private readonly Dictionary<Type, Registration> _container = new();
		private readonly List<Type> _requests = new();

		private readonly DIContainer _parent;

        public DIContainer() : this(parent: null) { }
        public DIContainer(DIContainer parent) => _parent = parent;	

        public Registration RegisterAsSingle<T>(Func<DIContainer, T> creator)
		{
			if (_container.ContainsKey(typeof(T)))
				throw new InvalidOperationException($"An object of type {typeof(T)} is already registered as Single");

			Registration registration = new Registration(container => creator(container));
			_container.Add(typeof(T), registration);

			return registration;
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

		public void Initialize()
		{
			foreach (Registration registration in _container.Values)
			{
				if (registration.Instance == null && registration.Factory != null)
					registration.Instance = registration.Factory(this);

				if (registration.Instance != null && registration.Instance is IInitializable initializable)
					initializable.Initialize();
			}
		}

		public void Dispose()
		{
			foreach (Registration registration in _container.Values)
			{
				if (registration.Instance != null && registration.Instance is IDisposable disposable)
					disposable.Dispose();
			}
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
            public Registration(Func<DIContainer, object> factory) => Factory = factory;

			public object Instance { get; set; }
<<<<<<< Updated upstream
			public Func<DIContainer, object> Creator { get; }
=======
			public Func<DIContainer, object> Factory { get; }

			public bool IsNonLazy { get; private set; } = false;
			
			public void NonLazy() => IsNonLazy = true;
			public void Lazy() => IsNonLazy = false;
>>>>>>> Stashed changes
        }
	}
}
