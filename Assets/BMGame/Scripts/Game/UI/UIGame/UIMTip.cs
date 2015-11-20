using UnityEngine;
using System.Collections;

public class UIMTip : MonoBehaviour {

	private float allWidth = 670f;
	private bool isYes;
	private float yesTime = -1;
	private Transform tMovie;//UMovie
	private Transform runMovie;
	private Transform yesMovie;
	private Transform noMovie;
	private bool isBeatShow;
	private bool isBAttack = false;
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
			RectTransform rt = (RectTransform)runMovie.transform;
			rt.anchoredPosition = Vector3.right * CenterInfo.audioManager.mAdudio.GetFourBRate () * allWidth;
			if (CenterInfo.audioManager.mAdudio.IsFourSingle ()) {
				if (CenterInfo.audioManager.isAttackBeat()) {
					if (!isBeatShow) {
						isBeatShow = true;
						CreateT();
					}
				} else {
					isBeatShow = false;
				}
				CenterInfo.game.gameData.isBeatTouch = false;
			} else {
				if(CenterInfo.game.gameData.isBeatTouch){
					if(!isYes){
						CreateYes();
						isYes = true;
						yesTime = CenterInfo.audioManager.GetRateTime();
					}
					CenterInfo.game.gameData.isBeatTouch = false;
				}
				if (!CenterInfo.audioManager.isAttackBeat()&&isBAttack) {
					if(yesTime!=CenterInfo.audioManager.GetRateTime()){
						CreateNo();
						CenterInfo.game.gameData.isBeatTouch = false;
					}
					isYes = false;
					yesTime = -1;
				}
			}
			isBAttack = CenterInfo.audioManager.isAttackBeat();
			if(CenterInfo.audioManager.mAdudio.GetFourBRate()>0.95f){
				if (!CenterInfo.audioManager.mAdudio.IsFourSingle ()) {
					if(list.Count>0){
						for(int i = 0;i<list.Count;i++){
							RectTransform t = (RectTransform)list[i];
							Destroy(t.gameObject);
						}
						list.Clear();
						SetRandomBeatId();
					}
				}
				if(touchList.Count>0){
					for(int i = 0;i<touchList.Count;i++){
						RectTransform t = (RectTransform)touchList[i];
						Destroy(t.gameObject);
					}
					touchList.Clear();
				}
			}
		}
	}

	private void CreateT(){
		CenterInfo.audioManager.mSound.PlayTipSound ();
		RectTransform t = (RectTransform)GameObject.Instantiate (tMovie);
		t.gameObject.SetActive(true);
		t.SetParent(yesMovie.parent);
		t.anchoredPosition = Vector3.right * allWidth * CenterInfo.audioManager.GetRateTime();
		t.localPosition = new Vector3(t.localPosition.x,0,0);
		t.localScale = Vector3.one;
		list.Add(t);
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
		CenterInfo.audioManager.PlaySound (CenterInfo.audioManager.GetBeatSoundName());
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

	public void Clear(){
		if(list.Count>0){
			for(int i = 0;i<list.Count;i++){
				RectTransform t = (RectTransform)list[i];
				Destroy(t.gameObject);
			}
			list.Clear();
		}
		if(touchList.Count>0){
			for(int i = 0;i<touchList.Count;i++){
				RectTransform t = (RectTransform)touchList[i];
				Destroy(t.gameObject);
			}
			touchList.Clear();
		}
	}
}
