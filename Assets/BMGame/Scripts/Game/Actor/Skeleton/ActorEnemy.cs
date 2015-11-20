using UnityEngine;
using System.Collections;

/**jski*/
public class ActorEnemy : Actor{

	public string actorName;
	private bool isHurt = false;
	private bool isFSingle = false;
	private bool isAttack;
	private bool isBo;
	
	protected override void init(){
		isAutoForAttack2 = false;
		base.init();
	}

	void Start (){
		addEvent();
		actorVO = new EnemyVO(actorName);
		setSpeed(CenterInfo.audioManager.GetScaleTime());
	}

	public void OnUpdate () {
		if(!CenterInfo.game.gameData.isGameOver){
			isFSingle = CenterInfo.audioManager.mAdudio.IsFourSingle ();
			if(!isFSingle){
				if(CenterInfo.audioManager.mAdudio.IsBeatCenter()){
					if(!actorVO.isAttack && !actorVO.isHurt){
						setAnimation(actorVO.idle,true,false);
					}
				}
				if (CenterInfo.audioManager.isMusicAttack) {
					if(!isHurt && !isBo){
						isBo = true;
						isAttack = true;
						setAnimation(CenterInfo.audioManager.GetMusicAttack(),false,true);
						StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => {
							if(isAttack){
								CenterInfo.actorManager.OnHeroHurt(1);
							}
						},0.1f));
					}
				}else{
					isBo = false;
				}
			}else{
				if(CenterInfo.audioManager.mAdudio.IsBeatCenter()){
					if(!actorVO.isAttack && !actorVO.isHurt){
						setAnimation(actorVO.ready,false,false);
					}
				}
			}
		}
	}

	public override void OnHurt(int AttackType){
		if(!isHurt){
			isAttack = false;
			isHurt = true;
			float laterTimer = CenterInfo.audioManager.getBeatTime;
			if(AttackType==2&&!isFSingle){
				laterTimer = laterTimer*1/3f;
				setAnimation(CenterInfo.audioManager.GetEnemyHurt(),false,true);
			}else{
				isHurt = false;
				if(CenterInfo.audioManager.isBeat){
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
						hurtBlood = actorVO.mActorVO.HurtNoBeat(CenterInfo.actorManager.heroActor.actorVO.attack);
						actorVO.blood -=hurtBlood;
					}else if(AttackType==2){
						if(!isFSingle){
							hurtBlood = actorVO.mActorVO.HurtBroken(CenterInfo.actorManager.heroActor.actorVO.attack);
						}else{
							hurtBlood = actorVO.mActorVO.HurtBeat(CenterInfo.actorManager.heroActor.actorVO.attack);
						}
						actorVO.blood -=hurtBlood;
						
					}
				}
				if(actorVO.blood<=0){
					actorVO.blood =0;
					setAnimation(actorVO.die,false,false);
					CenterInfo.game.GameEnemyDead();
				}
				CenterInfo.uigame.ShowFlyText(hurtBlood.ToString(),new Vector3(110,216,20));
			},laterTimer));
		}
	}
}

