using UnityEngine;
using System.Collections;

public class UIHitMark : MonoBehaviour {
	private SkeletonAnimation skeleton;
	private enum AState{idle,cool,bad,miss};
	private int beatTime;
	private AState state;

	void Awake(){
		skeleton = GetComponent<SkeletonAnimation> ();
	}

	void Start(){
		state = AState.idle;
		beatTime = CenterInfo.audioManager.aBeatTimer;
	}

	void Update () {
		if (transform.localPosition.x > -100) {
			float f = 650 /(5.1f*CenterInfo.audioManager.mAdudio.fourBTime);
			transform.Translate (Vector3.left*Time.deltaTime*f,Space.Self);
			if (!CenterInfo.audioManager.mAdudio.IsFourSingle ()) {
				if(CenterInfo.audioManager.aBeatTimer>=beatTime){
					ShowMissAnimation();
				}
			}
		} else {
			Destroy (gameObject);
		}
	}

	public void ShowHit(){
		if (CenterInfo.audioManager.aBeatTimer == beatTime-1) {
			ShowCoolAnimation();
		}
	}

	public void ShowPerfect(){
		if (CenterInfo.audioManager.aBeatTimer == beatTime-1) {
			ShowCoolAnimation();
		}
	}

//	private void ShowPerfectAnimation(){
//		if (state == AState.idle) {
//			state = AState.cool;
//			skeleton.state.SetAnimation (1, "perfect", false);
//		}
//	}

	private void ShowCoolAnimation(){
		if (state == AState.idle) {
			state = AState.cool;
			skeleton.state.SetAnimation (1, "cool", false);
		}
	}

	private void ShowMissAnimation(){
		if (state == AState.idle) {
			state = AState.miss;
			skeleton.state.SetAnimation (1, "miss", false);
		}
	}

	private void ShowIdleAnimation(){
		state = AState.idle;
		skeleton.state.SetAnimation (1, "idle", false);
	}

}
