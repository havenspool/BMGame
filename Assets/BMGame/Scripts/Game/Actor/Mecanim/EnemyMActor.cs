using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class EnemyMActor : MActor {

	private int hash_attack1 = Animator.StringToHash("attack_1");
	private int hash_attack2 = Animator.StringToHash("attack_1-2");
	private int hash_attack4 = Animator.StringToHash("attack_1-4");
	private int hash_attack8 = Animator.StringToHash("attack_1-8");
	private int hash_attack16 = Animator.StringToHash("attack_1-16");

	private bool isHurtClick = false;
	public void OnHurt(int AttackType){
		if(!isHurtClick){
			isHurtClick = true;
			float laterTimer = CenterInfo.audioManager.getBeatTime;
			bool isHitPoint = isHitAttackPoint();
			if(isHitPoint && AttackType==2){
				isHurtClick = false;
				laterTimer = laterTimer*1/3f;
				TriggerHurt();
			}else{
				if(CenterInfo.audioManager.isBeat || isHitPoint){
					laterTimer = laterTimer*1/3f;
				}else{
					laterTimer = laterTimer*4/3f;
				}
			}
			StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => {
				isHurtClick = false;
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
					setDead();
					CenterInfo.game.ShowGameNext();
				}
				CenterInfo.uigame.ShowFlyText(hurtBlood.ToString(),new Vector3(110,216,20));
			},laterTimer));
		}
	}

	private bool isThisBeat=false;
	void FixedUpdate () {
		if(!CenterInfo.game.gameData.isGameOver){
			if(CenterInfo.audioManager.isBeatEnd()){
				TriggerBeat();
			}
			if(CenterInfo.audioManager.isBeat){
				if(!isThisBeat){
					isThisBeat = true;
					if(!isHurtClick){
						setAtttakType1();
					}
				}
			}else{
				isThisBeat = false;
			}
		}
	}

	private int ii = 0;
	private void setAtttakType1(){
		if(ii%4 == 2){
			setAttackType(2);
		}else{
			setAttackType(0);
		}
		ii ++;
	}

	private int attackNum = 0;
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
	
	public bool isHitAttackPoint(){
		bool isHitPoint = false;
		float left = 1;
		if(isAttack()){
			left = animatorStateInfo.normalizedTime-animatorStateInfo.length/2;
		}else{
			left = animatorStateInfo.length/2-animatorStateInfo.normalizedTime;
		}
		if(isAAttack(animatorStateInfo)|| isAAttack(animator.GetNextAnimatorStateInfo(0))){
			if(left<0.1 && left>-0.2){
				isHitPoint = true;
			}
		}
		return isHitPoint;
	}

	private float StartAttackTime(){
		float sTime = 0f;
		if(isAttack()){
			sTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
		}
		return sTime;
	}
	
	public bool isAttack(){
		bool isAK = false;
		if(animatorStateInfo.shortNameHash == hash_attack1
		   ||animatorStateInfo.shortNameHash == hash_attack2
		   ||animatorStateInfo.shortNameHash == hash_attack4
		   ||animatorStateInfo.shortNameHash == hash_attack8
		   ||animatorStateInfo.shortNameHash == hash_attack16){
			isAK = true;
		}
		return isAK;
	}

	public bool isAAttack(AnimatorStateInfo asi){
		bool bo = false;
		if(asi.IsName("attack_1")
		   ||asi.IsName("attack_1-2")
		   ||asi.IsName("attack_1-4")
		   ||asi.IsName("attack_1-8")
		   ||asi.IsName("attack_1-16")){
			bo = true;
		}
		return bo;
	}

	public void setDead(){
		animator.SetBool("isDead",true);
	}

	private bool isDead{
		get{
			return animator.GetBool("isDead");
		}
	}

	private int hurtType = 0;
	private void setAttackType(int type){
		if(hurtType != type && hurtType>0){
			CenterInfo.actorManager.OnHeroHurt(hurtType);
		}
		hurtType = type;
		animator.SetInteger("attackType",type);
		if(type>0){
			SetHurt(false);
		}
	}

	private int getAttackType(){
		return animator.GetInteger("attackType");
	}

	private void TriggerBeat(){
		if(isIdle){
			animator.SetTrigger("isBeat");
		}
	}

	private void TriggerHurt(){
		animator.SetTrigger("isHurt1");
		animator.SetInteger("attackType",0);
	}

	private void SetHurt(bool value){
		if(isWait){
			animator.SetBool("isHurt",value);
		}
	}

	private bool isHurt{
		get{
			bool bo = false;
			if(animatorStateInfo.IsName("hurt")){
				bo = true;
			}
			return bo;
		}
	}

	private bool isIdle{
		get{
			bool bo = false;
			if(animatorStateInfo.IsName("idle")){
				bo = true;
			}
			return bo;
		}
	}

	private bool isWait{
		get{
			bool bo = false;
			if(animatorStateInfo.IsName("idle")
			   ||animatorStateInfo.IsName("idleBeat")){
				bo = true;
			}
			return bo;
		}
	}
}
