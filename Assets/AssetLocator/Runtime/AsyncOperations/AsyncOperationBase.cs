using System.Collections;
using UnityEngine;

namespace AssetLocator
{
	public abstract class AsyncOperationBase : CustomYieldInstruction
	{
		public bool HasError { get; protected set; }
	}
}
