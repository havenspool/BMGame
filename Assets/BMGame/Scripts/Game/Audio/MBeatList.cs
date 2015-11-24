using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class MBeatList{
	
	public float waitTime=2;
	
	public float randomWait=0.2f;

	private List<MBeatVO> aBeatList = new List<MBeatVO>(); 

	public int Count{
		get{
			return aBeatList.Count;
		}
	}

	public string[] getBeatList(int id){
		MBeatVO beatVO = aBeatList[id];
		return beatVO.GetBeatList ();
	}

	public void Add(MBeatVO vo){
		aBeatList.Add (vo);
	}
}
