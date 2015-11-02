using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
 * jski
 */
public class AssetManager{
	
	public static GameObject CreateGameObject(string path){
		try{
			GameObject obj = GameObject.Instantiate(Resources.Load(path, typeof(GameObject))) as GameObject;
			return obj;
		}catch(Exception ec){
			Debug.LogError("Can not instant resource : " + path + ". " + ec);
		}
		return null;
	}
	
	public static GameObject CreateGameObject(string path, Vector3 pos, Quaternion rot){
		try{
			GameObject obj = GameObject.Instantiate(Resources.Load(path, typeof(GameObject)), pos, rot) as GameObject;
			return obj;
		}catch(Exception ec){
			Debug.LogError("Can not instant resource : " + path + ". " + ec);
		}
		return null;
	}
	
	public static void DestroyGameObject(GameObject go , float delay = 0f) {
		if (delay <= 0) {
			GameObject.Destroy(go);
		} else {
			GameObject.Destroy(go,delay);
		}
	}
}

