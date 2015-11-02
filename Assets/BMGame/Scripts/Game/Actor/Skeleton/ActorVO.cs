using UnityEngine;
using System.Collections;

public class ActorVO : IActorVO {

	public string die{
		get{
			return "die";//30f  1s
		}
	}
	
	public string idle{
		get{
			return "idle";//14f  0.467s
		}
	}
	
	public string idleBeat{
		get{
			return "idleBeat";//14f  0.467s
		}
	}
	
	public string attack_1{
		get{ 
			return "attack_1";//14f  0.467s
		}
	}
	public string attack_2{
		get{
			return "attack_2";//14f 0.467s
		}
		
	}
	public string attack_12{
		get{
			return "attack_1-2";
		}
		
	}
	public string attack_14{
		get{ 
			return "attack_1-4";
		}
		
	}
	public string attack_18 {
		get{
			return "attack_1-8";
		}
		
	}
	public string attack_116{
		get{
			return  "attack_1-16";
		}
	}
	public bool isDead{
		get{
			return currentAnimation == die;
		}
	}
	
	public bool isAttack{
		get{
			if(currentAnimation == attack_1
			   ||currentAnimation == attack_2
			   ||currentAnimation == attack_12
			   ||currentAnimation == attack_14
			   ||currentAnimation == attack_18
			   ||currentAnimation == attack_116){
				return true;
			}
			return false;
		}
	}
}
