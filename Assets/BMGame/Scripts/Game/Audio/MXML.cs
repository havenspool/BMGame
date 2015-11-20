using System;
using UnityEngine;
using System.Linq; 
using System.Xml;  
using System.Collections;
using System.Text;  
using System.Collections.Generic; 

public class MXML{

	private string actorUrl = Application.dataPath +"/Data/Actor.xml";
	private string musicUrl =  Application.dataPath +"/Data/BeatTime.xml";
	private XmlDocument musicDoc;
	private Dictionary<string,MActorVO> _allActorDy = new Dictionary<string,MActorVO>();  //Hashtable
	private Dictionary<string,List<MBeatVO>> _allBeatDy = new Dictionary<string,List<MBeatVO>>();  //Hashtable
	private List<MBeatVO> aBeatList = new List<MBeatVO>();  
	private XmlDocument actorDoc;
	
	public int listI = 0;

	public int listCount{
		get{
			return aBeatList.Count;
		}
	}

	public void SetBeatList(string name){
		aBeatList = _allBeatDy[name];
	}

	public MXML(){
		musicDoc = Util.ReadAndLoadXml(musicUrl); 
		actorDoc = Util.ReadAndLoadXml(actorUrl);
		GetAllBeatVO ();
		GetAllActorVO ();
	}

	public string[] GetBeatList(){
		if (listI >= 0) {
			MBeatVO beatVO = aBeatList [listI];
			return beatVO.GetBeatList ();
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
			List<MBeatVO> aList = new List<MBeatVO>();  
			foreach (XmlNode b in beatNodeList){  
				MBeatVO beatVO = new MBeatVO();
				beatVO.beatLater = float.Parse(b.Attributes["later"].Value);
				beatVO.attackList = b.InnerText;
				aList.Add(beatVO);
			}
			_allBeatDy.Add(a.Attributes["name"].Value,aList);
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
