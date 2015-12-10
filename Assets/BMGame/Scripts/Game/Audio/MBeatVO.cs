using System;

public class MBeatVO{

	public float waitTime=2;

	public float randomWait=0.2f;

	public string attackList = "";
	
	public string[] GetBeatList(){
		string[] split = attackList.Split(new Char[] { ',' });
		return split;
	}
}
