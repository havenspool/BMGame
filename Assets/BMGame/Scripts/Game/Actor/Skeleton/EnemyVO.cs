using UnityEngine;
using System.Collections;

public class EnemyVO : ActorVO {

	public string die{
		get{
			return "enDie";//30f  1s
		}
	}
	
	public string idle{
		get{
			return "enIdle";//14f  0.467s
		}
	}
	
	public string idleBeat{
		get{
			return "enIdleBeat";//14f  0.467s
		}
	}
	
	public string attack_1{
		get{ 
			return "enAttack_1";//14f  0.467s
		}
	}
	public string attack_2{
		get{
			return "";
		}
		
	}
	public string attack_12{
		get{
			return "enAttack_1-2";
		}
		
	}
	public string attack_14{
		get{ 
			return "enAttack_1-4";
		}
		
	}
	public string attack_18 {
		get{
			return "enAttack_1-8";
		}
		
	}
	public string attack_116{
		get{
			return  "enAttack_1-16";
		}
	}
}
