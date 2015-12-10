using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class ActorHero : Actor{

	public string actorName;
	private int attackType= 0;

	private float blastingTime = 0;
	private float allBlasting = 60*10;

	protected override void init(){
		isAutoForAttack2 = true;
		base.init();
	}

	void Start (){
		addEvent();
		actorVO = new HeroVO(actorName);
		setSpeed(CenterInfo.audioManager.GetScaleTime());
	}

	public void OnUpdate () {
		if (!CenterInfo.game.gameData.isGameOver) {
			if (CenterInfo.audioManager.mAdudio.IsBeatCenter ()) {
				if (actorVO.isCanIdle) {
					SetAnimationIdle();
				}
			}
			if(null != actorVO){
				if (isBlasting) {
					blastingTime ++;
					if (blastingTime > allBlasting) {
						PowerEnd();
						setAnimation(actorVO.powEnd,false,false);
						CenterInfo.actorManager.OnEnemyPowerEnd();
					}else{
						Debug.Log((allBlasting-blastingTime) / allBlasting);
						actorVO.power = (float)((allBlasting-blastingTime) / allBlasting) * actorVO.allPower;
					}
				}else{
					if(actorVO.ratePower>=1){
						isBlasting = true;
						blastingTime = 0;
						setAnimation(actorVO.powStart,false,false);
						CenterInfo.actorManager.OnEnemyPowerStart();
					}
				}
			}
		} else {
			isBlasting = false;
		}
	}

	public void PowerEnd(){
		isBlasting = false;
		blastingTime = 0;
		actorVO.power = 0;
	}
	
	public override void OnHurt(int AttackType){
		hurtTBlood(AttackType);
	}

	private void hurtTBlood(int AttackType){
		if(CenterInfo.actorManager.enemyActor.actorVO.isAttack){
			float hurtBlood = actorVO.mActorVO.HurtNoBeat(CenterInfo.actorManager.enemyActor.actorVO.attackBlood);
			if(actorVO.blood-hurtBlood>0){
				actorVO.blood -=hurtBlood;
			}else{
				actorVO.blood =0;
				setAnimation(actorVO.die,false,false);
				CenterInfo.game.GameEnd();
			}
			if(hurtBlood>0){
//				setColor(1,155/255,155/255,1);
				setAnimation(actorVO.hurt,false,true);
				CenterInfo.uigame.ShowFlyText(hurtBlood.ToString(),new Vector3(-110,216,20));
			}
			StartCoroutine(DelayToInvoke.DelayToInvokeDo(() => {
				setColor(1,1,1,1);
			},0.5f));
		}
	}

	public int OnAttack(){
		bool isHitPoint = CenterInfo.audioManager.isMusicAttack;
		if(!actorVO.isDead){
			CenterInfo.uigame.uiMusicTip.OnAttack();
			if(isBlasting){
				attackType = 3;
				CenterInfo.audioManager.PlaySound (MSound.ATTACK);
				SetPowAttack();
				return attackType;
			}
			if(CenterInfo.audioManager.isBeat || isHitPoint){
				if(CenterInfo.audioManager.mAdudio.IsFourSingle () || CenterInfo.audioManager.isBeatNoLength){//CenterInfo.audioManager.mAdudio.beatList.Length<=1
					if(CenterInfo.audioManager.isBeat){
						CenterInfo.audioManager.PlaySound (MSound.ATTACK);
						setAnimation(actorVO.attackNormal,false,true);
						attackType = 2;
					}else{
						CenterInfo.game.gameData.isBeatTouch = false;
						CenterInfo.audioManager.PlaySound (MSound.MISS);
						setAnimation(actorVO.attackMiss,false,false);
						attackType = 0;
					}
				}else{
					if(isHitPoint){
						CenterInfo.game.gameData.isBeatTouch = true;
						CenterInfo.audioManager.PlaySound (MSound.BEATHit);
						if(CenterInfo.audioManager.isMusicPerfet){
							actorVO.addPower(10);
							setAnimation(actorVO.attackBeat,false,true);
							CenterInfo.uigame.uiMusicTip.OnShowPerfect();
						}else{
							actorVO.addPower(1);
							setAnimation(actorVO.attackBeat,false,true);
							CenterInfo.uigame.uiMusicTip.OnShowYes();
						}
						CenterInfo.uigame.uiMTip.OnShowYes();
						attackType = 2;
					}else{
						CenterInfo.game.gameData.isBeatTouch = false;
						CenterInfo.audioManager.PlaySound (MSound.MISS);
						CenterInfo.uigame.uiMusicTip.OnShowTip(0);
						setAnimation(actorVO.attackMiss,false,false);
						attackType = 0;
					}
				}
			}else{
				if(CenterInfo.audioManager.mAdudio.IsFourSingle ()|| CenterInfo.audioManager.isBeatNoLength){
					CenterInfo.audioManager.PlaySound (MSound.MISS);
					setAnimation(actorVO.attackMiss,false,false);
				}else{
					CenterInfo.uigame.uiMusicTip.OnShowTip(0);
					CenterInfo.audioManager.PlaySound (MSound.BEATHit);
					setAnimation(actorVO.hurt,false,true);
					CenterInfo.actorManager.OnEnemyAttack();
					hurtTBlood(0);
				}
				CenterInfo.game.gameData.isBeatTouch = false;
				attackType = 0;
			}
		}else{
			attackType = -1;
		}
		return attackType;
	}

	protected override void OnStateComplete(Spine.AnimationState state,int trackIndex,int loop){
		base.OnStateComplete (state,trackIndex,loop);
	}
}

