using UnityEngine;
using System.Collections;
using System.Xml;  

/**
 ** jski
 */
public class Util{

//	private static int ipo = 4;//0 edit 1 ios 2 androd 3 mac  4 win

	/// <summary>  
	/// 加载xml文档  
	/// </summary>  
	/// <returns></returns>  
	public static  XmlDocument ReadAndLoadXml(string url)  {  
		XmlDocument doc = new XmlDocument();
		doc.Load(getAppPath()+url);  
		return doc;  
	}  

	private static string getAppPath(){
		string filepath = Application.dataPath +"/StreamingAssets";
		if (RuntimePlatform.OSXEditor == Application.platform) {
		}else if (RuntimePlatform.WindowsPlayer == Application.platform) {
			filepath = Application.dataPath +"/StreamingAssets";
		} else if (RuntimePlatform.OSXPlayer == Application.platform) {
			filepath = Application.dataPath +"/Resources/Data/StreamingAssets";
		}else if (RuntimePlatform.Android == Application.platform) {
			filepath = Application.persistentDataPath;
		}else if (RuntimePlatform.IPhonePlayer == Application.platform) {
			filepath = Application.dataPath + "/Raw";
		}

//		UNITY_EDITOR
//		Debug.Log (Application.dataPath);
//		if (ipo == 1) {
//			///elif UNITY_IPHONE
//			filepath = Application.dataPath + "/Raw";
//		} else if (ipo == 2) {
//			// UNITY_ANDROID
//			filepath = Application.persistentDataPath;
//		} else if (ipo == 3) {
//			filepath = Application.dataPath +"/Resources/Data/StreamingAssets";
//		} else if (ipo == 4) {
//			filepath = Application.dataPath +"/StreamingAssets";
//		}
		return filepath;
	}

	public static float CF(float t,int i){
		if (i == 0) {
			return float.Parse (t.ToString ("f0"));
		} else if (i == 1) {
			return float.Parse (t.ToString ("f1"));
		}else if (i == 2) {
			return float.Parse (t.ToString ("f2"));
		}else if (i == 3) {
			return float.Parse (t.ToString ("f3"));
		}else if (i == 4) {
			return float.Parse (t.ToString ("f4"));
		}else if (i == 5) {
			return float.Parse (t.ToString ("f5"));
		}else if (i == 6) {
			return float.Parse (t.ToString ("f6"));
		}else if (i == 7) {
			return float.Parse (t.ToString ("f7"));
		}
		return t;
	}
}
