using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class ActorEnemy : Actor{
	
	private int ii = 0;
	private int hurtType = 0;
	private bool isHurt = false;
//	private bool isAttackBeat=false;
	private int attackNum = 0;
	
	protected override void init(){
		base.init();
		actorVO = new EnemyVO();
	}

	void Start (){
		addEvent();
		setSpeed(CenterInfo.audioManager.GetScaleTime());
	}
	
	void FixedUpdate () {
		if(!CenterInfo.game.gameData.isGameOver){
			if(CenterInfo.audioManager.mAdudio.IsBeatCenter()){
				if(!actorVO.isAttack && !actorVO.isHurt){
					setAnimation(actorVO.idleBeat,true,false);
				}
			}
//			if(CenterInfo.audioManager.isBeat){
//				if(!isAttackBeat){
//					isAttackBeat = true;
//					if(!isHurt){
//						setAtttakType1();
//					}
//				}
//			}else{
//				isAttackBeat = false;
//			}
		}
	}

	private void setAtttakType1(){
		if(ii%4 == 2){
			setAttackType(2);
		}else{
			setAttackType(0);
		}
		ii ++;
	}

	private bool isSetAttack(){
		bool bo = false;
		float value = Random.value;
		if(value<0.2f){
			bo = true;
			setAttackType(1);
		}else if(value<0.4f){
			bo = true;
			setAttackType(2);
		}else{
			bo = false;
			setAttackType(0);
		}
		attackNum ++;
		return bo;
	}

	private void setAttackType(int type){
		if(hurtType != type && hurtType>0){
			CenterInfo.actorManager.OnHeroHurt(hurtType);
		}
		hurtType = type;
		if(actorVO.HurtTypeName(type) != ""){
			setAnimation(actorVO.HurtTypeName(hurtType),false,false);
		}else{
			setAnimation(actorVO.idleBeat,true,false);
		}
	}

	public override void OnHurt(int AttackType){
		if(!isHurt){
			isHurt = true;
			float laterTimer = CenterInfo.audioManager.getBeatTime;
			bool isHitPoint = isHitAttackPoint();
			if(isHitPoint && AttackType==2){
				isHurt = false;
				laterTimer = laterTimer*1/3f;
				setAnimation(actorVO.HurtTypeName(hurtType),false,false);
			}else{
				if(CenterInfo.audioManager.isBeat || isHitPoint){
					laterTimer = laterTimer*1/3f;
				}else{
					laterTimer = laterTimer*4/3f;
				}
			}
			StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => {
				isHurt = false;
				float hurtBlood = 0f;
				if(actorVO.blood>0){
					if(AttackType==1){
						hurtBlood = 5f;
						actorVO.blood -=hurtBlood;
					}else if(AttackType==2){
						hurtBlood = 50f;
						actorVO.blood -=hurtBlood;
					}
				}else{
					actorVO.blood =0;
					setAnimation(actorVO.die,false,false);
					CenterInfo.game.ShowGameNext();
				}
				CenterInfo.uigame.ShowFlyText(hurtBlood.ToString(),new Vector3(110,216,20));
			},laterTimer));
		}
	}

	public bool isHitAttackPoint(){
		bool isHitPoint = false;
//		float left = 1;
//		if(isAttack()){
//			left = animatorStateInfo.normalizedTime-animatorStateInfo.length/2;
//		}else{
//			left = animatorStateInfo.length/2-animatorStateInfo.normalizedTime;
//		}
//		if(isAAttack(animatorStateInfo)|| isAAttack(animator.GetNextAnimatorStateInfo(0))){
//			if(left<0.1 && left>-0.2){
//				isHitPoint = true;
//			}
//		}
		return isHitPoint;
	}



}

