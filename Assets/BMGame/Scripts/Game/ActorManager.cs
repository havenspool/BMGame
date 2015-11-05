using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class ActorManager : MonoBehaviour {

	public ActorEnemy enemyActor;
	public ActorHero heroActor;

	void Awake(){
		CenterInfo.actorManager = this;
	}

	void Update(){
		CenterInfo.uigame.EnemyBlood(enemyActor.actorVO.rateBlood);
		CenterInfo.uigame.HeroBlood(heroActor.actorVO.rateBlood);
	}

	public void OnHeroHurt(int type){
		heroActor.OnHurt(type);
	}
	
	public void OnHeroAttack(){
		int type = heroActor.OnAttack(enemyActor.isHitAttackPoint());
		if(type>0){
			enemyActor.OnHurt(type);
		}
	}

	public void ResetAllActor(){
		ResetShowEnemy();
		ResetShowHero();
	}
	
	public void ResetShowEnemy(){
		if(enemyActor){
			Destroy(enemyActor.gameObject);
		}
		GameObject go = AssetManager.CreateGameObject("Enemy");
		go.transform.SetParent(transform);
		go.transform.localPosition = new Vector3(0,0,-20);
		go.transform.localScale = new Vector3(1,1,1);
		enemyActor = go.GetComponent<ActorEnemy>();
		enemyActor.setSpeed(CenterInfo.audioManager.GetScaleTime());
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
