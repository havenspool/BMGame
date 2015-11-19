using UnityEngine;
using System.Collections;

public class MActorVO {

	public string name;

	public float attack;

	public float defense;

	public float blood;

	public float HurtBeat(float otherAttack){
		return (otherAttack - defense) * 2;
	}

	public float HurtNoBeat(float otherAttack){
		return otherAttack-defense;
	}

	public float HurtBroken(float otherAttack){
		return otherAttack * 2;
	}
}
