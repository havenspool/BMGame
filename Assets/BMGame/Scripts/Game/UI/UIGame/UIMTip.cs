using UnityEngine;
using System.Collections;

public class UIMTip : MonoBehaviour {
	
	private bool isYes;
	private float allWidth = 670f;
	private float yesTime = -1;
	private Transform tMovie;//UMovie
	private Transform runMovie;
	private Transform yesMovie;
	private Transform noMovie;
	private bool isBeatShow;
	public ArrayList list = new ArrayList();
	public ArrayList touchList = new ArrayList();
	private Transform tipContainer;

	void Awake(){
		tipContainer = transform.Find ("TipContainer");
		runMovie = transform.Find("RunMovie");
		yesMovie = tipContainer.Find("YesMovie");
		tMovie = tipContainer.Find("TMovie");
		noMovie= tipContainer.Find("NoMovie");
	}

	void FixedUpdate () {
		if (CenterInfo.game.gameData.isGameFight) {
			if(CenterInfo.actorManager.heroActor && CenterInfo.actorManager.heroActor.isBlasting){
				ClearList();
				ClearTouchList();
				CenterInfo.audioManager.aBeatTimer = 0;
				return;
			}
			RectTransform rt = (RectTransform)runMovie.transform;
			rt.anchoredPosition = Vector3.right * CenterInfo.audioManager.mAdudio.GetFourBRate () * allWidth;
			if(!CenterInfo.audioManager.isBeatNoLength){
				if (CenterInfo.audioManager.mAdudio.IsFourSingle ()) {
					if (CenterInfo.audioManager.isMusicAttackAfter) {
						if (!isBeatShow) {
							isBeatShow = true;
							CreateT();
							CenterInfo.audioManager.AddNextAttackTime();
						}
					} else {
						isBeatShow = false;
					}
					hasShowTip = true;
					CenterInfo.game.gameData.isBeatTouch = false;
				} else {
					if(hasShowTip){
						hasShowTip = false;
						CenterInfo.audioManager.aBeatTimer = 0;
						GotoTipNo();
					}
					if (CenterInfo.audioManager.isMusicAttackAfter) {
						if (!isBeatShow) {
							isBeatShow = true;
							if(!isYes){
								CenterInfo.audioManager.AddNextAttackTime();
							}
							isYes = false;
							yesTime = CenterInfo.audioManager.GetRateTime();
						}
					}else{
						isYes = false;
						isBeatShow = false;
					}
				}
			}
			if(CenterInfo.audioManager.mAdudio.GetFourBRate()>0.95f){
				if (!CenterInfo.audioManager.mAdudio.IsFourSingle ()) {
					ClearList();
					SetRandomBeatId();
				}
				ClearTouchList();
				CenterInfo.audioManager.aBeatTimer = 0;
			}
		}
	}

	public void  OnShowYes(){
		if (transform.gameObject.activeInHierarchy) {
			isYes = true;
			CreateYes();
			yesTime = CenterInfo.audioManager.GetRateTime();
			CenterInfo.audioManager.AddNextAttackTime();
		}
//		if(CenterInfo.game.gameData.isBeatTouch){
//			if(!isYes){
//				isYes = true;
//			}
//			CenterInfo.game.gameData.isBeatTouch = false;
//		}
	}

	private bool hasShowTip = true;
	private void CreateT(){
		CenterInfo.audioManager.mSound.PlayTipSound ();
		RectTransform t = (RectTransform)GameObject.Instantiate (tMovie);
		t.gameObject.SetActive(true);
		t.SetParent(yesMovie.parent);
		t.anchoredPosition = Vector3.right * allWidth * CenterInfo.audioManager.GetRateTime();
		t.localPosition = new Vector3(t.localPosition.x,0,0);
		t.localScale = Vector3.one;
		list.Add(t.GetComponent<UMovie>());
	}

	private void CreateNo(){
		CenterInfo.audioManager.mSound.PlayTipSound ();
		RectTransform t = (RectTransform)GameObject.Instantiate (noMovie);
		t.gameObject.SetActive(true);
		t.SetParent(yesMovie.parent);
		t.anchoredPosition = Vector3.right * allWidth * CenterInfo.audioManager.GetRateTime();
		t.localPosition = new Vector3(t.localPosition.x,0,0);
		t.localScale = Vector3.one;
		touchList.Add(t);
	}

	private void CreateYes(){
		RectTransform t = (RectTransform)GameObject.Instantiate (yesMovie);
		t.gameObject.SetActive(true);
		t.SetParent(yesMovie.parent);
		t.anchoredPosition = Vector3.right * allWidth * CenterInfo.audioManager.GetRateTime();
		t.localPosition = new Vector3(t.localPosition.x,0,0);
		t.localScale = Vector3.one;
		touchList.Add(t);
	}

	private void SetRandomBeatId(){
		CenterInfo.audioManager.ResetBeat((int)(CenterInfo.audioManager.mAdudio.beatListCount * Random.value));
	}

	private void GotoTipNo(){
		if(list.Count>0){
			for(int i = 0;i<list.Count;i++){
				UMovie t = (UMovie)list[i];
				t.GotoAndStop(2);
			}
		}
	}

	public void Clear(){
		ClearList ();
		ClearTouchList ();
		CenterInfo.audioManager.Clear ();
	}

	private void ClearList(){
		if(list.Count>0){
			for(int i = 0;i<list.Count;i++){
				UMovie t = (UMovie)list[i];
				Destroy(t.gameObject);
			}
			list.Clear();
		}
	}

	private void ClearTouchList(){
		if(touchList.Count>0){
			for(int i = 0;i<touchList.Count;i++){
				RectTransform t = (RectTransform)touchList[i];
				Destroy(t.gameObject);
			}
			touchList.Clear();
		}
	}
}
