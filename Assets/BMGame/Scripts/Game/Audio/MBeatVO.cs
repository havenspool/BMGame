using System;

public class MBeatVO{

	public float beatLater = 0;

	public string attackList = "";
	
	public string[] GetBeatList(){
		string[] split = attackList.Split(new Char[] { ',' });
		return split;
	}
}
