using Assets.UntitledProject.Develop.Gameplay.Entities.Behaviors;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.UntitledProject.Develop.Gameplay.Entities
{
	public class Entity : MonoBehaviour
	{
		private readonly Dictionary<EntityValue, object> _values = new();

		private readonly HashSet<IEntityBehavior> _behaviors = new();
		private readonly List<IEntityUpdate> _updatables = new();
		private readonly List<IEntityInitialize> _initializables = new();
		private readonly List<IEntityDispose> _disposables = new();

		public bool IsInitialized { get; private set; } = false;

		public Entity AddValue<TValue>(EntityValue valueType, TValue value)
		{
			if (_values.ContainsKey(valueType))
				throw new ArgumentException($"A value of type {valueType} is already registered");

			_values[valueType] = value;
			return this;
		}

		public bool TryGetValue<TValue>(EntityValue valueType, out TValue value)
		{
			if (_values.TryGetValue(valueType, out object foundObject))
			{ 
				if (foundObject is TValue foundValue)
				{
					value = foundValue;
					return true;
				}
			}

			value = default(TValue);
			return false;
		}

		public TValue GetValue<TValue>(EntityValue valueType)
		{
			if (TryGetValue(valueType, out TValue value) == false)
				throw new ArgumentException($"Unable to find a value of type {valueType}");

			return value;
		}

		public Entity AddBehavior(IEntityBehavior behavior)
		{
			if (_behaviors.Contains(behavior))
				throw new ArgumentException($"A behavior of type {behavior.GetType().Name} is already registered");

			_behaviors.Add(behavior);

			if (behavior is IEntityUpdate updatable)
				_updatables.Add(updatable);

			if (behavior is IEntityInitialize initializable)
			{
				_initializables.Add(initializable);

				if (IsInitialized)
					initializable.OnInitialize(this);
			}

			if (behavior is IEntityDispose disposable)
				_disposables.Add(disposable);

			return this;
		}

		public void Initialize()
		{
			foreach (IEntityInitialize entity in _initializables)
				entity.OnInitialize(this);

			IsInitialized = true;
		}

		private void Update()
		{
			if (IsInitialized == false)
				throw new InvalidOperationException($"Cannot update {name} entity as it was not initialized");

			foreach (IEntityUpdate entity in _updatables)
				entity.OnUpdate(Time.deltaTime);
		}

		private void OnDestroy()
		{
			foreach (IEntityDispose entity in _disposables)
				entity.OnDispose();
		}
	}
}
