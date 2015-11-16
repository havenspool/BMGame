using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UITextTip : MonoBehaviour {
	
	private Text tipTxt;
	private int frame;
	private int AllFrame = 40;
	private float scaleXY = 1f;
	private bool isShow;

	void Awake(){
		tipTxt = transform.FindChild ("Text").GetComponent<Text>();
	}
	
	void Start(){
		ShowTip ("LOVE");
	}

	void Update () {
		if (isShow) {
			if (frame<=AllFrame) {
				frame ++;
				if(frame%(AllFrame+1)>0){
					scaleXY = frame%AllFrame/AllFrame;
				}else{
					scaleXY = 1;
				}
				SetScale (scaleXY);
			}
		}
	}

	public void ShowTip(string tip){
		isShow = true;
		frame = 0;
		scaleXY = 1f;
		gameObject.SetActive (true);
		tipTxt.text = tip; 
		SetScale (0);
	}
	
	public void StopTip(){
		isShow = false;
		frame = 0;
		scaleXY = 1f;
		gameObject.SetActive (false);
	}
	
	private void SetScale(float s){
		transform.localScale = new Vector3 (1,s,1);
	}
}