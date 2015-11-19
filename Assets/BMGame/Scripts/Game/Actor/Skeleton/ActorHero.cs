using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class ActorHero : Actor{

	public string actorName;
	private int attackType= 0;

	protected override void init(){
		isAutoForAttack2 = true;
		base.init();
		actorVO = new HeroVO(actorName);
	}

	void Start (){
		addEvent();
		setSpeed(CenterInfo.audioManager.GetScaleTime());
	}

	public void OnUpdate () {
		if(!CenterInfo.game.gameData.isGameOver){
			if(CenterInfo.audioManager.mAdudio.IsBeatCenter()){
				if(!actorVO.isAttack && !actorVO.isHurt){
					setAnimation(actorVO.idle,true,false);
				}
			}
		}
	}
	
	public override void OnHurt(int AttackType){
//		if(!isHurtClick && AttackType>0){
//			isHurtClick = true;
//			float laterTimer = CenterInfo.audioManager.getBeatTime;
//			if(AttackType==1){
//				laterTimer = laterTimer*2/3f;
//			}else if(AttackType==2){
//				laterTimer = laterTimer*1/12f;
//			}else if(AttackType==4){
//				laterTimer = laterTimer*1/1024f;
//			}
//			StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => {
//				hurtTBlood(AttackType);
//			},laterTimer));
//		}
		hurtTBlood(AttackType);
	}

	private void hurtTBlood(int AttackType){
		if(CenterInfo.actorManager.enemyActor.actorVO.isAttack){
			float hurtBlood = actorVO.mActorVO.HurtNoBeat(CenterInfo.actorManager.enemyActor.actorVO.attack);
			if(actorVO.blood-hurtBlood>0){
				actorVO.blood -=hurtBlood;
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
		bool isHitPoint = CenterInfo.audioManager.isMusicAttack;
		if(!actorVO.isDead){
			if(CenterInfo.audioManager.isBeat || isHitPoint){
				if(!actorVO.isNormalAttack){
					if(isHitPoint){
						CenterInfo.game.gameData.isBeatTouch = true;
						setAnimation(CenterInfo.audioManager.GetMusicAttack(),false,true);
					}else{
						setAnimation(actorVO.attackBeat,false,true);
					}
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
			setAnimation(actorVO.attackNormal,false,false);
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

