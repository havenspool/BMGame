using System;
using UnityEngine;
using System.Linq; 
using System.Xml;  
using System.Collections;
using System.Text;  
using System.Collections.Generic; 

public class MXML{
	
	public int listI = 0;
	private string actorUrl = "/Actor.txt";
	private string musicUrl =  "/BeatTime.txt";
	private XmlDocument musicDoc;
	private Dictionary<string,MActorVO> _allActorDy = new Dictionary<string,MActorVO>();
	private Dictionary<string,MBeatList> _allBeatDy = new Dictionary<string,MBeatList>();
	private MBeatList mbeatList;
	private XmlDocument actorDoc;

	public MBeatList getMBeatList(){
		return mbeatList;
	}

	public int listCount{
		get{
			return mbeatList.Count;
		}
	}

	public void SetBeatList(string name){
		mbeatList = _allBeatDy[name];
	}

	public MXML(){
		musicDoc = Util.ReadAndLoadXml(musicUrl); 
		actorDoc = Util.ReadAndLoadXml(actorUrl);
		GetAllBeatVO ();
		GetAllActorVO ();
	}

	public string[] GetBeatList(){
		if (listI >= 0 && null != mbeatList) {
			return mbeatList.getBeatList(listI);
		} else {
			return new string[]{"0"};
		}
	}

	public MActorVO GetMActorVO(string name){
		MActorVO mvo = _allActorDy [name];
		return mvo;
	}

	private void GetAllBeatVO(){  
		XmlNode musicNode = musicDoc.SelectSingleNode("music");  
		XmlNodeList actorNodeList = musicNode.SelectNodes ("actor");
		foreach (XmlNode a in actorNodeList) {  
			XmlNodeList beatNodeList = a.SelectNodes ("beat");
			MBeatList beatlist = new MBeatList();
			beatlist.waitTime = float.Parse(a.Attributes["waitTime"].Value);
			beatlist.randomWait = float.Parse(a.Attributes["randomWait"].Value);
			foreach (XmlNode b in beatNodeList){  
				MBeatVO beatVO = new MBeatVO();
				beatVO.attackList = b.InnerText;
				beatlist.Add(beatVO);
			}
			_allBeatDy.Add(a.Attributes["name"].Value,beatlist);
		}
	}  

	private void GetAllActorVO(){  
		XmlNode actorNode = actorDoc.SelectSingleNode("actor");  
		XmlNodeList voList = actorNode.SelectNodes ("data");
		foreach (XmlNode b in voList){  
			MActorVO mActorVO = new MActorVO();
			mActorVO.name = b.InnerText;
			mActorVO.blood = float.Parse(b.Attributes["blood"].Value);
			mActorVO.attack = float.Parse(b.Attributes["attack"].Value);
			mActorVO.defense = float.Parse(b.Attributes["defense"].Value);
			_allActorDy.Add(mActorVO.name,mActorVO);
		}
	}  
}
