using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace AssetLocator
{
	public class ResourcePromise<T> : IPromise<T> where T : UnityEngine.Object
	{
		public static IPromise<T> Get(string key)
		{
			var promise = new ResourcePromise<T>();
			promise.UnderlyingRequest = Resources.LoadAsync<T>(key);
			promise.UnderlyingRequest.completed += op => { promise.Completed((T) promise.UnderlyingRequest.asset); };
			return promise;
		}

		public object Current { get; }

		public event IPromise<T>.PromiseCompleted Completed = delegate(T result) { };
		public event IPromise<T>.PromiseFailed    Failed    = delegate(Exception error) { };

		private int x = 0;

		public float Progress
		{
			get
			{
				if (UnderlyingRequest == null)
					return 0f;

				return UnderlyingRequest.progress;
			}
		}

		public T Result { get; private set; }

		public bool HasError { get; }

		public ResourceRequest UnderlyingRequest { get; internal set; }

		public bool MoveNext()
		{
			if (x++ < 4 || !UnderlyingRequest.isDone)
			{
				return true;
			}

			Result = (T) UnderlyingRequest.asset;

			// Completed(Result);

			return false;
		}

		public void Reset()
		{
		}
	}

	public class Promise<T>
	{
		public delegate void PromiseCompletedDelegate(T result);

		public delegate void PromiseFailedDelegate(string reason);

		public event PromiseFailedDelegate    Failed    = delegate(string reason) { };
		public event PromiseCompletedDelegate Completed = delegate(T result) { };

		private T m_Result;

		public T Result
		{
			get => m_Result;
			internal set => m_Result = value;
		}

		public Task<T> InternalTask { get; internal set; }

		internal async void BeginAwait()
		{
			try
			{
				m_Result = await InternalTask;
			}
			catch (Exception e)
			{
				Failed(e.ToString());
				throw;
			}

			Completed(m_Result);
		}
	}
}
