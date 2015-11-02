using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class ActorEnemy : Actor{

	protected override void init(){
		base.init();
		actorVO = new EnemyVO();
	}

	void Start (){
	
	}

	void FixedUpdate () {
		
	}
}

