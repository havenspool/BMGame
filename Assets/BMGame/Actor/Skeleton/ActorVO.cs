using UnityEngine;
using System.Collections;

public class ActorVO{
	
//	public static enum AttackType{nu,attack1,attack12,attack14,attack18,attack116}
	public ActorVO(){}

	public MActorVO mActorVO;

	public string currentAnimation;

	public float blood = 1000;
	
	public float allBlood = 1000;

	public float power = 0;

	public float allPower = 100;

	public virtual string HurtTypeName(int type){
		return "";
	}

	public virtual string AttackTypeName(int type){
		return "";
	}

	public void  addPower(int p){
		if (ratePower != 1) {
			power +=p;
		}
	}
	
	public float ratePower{
		get{
			if (power > allPower) {
				return 1;
			}
			return power / allPower;
		}
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

	public float attackBlood{
		get{
			return mActorVO.attack;
		}
	}

	public bool IsAnimalBehaiver(string name){
		return currentAnimation == name;
	}

	public bool isNormalAttack{
		get{
			if(currentAnimation == attackMiss || currentAnimation == attackNormal){
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
			if(currentAnimation == idle){//currentAnimation == idleBeat ||
				bo = true;
			}
			return bo;
		}
	}

	public bool isCanIdle{
		get{
			if (!isAttack && !isHurt && !isMiss && currentAnimation!=powStart && currentAnimation!=powEnd && currentAnimation!=warning ) {
				return true;
			}
			return false;
		}
	}

	public bool isHurt{
		get{
			bool bo = false;
//			if(currentAnimation == hurt_1 
//			   ||currentAnimation == hurt_12
//			   ||currentAnimation == hurt_14){
//				bo = true;
//			}
			if(currentAnimation == hurt){
				bo = true;
			}
			return bo;
		}
	}

	public bool isMiss{
		get{
			if(currentAnimation == attackMiss){
				return true;
			}
			return false;
		}

	}
	public bool isAttack{
		get{
			if(currentAnimation == attackNormal
			   ||currentAnimation == attackBeat
			   ||currentAnimation == powAttack1
			   ||currentAnimation == powAttack2
//			   ||currentAnimation == attack_1
//			   ||currentAnimation == attack_12
//			   ||currentAnimation == attack_14
//			   ||currentAnimation == attack_18
//			   ||currentAnimation == attack_116
			   ){
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
	public virtual string powIdle{
		get{
			return "powIdle";//14f  0.467s
		}
	}
	public virtual string powAttack1{
		get{
			return "powAttack1";
		}
	}
	public virtual string powAttack2{
		get{
			return "powAttack2";
		}
	}
	public virtual string powStart{
		get{
			return "powStart";
		}
	}
	public virtual string powEnd{
		get{
			return "powEnd";
		}
	}

	public virtual string attackMiss{
		get{
			return "miss";
		}
	}
	public virtual string attackNormal{
		get{
			return "attack";//14f 0.467s attackNormal
		}
	}
	public virtual string attackBeat{
		get{
			return "beatHit";//"attackBeat";//14f 0.467s
		}
	}
	public virtual string hurt{
		get{
			return  "hurt";
		}
	}
	public virtual string warning{
		get{
			return  "warning";
		}
	}
	
//	public virtual string idleBeat{
//		get{
//			return "idle";//14f  0.467s
//		}
//	}
//	public virtual string attack_1{
//		get{ 
//			return "1b";
//		}
//	}
//	public virtual string attack_12{
//		get{
//			return "1_2b";
//		}
//	}
//	public virtual string attack_14{
//		get{ 
//			return "1_4b";
//		}
//	}
//	public virtual string attack_18 {
//		get{
//			return "1_8b";
//		}
//	}
//	public virtual string attack_116{
//		get{
//			return  "1_16-1";
//		}
//	}
//	public virtual string hurt_1{
//		get{
//			return  "hurt_1";
//		}
//	}
//	public virtual string hurt_12{
//		get{
//			return  "hurt_1-2";
//		}
//	}
//	public virtual string hurt_14{
//		get{
//			return  "hurt_1-4";
//		}
//	}

}
