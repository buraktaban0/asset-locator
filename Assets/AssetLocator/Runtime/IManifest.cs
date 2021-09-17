namespace AssetLocator
{
	public interface IManifest
	{
		
		
		public string Serialize();
		public void   Deserialize(string text);
	}
}
