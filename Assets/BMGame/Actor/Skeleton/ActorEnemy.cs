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
			isBlasting = CenterInfo.actorManager.isBlasting();
			if(CenterInfo.audioManager.mAdudio.IsBeatCenter()){
				if(actorVO.isCanIdle){
					SetAnimationIdle();
				}
			}
			if(isBlasting){
				return;
			}
			isFSingle = CenterInfo.audioManager.mAdudio.IsFourSingle ();
			if(!isFSingle){
				CenterInfo.audioManager.mAdudio.isShowTip = false;
				if (CenterInfo.audioManager.isMusicAttackAfter && !CenterInfo.audioManager.isBeatNoLength) {
					if(!isHurt && !isBo){
						isBo = true;
						isAttack = true;
						setAnimation(actorVO.attackNormal,false,true);
						CenterInfo.uigame.uiMusicTip.OnShowTip(2);
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
				if(CenterInfo.audioManager.mAdudio.IsBeatCenter() && !CenterInfo.audioManager.isBeatNoLength){
//					OnShowWarningAnimation();
				}
				if(CenterInfo.audioManager.mAdudio.isShowTip){
					CenterInfo.audioManager.mAdudio.isShowTip = false;
					OnShowWarningAnimation();
				}
			}
		}
	}

	public void OnShowWarningAnimation(){
		if(!actorVO.isAttack && !actorVO.isHurt){
			CenterInfo.audioManager.PlaySound (MSound.TIPS);
			setAnimation(actorVO.warning,false,true);
		}
	}

	public void onAttack(){
		setAnimation(actorVO.attackNormal,false,true);
	}

	public void onPowStart(){
		setAnimation(actorVO.powStart,false,true);
	}
	public void onPowEnd(){
		setAnimation(actorVO.powEnd,false,true);
		OnHurt (3);
	}

	public override void OnHurt(int AttackType){
		if(!isHurt){
			isAttack = false;
			isHurt = true;
			float laterTimer = CenterInfo.audioManager.getBeatTime;
			if((AttackType == 3 || AttackType==2&&!isFSingle) && !CenterInfo.audioManager.isBeatNoLength ){
				laterTimer = laterTimer*1/3f;
				setAnimation(actorVO.hurt,false,true);
			}else{
				isHurt = false;
				if(CenterInfo.audioManager.isBeat){
					laterTimer = laterTimer*1/3f;
				}else{
					laterTimer = laterTimer*1/3f;
				}
			}
			StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => {
				isHurt = false;
				float hurtBlood = 0f;
				if(actorVO.blood>0){
					if(AttackType==1||AttackType==3){
						hurtBlood = actorVO.mActorVO.HurtNoBeat(CenterInfo.actorManager.heroActor.actorVO.attackBlood);
						actorVO.blood -=hurtBlood;
					}else if(AttackType==2){
						if(!isFSingle){
							hurtBlood = actorVO.mActorVO.HurtBroken(CenterInfo.actorManager.heroActor.actorVO.attackBlood);
						}else{
							hurtBlood = actorVO.mActorVO.HurtBeat(CenterInfo.actorManager.heroActor.actorVO.attackBlood);
						}
						actorVO.blood -=hurtBlood;
					}
				}
				if(actorVO.blood<=0){
					actorVO.blood = 0;
					setAnimation(actorVO.die,false,false);
					CenterInfo.game.GameEnemyDead();
				}
				setColor(1,1,1,1);
				CenterInfo.uigame.ShowFlyText(hurtBlood.ToString(),new Vector3(110,216,20));
			},laterTimer));
			setColor(1,250/255,250/255,0.9f);
		}
	} 
}

