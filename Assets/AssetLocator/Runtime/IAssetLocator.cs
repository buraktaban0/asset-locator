namespace AssetLocator
{
	public interface IAssetLocator
	{
		/// <summary>
		/// Checks if the asset defined by the 'key' is cached. Cache location is Application.persistentDataPath.
		/// </summary>
		/// <param name="key">Ket of the asset</param>
		/// <returns>A bool promise, true if the asset was found in the cache.</returns>
		public IPromise<bool> IsAssetCached(string key);

		/// <summary>
		/// Tries to cache the asset defined by the 'key'. Cache location is Application.persistentDataPath.
		/// </summary>
		/// <param name="key">Key of the asset</param>
		/// <returns>A bool promise, true if caching was successful.</returns>
		public IPromise<bool> CacheAsset(string key);

		/// <summary>
		/// Loads the asset defined by the 'key'.
		/// </summary>
		/// <param name="key">Key of the asset</param>
		/// <typeparam name="T">Type of the asset</typeparam>
		/// <returns>An asset promise.</returns>
		public IPromise<T> LoadAsync<T>(string key) where T : UnityEngine.Object;
	}
}
