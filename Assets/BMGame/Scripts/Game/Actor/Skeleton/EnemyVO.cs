using UnityEngine;
using System.Collections;

public class EnemyVO : ActorVO {

	public EnemyVO(){
		allBlood = 800f;
	}

	public override string die{
		get{
			return "enDie";//30f  1s
		}
	}
	
	public override string idle{
		get{
			return "enIdle";//14f  0.467s
		}
	}
	
	public override string idleBeat{
		get{
			return "enIdleBeat";//14f  0.467s
		}
	}
	
	public override string attack_1{
		get{ 
			return "enAttack_1";//14f  0.467s
		}
	}
	public override string attack_2{
		get{
			return "";
		}
		
	}
	public override string attack_12{
		get{
			return "enAttack_1-2";
		}
		
	}
	public override string attack_14{
		get{ 
			return "enAttack_1-4";
		}
		
	}
	public override string attack_18 {
		get{
			return "enAttack_1-8";
		}
		
	}
	public override string attack_116{
		get{
			return  "enAttack_1-16";
		}
	}
}
