using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class ActorManager : MonoBehaviour {

	public ActorEnemy enemyActor;
	public ActorHero heroActor;

	void Awake(){
		ClearEnemy ();
		CenterInfo.actorManager = this;
	}

	public void OnFrame(){
		if (null != enemyActor && enemyActor.actorVO != null) {
			CenterInfo.uigame.EnemyBlood(enemyActor.actorVO.rateBlood);
		}
		if (null != heroActor && heroActor.actorVO != null) {
			CenterInfo.uigame.HeroBlood(heroActor.actorVO.rateBlood);
		}
	}

	public void OnUpdate(){
		if (null != enemyActor) {
			enemyActor.OnUpdate();
		}
		if (null != heroActor) {
			heroActor.OnUpdate();
		}
	}
	
	public void OnHeroHurt(int type){
		heroActor.OnHurt(type);
	}
	
	public void OnHeroAttack(){
		if (CenterInfo.game.gameData.isGameFight) {
			int type = heroActor.OnAttack();
			if(type>1){
				enemyActor.OnHurt(type);
			}
		}
	}

	public void ResetAllActor(){
		ResetShowEnemy();
		ResetShowHero();
	}
	
	public void ResetShowEnemy(){
		ClearEnemy ();
		GameObject go = AssetManager.CreateGameObject("Enemy/"+CenterInfo.game.gameData.thisWaveName);
		go.transform.SetParent(transform);
		go.transform.localPosition = new Vector3(0,0,-20);
		go.transform.localScale = new Vector3(1,1,1);
		enemyActor = go.GetComponent<ActorEnemy>();
		enemyActor.setSpeed(CenterInfo.audioManager.GetScaleTime());
		CenterInfo.game.mxml.SetBeatList (enemyActor.actorName);
	}

	public void ClearEnemy(){
		if(enemyActor){
			Destroy(enemyActor.gameObject);
			enemyActor = null;
		}
	}

	public void ResetShowHero(){
		if(heroActor){
			Destroy(heroActor.gameObject);
		}
		GameObject go = AssetManager.CreateGameObject("Hero");
		go.transform.SetParent(transform);
		go.transform.localPosition = new Vector3(0,0,-20);
		go.transform.localScale = new Vector3(1,1,1);
		heroActor = go.GetComponent<ActorHero>();
	}
}
