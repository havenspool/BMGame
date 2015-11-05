using UnityEngine;
using System.Collections;

/**
 * jski
 */
public class Actor : MonoBehaviour,IActor{

	void Awake(){
		init();
	}
	
	public ActorVO actorVO;

	public virtual void OnHurt(int AttackType){}
	
	protected SkeletonAnimation skeletonAnimation;
	
	protected virtual void init(){
		skeletonAnimation = gameObject.GetComponentInChildren<SkeletonAnimation>();
	}
	
	protected void addEvent(){
		skeletonAnimation.state.Event +=OnStateEvent;
		skeletonAnimation.state.Start +=OnStateStart;
		skeletonAnimation.state.End += OnStateEnd;
		skeletonAnimation.state.Complete +=OnStateComplete;
	}
	
	protected void setAnimation(string name,bool loop,bool isForce){
		if(actorVO.currentAnimation != name || isForce){
			skeletonAnimation.Reset();
			addEvent();
			actorVO.currentAnimation = name;
//			skeletonAnimation.loop = loop;
//			skeletonAnimation.AnimationName = name;
			skeletonAnimation.state.SetAnimation(1,name,loop);
		}
	}
	public void AnimationStop(){
		skeletonAnimation.valid = false;
	}

	public void AnimationPlay(){
		skeletonAnimation.valid = true;
	}

	public void setSpeed(float speed){
		skeletonAnimation.timeScale = speed;
	}

	protected bool isAnimationName(string name){
		return actorVO.currentAnimation == name;
	}
	
	protected virtual void OnStateEvent(Spine.AnimationState state,int trackIndex,Spine.Event e){}
	protected virtual void OnStateComplete(Spine.AnimationState state,int trackIndex,int loop){
		if(actorVO.currentAnimation == actorVO.attack_1){
			setAnimation(actorVO.attack_2,false,false);
			actorVO.currentAnimation = actorVO.attack_11;
		}else{
			setAnimation(actorVO.idle,true,false);
		}
	}
	protected virtual void OnStateStart(Spine.AnimationState state,int trackIndex){}
	protected virtual void OnStateEnd(Spine.AnimationState state,int trackIndex){

	}
}

