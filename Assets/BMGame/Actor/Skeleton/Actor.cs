using UnityEngine;
using System.Collections;

/**
 * jski
 */
public class Actor : MonoBehaviour,IActor{

	[HideInInspector]
	public bool isAutoForAttack2 =false;
	private float sr = 1;
	private float sg = 1;
	private float sb = 1;
	private float sa = 1;
	
	public bool isBlasting= false;//爆气

	void Awake(){
		init();
	}
	
	public ActorVO actorVO;
	protected SkeletonAnimation skeletonAnimation;
	public virtual void OnHurt(int AttackType){}
	
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
			skeletonAnimation.state.SetAnimation(1,name,loop);
		}
	}
	protected void setNoLAnimation(string name,bool loop,bool isForce){
		if(actorVO.currentAnimation != name || isForce){
			skeletonAnimation.Reset();
			skeletonAnimation.state.ClearTracks();
			addEvent();
			actorVO.currentAnimation = name;
			skeletonAnimation.state.SetAnimation(1,name,loop);
		}
	}

	//actor.setColor(155/255,1,1,1);
	public void setColor(float r,float g,float b,float a){
		sr = r;
		sg = g;
		sb = b;
		sa = a;
		resetColor ();
	}
	
	private void resetColor(){
		skeletonAnimation.skeleton.R = sr;
		skeletonAnimation.skeleton.G = sg;
		skeletonAnimation.skeleton.B = sb;
		skeletonAnimation.skeleton.A = sa;
	}

	public void AnimationStop(){
		skeletonAnimation.valid = false;
	}

	public void AnimationPlay(){
		skeletonAnimation.valid = true;
	}

	protected void SetAnimationIdle(){
		if(isBlasting){
			setAnimation (actorVO.powIdle, true, false);
		}else{
			setAnimation (actorVO.idle, true, false);
		}
	}

	protected void SetPowAttack(){
		if (actorVO.currentAnimation != actorVO.powStart || actorVO.currentAnimation != actorVO.powEnd) {
			if (actorVO.currentAnimation == actorVO.powAttack1) {
				setAnimation (actorVO.powAttack2, false, true);
			} else {
				setAnimation(actorVO.powAttack1,false,true);
			}
		}
	}

	public void setSpeed(float speed){
		skeletonAnimation.timeScale = speed;
	}

	protected bool isAnimationName(string name){
		return actorVO.currentAnimation == name;
	}
	
	protected virtual void OnStateEvent(Spine.AnimationState state,int trackIndex,Spine.Event e){}
	protected virtual void OnStateComplete(Spine.AnimationState state,int trackIndex,int loop){
		if(actorVO.currentAnimation != actorVO.die && actorVO.currentAnimation != actorVO.warning && actorVO.currentAnimation != actorVO.idle&& actorVO.currentAnimation != actorVO.powIdle){
			SetAnimationIdle();
		}
	}
	protected virtual void OnStateStart(Spine.AnimationState state,int trackIndex){}
	protected virtual void OnStateEnd(Spine.AnimationState state,int trackIndex){

	}
}

