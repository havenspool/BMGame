using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class ActorManager : MonoBehaviour {

	public EnemyMActor enemyActor;
	public HeroMActor heroActor;

	void Awake(){
		CenterInfo.actorManager = this;
	}

//	void FixedUpdate () {}

	void Update(){
		CenterInfo.uigame.EnemyBlood(enemyActor.actorVO.RateBlood);
		CenterInfo.uigame.HeroBlood(heroActor.actorVO.RateBlood);
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
		enemyActor = go.GetComponent<EnemyMActor>();
		enemyActor.setSpeed(CenterInfo.audioManager.getScaleTime());
	}

	public void ResetShowHero(){
		if(heroActor){
			Destroy(heroActor.gameObject);
		}
		GameObject go = AssetManager.CreateGameObject("Hero");
		go.transform.SetParent(transform);
		go.transform.localPosition = new Vector3(0,0,-20);
		go.transform.localScale = new Vector3(1,1,1);
		heroActor = go.GetComponent<HeroMActor>();
		heroActor.setSpeed(CenterInfo.audioManager.getScaleTime());
	}
}
