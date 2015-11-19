using UnityEngine;
using System.Collections;

public class EnemyVO : ActorVO {

	public EnemyVO(string name):base(name){
		mActorVO = CenterInfo.game.gameData.mxml.GetMActorVO (name);
		ResetBlood(mActorVO.blood);
	}

	public override string HurtTypeName(int type){
		string name = "idle";
		if(type ==1){
			name = hurt_1;
		}else if(type ==2){
			name = hurt_12;
		}else if(type==3){
			name = hurt_14;
		}else if(type==4){
			name = hurt_14;
		}else if(type==6){
			name = hurt_14;
		}
		return name;
	}

	public override string AttackTypeName(int type){
		string name = "idle";
		if(type ==1){
			name = attack_1;
		}else if(type ==2){
			name = attack_12;
		}else if(type==3){
			name = attack_14;
		}else if(type==4){
			name = attack_18;
		}else if(type==5){
			name = attack_116;
		}
		return name;
	}

	public override string attack_1{
		get{ 
			return "1b";//14f  0.467s
		}
	}
	public override string attack_12{
		get{
			return "1_2b";
		}
	}
	public override string attack_14{
		get{ 
			return "1_4b";
		}	
	}
	public override string hurt_1{
		get{
			return  "h1b";
		}
	}
	public override string hurt_12{
		get{
			return  "h1_2b";
		}
	}
	public override string hurt_14{
		get{
			return  "h1_4b";
		}
	}
}
