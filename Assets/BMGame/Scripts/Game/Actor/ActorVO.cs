using UnityEngine;
using System.Collections;

public class ActorVO{

	public float blood = 1000f;

	public float allBlood = 1000f;

	public float perBlood{
		get{
			return blood/allBlood;
		}
	}
}
