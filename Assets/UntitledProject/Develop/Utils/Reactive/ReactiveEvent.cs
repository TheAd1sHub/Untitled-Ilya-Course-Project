using System;
using System.Collections.Generic;

namespace Assets.UntitledProject.Develop.Utils.Reactive
{
	public sealed class ReactiveEvent
	{
		private List<ActionNode> _subscribers = new();

		public IDisposable Subscribe(Action action)
		{
			ActionNode actionNode = new ActionNode(action, Remove);
			_subscribers.Add(actionNode);
			
			return actionNode;
		}

		public void Invoke()
		{
			foreach (ActionNode subscriber in _subscribers)
				subscriber.Invoke();	
		}

		private void Remove(ActionNode actionNode) => _subscribers.Remove(actionNode);

		public sealed class ActionNode : IDisposable
		{ 
			private Action _action;
			private Action<ActionNode> _onDispose;

			public ActionNode(Action action, Action<ActionNode> onDispose)
			{
				_action = action;
				_onDispose = onDispose;
			}

			public void Invoke() => _action?.Invoke();

			public void Dispose() => _onDispose?.Invoke(this);
		}
	}

	public sealed class ReactiveEvent<T> 
	{
		private List<ActionNode> _subscribers = new();

		public IDisposable Subscribe(Action<T> action)
		{
			ActionNode actionNode = new ActionNode(action, Remove);
			_subscribers.Add(actionNode);

			return actionNode;
		}

		public void Invoke(T arg)
		{
			foreach (ActionNode subscriber in _subscribers)
				subscriber.Invoke(arg);
		}

		private void Remove(ActionNode actionNode) => _subscribers.Remove(actionNode);

		public sealed class ActionNode : IDisposable
		{
			private Action<T> _action;
			private Action<ActionNode> _onDispose;

			public ActionNode(Action<T> action, Action<ActionNode> onDispose)
			{
				_action = action;
				_onDispose = onDispose;
			}

			public void Invoke(T arg) => _action?.Invoke(arg);

			public void Dispose() => _onDispose?.Invoke(this);
		}
	}
}
