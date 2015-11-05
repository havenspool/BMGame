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
		RectTransform rt = (RectTransform)runMovie.transform;
		rt.anchoredPosition = Vector3.right * CenterInfo.audioManager.GetFourBRate () * allWidth;

		if (CenterInfo.audioManager.IsFourSingle ()) {
			if (CenterInfo.audioManager.isBeat) {
				if (!isBeatShow) {
					isBeatShow = true;
					RectTransform t = (RectTransform)GameObject.Instantiate (tMovie).transform;
					t.gameObject.SetActive(true);
					t.SetParent(yesMovie.transform.parent);
					t.anchoredPosition = Vector3.right * allWidth*list.Count/4;
					t.localPosition = new Vector3(t.localPosition.x,0,0);
					t.localScale = Vector3.one;
					list.Add(t);
				}
			} else {
				isBeatShow = false;
			}
			if(touchList.Count>0){
				for(int i = 0;i<touchList.Count;i++){
					RectTransform t = (RectTransform)touchList[i];
					Destroy(t.gameObject);
				}
				touchList.Clear();
			}
		} else {
			if(list.Count>0){
				for(int i = 0;i<list.Count;i++){
					RectTransform t = (RectTransform)list[i];
					Destroy(t.gameObject);
				}
				list.Clear();
			}
			
			if (CenterInfo.audioManager.isBeat) {
				if(CenterInfo.game.gameData.isBeatTouch){
					if (!isBeatShow) {
						isBeatShow = true;
						RectTransform t = (RectTransform)GameObject.Instantiate (yesMovie).transform;
						t.gameObject.SetActive(true);
						t.SetParent(yesMovie.transform.parent);
						t.anchoredPosition = Vector3.right * allWidth*touchList.Count/4;
						t.localPosition = new Vector3(t.localPosition.x,0,0);
						t.localScale = Vector3.one;
						touchList.Add(t);
					}
				}else{
					if (!isBeatShow) {
						isBeatShow = true;
						RectTransform t = (RectTransform)GameObject.Instantiate (noMovie).transform;
						t.gameObject.SetActive(true);
						t.SetParent(yesMovie.transform.parent);
						t.anchoredPosition = Vector3.right * allWidth*touchList.Count/4;
						t.localPosition = new Vector3(t.localPosition.x,0,0);
						t.localScale = Vector3.one;
						touchList.Add(t);
					}
				}
			}else{
				isBeatShow = false;
			}
		}

		if (CenterInfo.audioManager.isBeat) {
			runMovie.GotoAndStop (1);
		} else {
			runMovie.GotoAndStop (0); 
		}

	}

}
