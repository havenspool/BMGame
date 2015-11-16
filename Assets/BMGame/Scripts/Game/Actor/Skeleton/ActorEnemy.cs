using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class ActorEnemy : Actor{

//	private int  ii = 0;
//	private int  attackNum = 0;
	private bool isHurt = false;
	
	protected override void init(){
		base.init();
		isAutoForAttack2 = false;
		actorVO = new EnemyVO();
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
			if(!CenterInfo.audioManager.mAdudio.IsFourSingle ()){
				if (CenterInfo.audioManager.isEnemyAttack) {
					if(!isHurt){
						setNoLAnimation(CenterInfo.audioManager.GetEnemyAttack(),false,true);
					}
				}
			}
		}
	}

	public override void OnHurt(int AttackType){
		if(!isHurt){
			isHurt = true;
			float laterTimer = CenterInfo.audioManager.getBeatTime;
			bool isHitPoint = CenterInfo.audioManager.isEnemyAttack;
			if(isHitPoint && AttackType==2){
				isHurt = false;
				laterTimer = laterTimer*1/3f;
				setAnimation(CenterInfo.audioManager.GetEnemyHurt(),false,true);
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
					CenterInfo.game.GameNext();
				}
				CenterInfo.uigame.ShowFlyText(hurtBlood.ToString(),new Vector3(110,216,20));
			},laterTimer));
		}
	}

}

