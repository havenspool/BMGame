using System;
using UnityEngine;
using System.Linq; 
using System.Xml;  
using System.Collections;
using System.Text;  
using System.Collections.Generic; 

public class MXML{

	private string musicUrl =  Application.dataPath +"/Data/BeatTime.xml";
	List<string> _allList = new List<string>();  
	private XmlDocument musicDoc;

	public MXML(){
		musicDoc = Util.ReadAndLoadXml(musicUrl); 
		GetAllProvinceName ();
		GetBeatList ();
	}

	public string[] GetBeatList(){
		string words = _allList [0];
		string[] split = words.Split(new Char[] { ',' });
		return split;
	}

	private void GetAllProvinceName()  
	{  
		//所有province节点  
		XmlNode musicNode = musicDoc.SelectSingleNode("music");  
		XmlNodeList beatNodeList = musicNode.SelectNodes ("beat");
		foreach (XmlNode b in beatNodeList)  
		{  
			_allList.Add(b.InnerText);
		}
	}  
}
