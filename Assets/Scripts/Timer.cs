using UnityEngine;
using System.Collections;
using System;

public class Timer {
	public static IEnumerator Start(float duration, Action callback)
	{
		return Start(duration, false, callback);
	}


	public static IEnumerator Start(float duration, bool repeat, Action callback)
	{
		do
		{
			yield return new WaitForSeconds(duration);
			
			if (callback != null)
				callback();
			
		} while (repeat);
	}
}

