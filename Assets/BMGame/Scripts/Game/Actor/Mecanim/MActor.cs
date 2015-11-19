using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class MActor : MonoBehaviour {
	
	public Animator animator;

	private ActorVO _actorVO;
	public ActorVO actorVO{
		get{
			if(null ==_actorVO){
				_actorVO = new ActorVO("");
			}
			return _actorVO;
		}
	}

	protected AnimatorStateInfo animatorStateInfo{
		get{
			return animator.GetCurrentAnimatorStateInfo(0);
		}
	}

	public void setSpeed(float speed){
		animator.speed = speed;
	}
}
