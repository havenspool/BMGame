using UnityEngine;
using System.Collections;

public class HeroVO : ActorVO {

	public HeroVO(string name):base(name){
		mActorVO = CenterInfo.game.gameData.mxml.GetMActorVO (name);
		ResetBlood(mActorVO.blood);
	}


}
