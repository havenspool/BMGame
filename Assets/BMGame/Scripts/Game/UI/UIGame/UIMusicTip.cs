using UnityEngine;
using System.Collections;

public class UIMusicTip : MonoBehaviour {
	
	public Transform hitMark;
	public SkeletonAnimation skeletonTipBg;
	public SkeletonAnimation skeletonWord;
	private bool isBeatShow = false;
	public ArrayList list = new ArrayList();

	void Awake(){}

	void Start () {
		isBeatShow = false;
		skeletonWord.gameObject.SetActive (false);
	}

	void FixedUpdate () {
		if (CenterInfo.game.gameData.isGameFight) {
			if(CenterInfo.actorManager.heroActor && CenterInfo.actorManager.heroActor.isBlasting){
				ClearList();
				CenterInfo.audioManager.aBeatTimer = 0;
				return;
			}
			if (!CenterInfo.audioManager.isBeatNoLength) {
				if (CenterInfo.audioManager.mAdudio.IsFourSingle ()) {
					if (CenterInfo.audioManager.isMusicAttackAfter) {
						if (!isBeatShow) {
							isBeatShow = true;
							CenterInfo.audioManager.mAdudio.isShowTip = true;
							CreateT ();
							CenterInfo.audioManager.AddNextAttackTime ();
						}
					} else {
						isBeatShow = false;
					}
				} else {
					isBeatShow = false;
					if (CenterInfo.audioManager.isMusicAttackAfter) {
						CenterInfo.audioManager.AddNextAttackTime ();
					}
				}
			}
			if (CenterInfo.audioManager.mAdudio.GetFourBRate () > 0.95f) {
				if (!CenterInfo.audioManager.mAdudio.IsFourSingle ()) {
					SetRandomBeatId ();
				}
				CenterInfo.audioManager.aBeatTimer = 0;
			}
		}
	}

	private void SetRandomBeatId(){
		CenterInfo.audioManager.ResetBeat((int)(CenterInfo.audioManager.mAdudio.beatListCount * Random.value));
	}

	private void CreateT(){
		Transform t = GameObject.Instantiate (hitMark);
		t.gameObject.SetActive(true);
		t.SetParent(hitMark.parent);
		t.localPosition = new Vector3(800,0,0);
		t.localScale = Vector3.one*100;
		list.Add(t.GetComponent<UIHitMark>());
	}

	public void OnAttack(){
		skeletonTipBg.Reset();
		skeletonTipBg.state.SetAnimation(1,"attack",false);
	}

	public void  OnShowYes(){
		if(list.Count>0){
			for(int i = 0;i<list.Count;i++){
				UIHitMark t = (UIHitMark)list[i];
				t.ShowHit ();
			}
		}
		OnShowTip (1);
	}

	public void OnShowPerfect(){
		if(list.Count>0){
			for(int i = 0;i<list.Count;i++){
				UIHitMark t = (UIHitMark)list[i];
				t.ShowPerfect ();
			}
		}
		OnShowTip (3);
	}

	public void Clear(){
		ClearList ();
		CenterInfo.audioManager.Clear ();
	}

	public void OnShowTip(int state){
		skeletonWord.gameObject.SetActive (true);
		skeletonWord.Reset();
		if (state == 0) {
			skeletonWord.state.SetAnimation(1,"bad",false);
		} else if (state == 1) {
			skeletonWord.state.SetAnimation(1,"cool",false);
		} else if (state == 2) {
			skeletonWord.state.SetAnimation(1,"miss",false);
		}else if (state == 3) {
			skeletonWord.state.SetAnimation(1,"perfect",false);
		}
	}
	
	private void ClearList(){
		if(list.Count>0){
			for(int i = 0;i<list.Count;i++){
				UIHitMark t = (UIHitMark)list[i];
				if(t != null){
					Destroy(t.gameObject);
				}
			}
			list.Clear();
		}
	}
}
