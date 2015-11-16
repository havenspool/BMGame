using System;
using UnityEngine;
using System.Linq; 
using System.Xml;  
using System.Collections;
using System.Text;  
using System.Collections.Generic; 

public class MXML{

	private string musicUrl =  Application.dataPath +"/Data/BeatTime.xml";
	private List<MBeatVO> _allList = new List<MBeatVO>();  
	private XmlDocument musicDoc;

	public MXML(){
		musicDoc = Util.ReadAndLoadXml(musicUrl); 
		GetAllProvinceName ();
	}

	public string[] GetBeatList(){
		MBeatVO beatVO  = _allList [0];
		return beatVO.GetBeatList();
	}

	private void GetAllProvinceName()  
	{  
		//所有province节点  
		XmlNode musicNode = musicDoc.SelectSingleNode("music");  
		XmlNodeList beatNodeList = musicNode.SelectNodes ("beat");
		foreach (XmlNode b in beatNodeList){  
			MBeatVO beatVO = new MBeatVO();
			beatVO.beatLater = float.Parse(b.Attributes["later"].Value);
			beatVO.attackList = b.InnerText;
			_allList.Add(beatVO);
		}
	}  
}
