using UnityEngine;
using System.Collections;

public class ActorVO{
	
//	public static enum AttackType{nu,attack1,attack12,attack14,attack18,attack116}

	public string currentAnimation;

	public float blood = 1000;
	
	public float allBlood = 1000;

	public virtual string HurtTypeName(int type){
		return "";
	}

	public virtual string AttackTypeName(int type){
		return "";
	}

	public void ResetBlood(float all){
		allBlood = all;
		blood = all;
	}

	public float rateBlood{
		get{
			return blood/allBlood;
		}
	}

	public bool IsAnimalBehaiver(string name){
		return currentAnimation == name;
	}

	public bool isNormalAttack{
		get{
			if(currentAnimation == attack_11 || currentAnimation == attack_1){
				return true;
			}
			return false;
		}
	}

	public bool isDead{
		get{
			return currentAnimation == die;
		}
	}

	public bool isWait{
		get{
			bool bo = false;
			if(currentAnimation == idleBeat || currentAnimation == idle){
				bo = true;
			}
			return bo;
		}
	}
	public bool isHurt{
		get{
			bool bo = false;
			if(currentAnimation == hurt_1 
			   ||currentAnimation == hurt_12
			   ||currentAnimation == hurt_14){
				bo = true;
			}
			return bo;
		}
	}
	public bool isAttack{
		get{
			if(currentAnimation == attack_1
			   ||currentAnimation == attack_2
			   ||currentAnimation == attack_11
			   ||currentAnimation == attack_12
			   ||currentAnimation == attack_14
			   ||currentAnimation == attack_18
			   ||currentAnimation == attack_116){
				return true;
			}
			return false;
		}
	}
	public virtual string die{
		get{
			return "die";//30f  1s
		}
	}
	public virtual string idle{
		get{
			return "idle";//14f  0.467s
		}
	}
	public virtual string idleBeat{
		get{
			return "idleBeat";//14f  0.467s
		}
	}
	public virtual string attack_1{
		get{ 
			return "attack_1";//14f  0.467s
		}
	}
	public virtual string attack_11{
		get{ 
			return "attack_11";//14f  0.467s
		}
	}
	public virtual string attack_2{
		get{
			return "attack_2";//14f 0.467s
		}
		
	}
	public virtual string attack_12{
		get{
			return "attack_1-2";
		}
		
	}
	public virtual string attack_14{
		get{ 
			return "attack_1-4";
		}
		
	}
	public virtual string attack_18 {
		get{
			return "attack_1-8";
		}
		
	}
	public virtual string attack_116{
		get{
			return  "attack_1-16";
		}
	}
	public virtual string hurt_1{
		get{
			return  "hurt_1";
		}
	}
	public virtual string hurt_12{
		get{
			return  "hurt_1-2";
		}
	}
	public virtual string hurt_14{
		get{
			return  "hurt_1-4";
		}
	}
	public virtual string ready{
		get{
			return  "ready";
		}
	}
}
