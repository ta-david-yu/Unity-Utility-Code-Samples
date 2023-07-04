using System;
using System.Collections;
using UnityEngine;

public static class MonoBehaviourExtensions
{
	public static void DelayInvoke(this MonoBehaviour monobehaviour, Action action, float delay)
	{
		monobehaviour.StartCoroutine(executeWithDelay(action, delay));
	}

	private static IEnumerator executeWithDelay(Action action, float delay)
	{
    	yield return new WaitForSeconds(delay);
    	action?.Invoke();
	}
}
