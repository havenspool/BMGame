using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class ActorBase : MonoBehaviour {

	protected SkeletonAnimation skeletonAnimation;

	protected string currentAnimation;

	protected void init(){
		skeletonAnimation = gameObject.GetComponent<SkeletonAnimation>();
	}

	protected void addEvent(){
		skeletonAnimation.state.Event +=OnStateEvent;
		skeletonAnimation.state.Start +=OnStateStart;
		skeletonAnimation.state.End += OnStateEnd;
		skeletonAnimation.state.Complete +=OnStateComplete;
	}

	protected void setAnimation(string name,bool loop){
		if(currentAnimation != name){
			currentAnimation = name;
			skeletonAnimation.Reset();
			skeletonAnimation.loop = loop;
			skeletonAnimation.AnimationName = name;
			skeletonAnimation.state.SetAnimation(0,name,loop);
		}
	}

	protected bool isAnimationName(string name){
		return currentAnimation == name;
	}

	protected virtual void OnStateEvent(Spine.AnimationState state,int trackIndex,Spine.Event e){}
	protected virtual void OnStateStart(Spine.AnimationState state,int trackIndex){}
	protected virtual void OnStateEnd(Spine.AnimationState state,int trackIndex){}
	protected virtual void OnStateComplete(Spine.AnimationState state,int trackIndex,int loop){}

}
