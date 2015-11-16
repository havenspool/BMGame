using UnityEngine;
using System.Collections;

public class UIMTip : MonoBehaviour {

	private float allWidth = 498f;
	private UMovie tMovie;
	private UMovie runMovie;
	private UMovie yesMovie;
	private UMovie noMovie;
	private bool isBeatShow;
	public ArrayList list = new ArrayList();
	public ArrayList touchList = new ArrayList();

	void Awake(){
		runMovie = transform.Find("RunMovie").GetComponent<UMovie>();
		yesMovie = transform.Find("YesMovie").GetComponent<UMovie>();
		tMovie = transform.Find("TMovie").GetComponent<UMovie>();
		noMovie= transform.Find("NoMovie").GetComponent<UMovie>();
	}

	void FixedUpdate () {

		if (!CenterInfo.game.gameData.isGameStop) {
			RectTransform rt = (RectTransform)runMovie.transform;
			rt.anchoredPosition = Vector3.right * CenterInfo.audioManager.mAdudio.GetFourBRate () * allWidth;
			
			if (CenterInfo.audioManager.mAdudio.IsFourSingle ()) {
				if(touchList.Count>0){
					CenterInfo.audioManager.attackTime = 0;
					for(int i = 0;i<touchList.Count;i++){
						RectTransform t = (RectTransform)touchList[i];
						Destroy(t.gameObject);
					}
					touchList.Clear();
					if(list.Count>0){
						for(int i = 0;i<list.Count;i++){
							RectTransform t = (RectTransform)list[i];
							Destroy(t.gameObject);
						}
						list.Clear();
					}
				}
				CenterInfo.audioManager.attackTime = list.Count+0;
				if (CenterInfo.audioManager.isEnemyAttack) {
					if (!isBeatShow) {
						isBeatShow = true;
						CreateT();
					}
				} else {
					isBeatShow = false;
				}
			} else {
				CenterInfo.audioManager.attackTime = touchList.Count+0;
				if (CenterInfo.audioManager.isEnemyAttack) {
					if(CenterInfo.game.gameData.isBeatTouch){
						if (!isBeatShow) {
							isBeatShow = true;
							CreateYes();
						}
					}else{
						if (!isBeatShow) {
							isBeatShow = true;
							CreateNo();
						}
					}
				}else{
					isBeatShow = false;
				}
			}
			if (CenterInfo.audioManager.isEnemyAttack) {
				runMovie.GotoAndStop (1);
			} else {
				runMovie.GotoAndStop (0); 
			}
		}
	}

	private void CreateT(){
		RectTransform t = (RectTransform)GameObject.Instantiate (tMovie).transform;
		t.gameObject.SetActive(true);
		t.SetParent(yesMovie.transform.parent);
		t.anchoredPosition = Vector3.right * allWidth * CenterInfo.audioManager.GetRateTime();
		t.localPosition = new Vector3(t.localPosition.x,0,0);
		t.localScale = Vector3.one;
		list.Add(t);
	}

	private void CreateNo(){
		RectTransform t = (RectTransform)GameObject.Instantiate (noMovie).transform;
		t.gameObject.SetActive(true);
		t.SetParent(yesMovie.transform.parent);
		t.anchoredPosition = Vector3.right * allWidth * CenterInfo.audioManager.GetRateTime();
		t.localPosition = new Vector3(t.localPosition.x,0,0);
		t.localScale = Vector3.one;
		touchList.Add(t);
	}

	private void CreateYes(){
		RectTransform t = (RectTransform)GameObject.Instantiate (yesMovie).transform;
		t.gameObject.SetActive(true);
		t.SetParent(yesMovie.transform.parent);
		t.anchoredPosition = Vector3.right * allWidth * CenterInfo.audioManager.GetRateTime();
		t.localPosition = new Vector3(t.localPosition.x,0,0);
		t.localScale = Vector3.one;
		touchList.Add(t);
	}


}
