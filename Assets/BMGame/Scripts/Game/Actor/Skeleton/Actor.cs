using UnityEngine;
using System.Collections;

/**
 * jski
 */
public class Actor : ActorBase{

	protected string die = "die";//30f  1s

	protected string idle = "idle";//14f  0.467s

	protected string idleBeat = "idleBeat";//14f  0.467s

	protected string attack_1 = "attack_1";//14f  0.467s

	protected string attack_2 = "attack_2";//14f 0.467s

	void Awake(){
		init();
	}
}

