using UnityEngine;
using System.Collections;

public class HeroVO : ActorVO {

	public HeroVO(string name):base(){
		allPower = 100;
		mActorVO = CenterInfo.game.gameData.mxml.GetMActorVO (name);
		ResetBlood(mActorVO.blood);
	}



}
