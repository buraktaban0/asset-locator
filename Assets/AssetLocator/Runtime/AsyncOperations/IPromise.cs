using System;
using System.Collections;

namespace AssetLocator
{
	public interface IPromise : IEnumerator
	{
		public delegate void PromiseCompleted();

		public delegate void PromiseFailed(Exception error);

		public event PromiseCompleted Completed;
		public event PromiseFailed    Failed;

		public float Progress { get; }

		public object Result { get; }

		public bool HasError { get; }
	}

	public interface IPromise<T> : IEnumerator
	{
		public delegate void PromiseCompleted(T result);

		public delegate void PromiseFailed(Exception error);

		public event PromiseCompleted Completed;
		public event PromiseFailed    Failed;

		public float Progress { get; }

		public T Result { get; }

		public bool HasError { get; }
	}
}
