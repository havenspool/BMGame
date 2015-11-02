using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class ActorHero : Actor{

	protected override void init(){
		base.init();
		actorVO = new HeroVO();
	}

	void Start (){
		
	}
	
	void FixedUpdate () {
		
	}

	public override void OnHurt(int AttackType){

	}

}

