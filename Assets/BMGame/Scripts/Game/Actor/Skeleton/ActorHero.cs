using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class ActorHero : Actor{

	private int attackType= 0;
	private bool isHurtClick = false;

	protected override void init(){
		isAutoForAttack2 = true;
		base.init();
		actorVO = new HeroVO();
	}

	void Start (){
		addEvent();
		setSpeed(CenterInfo.audioManager.GetScaleTime());
	}

	public void OnUpdate () {
		if(!CenterInfo.game.gameData.isGameOver){
			if(CenterInfo.audioManager.mAdudio.IsBeatCenter()){
				if(!actorVO.isAttack && !actorVO.isHurt){
					setAnimation(actorVO.idleBeat,true,false);
				}
			}
		}
		if (CenterInfo.game.gameData.isBeatTouch && !CenterInfo.audioManager.isEnemyAttack) {
			CenterInfo.game.gameData.isBeatTouch = CenterInfo.audioManager.isBeat;
		}
	}
	
	public override void OnHurt(int AttackType){
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
		if(CenterInfo.actorManager.enemyActor.actorVO.isAttack){
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
				setAnimation(actorVO.die,false,false);
				CenterInfo.game.GameEnd();
			}
			if(hurtBlood>0){
				CenterInfo.uigame.ShowFlyText(hurtBlood.ToString(),new Vector3(-110,216,20));
			}
		}
	}

	public int OnAttack(){
		bool isHitPoint = CenterInfo.audioManager.isEnemyAttack;
		if(!actorVO.isDead){
			if(CenterInfo.audioManager.isBeat || isHitPoint){
				if(!actorVO.isNormalAttack){
					CenterInfo.game.gameData.isBeatTouch = true;
					setAnimation(actorVO.attack_2,false,true);
					attackType = 2;
				}else{
					CenterInfo.game.gameData.isBeatTouch = false;
					attackType = 0;
				}
			}else{
				CenterInfo.game.gameData.isBeatTouch = false;
				attackType = NormalAttack();
			}
		}else{
			attackType = -1;
		}
		return attackType;
	}


	private int NormalAttack(){
		if(!actorVO.isNormalAttack){
			setAnimation(actorVO.attack_1,false,false);
			attackType = 1;
		}else{
			attackType = 0;
		}
		return attackType;
	}

	protected override void OnStateComplete(Spine.AnimationState state,int trackIndex,int loop){
		base.OnStateComplete (state,trackIndex,loop);
	}
}

