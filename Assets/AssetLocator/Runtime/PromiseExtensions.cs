using System.Threading.Tasks;

namespace AssetLocator
{
	public static class PromiseExtensions
	{
		public static void Promise(this Task task)
		{
			// var promise = new Promise();
			// promise.InternalTask = task;
			// promise.BeginAwait();
			//
			// return promise;
		}
	}
}
