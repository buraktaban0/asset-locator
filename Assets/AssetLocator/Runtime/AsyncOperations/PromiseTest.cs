using System;
using System.Collections;
using UnityEngine;

namespace AssetLocator
{
	public class PromiseTest : MonoBehaviour
	{
		private IEnumerator Start()
		{
			yield return new WaitForSeconds(1.5f);

			Debug.Log("STart " + Time.frameCount);

			IPromise<GameObject> promise = ResourcePromise<GameObject>.Get("test");
			promise.Completed += result => { Debug.Log(result.name + " was loaded. " + Time.frameCount); };

			Debug.Log("promise started " + Time.frameCount);

			yield return promise;

			Debug.Log("promise yield " + Time.frameCount);
		}
	}
}
