﻿using UnityEngine;
using System.Collections;
using System.Xml;  

/**
 ** jski
 */
public class Util{

	/// <summary>  
	/// 加载xml文档  
	/// </summary>  
	/// <returns></returns>  
	public static  XmlDocument ReadAndLoadXml(string url)  {  
		XmlDocument doc = new XmlDocument();
		doc.Load(url);  
		return doc;  
		
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
