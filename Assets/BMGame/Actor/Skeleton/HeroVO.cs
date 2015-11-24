using UnityEngine;
using System.Collections;

public class HeroVO : ActorVO {

	public HeroVO(string name):base(){
		mActorVO = CenterInfo.game.gameData.mxml.GetMActorVO (name);
		ResetBlood(mActorVO.blood);
	}

//	public override string attackNormal{
//		get{
//			return "miss";//14f 0.467s
//		}
//	}
}
