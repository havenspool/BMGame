using UnityEngine;
using System.Collections;
using System;
/**
 * jski
 */
public class DelayToInvoke
{

	//	StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>{
	//		
	//	}, 0.1f));
	//}
	public static IEnumerator DelayToInvokeDo(Action action, float delaySeconds)
	{
		yield return new WaitForSeconds(delaySeconds);
		action();
	}

	//第一个是执行一次，第二个是重复执行。
	//void Invoke(string methodName, float time);

	//第一个参数是方法名(注意是字符串形式），并不是更方便的委托。第二个是延时多少秒。只执行一次。
	//void InvokeRepeating(string methodName, float time, float repeatRate);
}
