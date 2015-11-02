using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class HeroMActor : MActor {

	private bool isHurtClick = false;
	public void OnHurt(int AttackType){
		if(!isHurtClick && AttackType>0){
			isHurtClick = true;
			float laterTimer = CenterInfo.audioManager.getBeatTime;
			if(AttackType==1){
				laterTimer = laterTimer*2/3f;
			}else if(AttackType==2){
				laterTimer = laterTimer*1/12f;
			}else if(AttackType==4){
				laterTimer = laterTimer*1/1024f;
			}

			StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => {
				hurtTBlood(AttackType);
			},laterTimer));
		}
	}

	private void hurtTBlood(int AttackType){
		isHurtClick = false;
		if(CenterInfo.actorManager.enemyActor.isAttack()){
			float hurtBlood = 0f;
			if(actorVO.blood>0){
				if(AttackType==1){
					hurtBlood = 40f;
					actorVO.blood -=hurtBlood;
				}else if(AttackType==2){
					hurtBlood = 20f;
					actorVO.blood -=hurtBlood;
				}else if(AttackType==4){
					hurtBlood = 10f;
					actorVO.blood -=hurtBlood;
				}
			}else{
				actorVO.blood =0;
				setDead();
				CenterInfo.game.ShowGameEnd();
			}
			if(hurtBlood>0){
				CenterInfo.uigame.ShowFlyText(hurtBlood.ToString(),new Vector3(-110,216,20));
			}
		}
	}

	private bool isBeatAtack;
	private bool isBeatClick = true;
	public int OnAttack(bool isHitPoint){
		if(isBeatAtack){
			if(isHitPoint){
				animator.SetTrigger("isAttack2");
				attackType = 2;
			}else{
				attackType = normalAttack();
			}
		}else{
			attackType = normalAttack();
		}
		return attackType;
	}

	private int attackType= 0;
	private int normalAttack(){
		if(!CenterInfo.audioManager.isBeat){
			if(isBeatAtack){
				if(!isAttack1()){
					isBeatAtack = false;
					animator.SetTrigger("isAttack1");
					attackType = 1;
				}
			}else{
				attackType = 0;
			}
		}else{
			if(isBeatAtack){
				if(!isAttack1()){
					animator.SetTrigger("isAttack2");
					attackType = 2;
				}
			}else{
				attackType = 0;
			}
		}
		return attackType;
	}

	public void setDead(){
		animator.SetBool("isDead",true);
	}

	void FixedUpdate () {
		if(CenterInfo.audioManager.isBeatEnd()){
			if(animatorStateInfo.IsName("idle")){
				animator.SetTrigger("isBeat");
			}
		}
		if(CenterInfo.audioManager.isBeat){
			if(!isBeatClick){
				isBeatAtack = true;
				isBeatClick = true;
			}
		}else{
			isBeatClick = false;
		}
	}

	private bool isIdle(){
		bool bo = false;
		if(animatorStateInfo.IsName("idleBeat") || animatorStateInfo.IsName("idle")){
			bo = true;
		}
		return bo;
	}

	private bool isAttack1(){
		bool bo = false;
		if(animatorStateInfo.IsName("attack_1")){
			bo = true;
		}else if(animatorStateInfo.IsName("attack_2")&&attackType==1){
			bo = true;
		}
		return bo;
	}
}
