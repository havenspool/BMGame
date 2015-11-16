using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UITopTip : MonoBehaviour {
	
	private int frame;
	private int AllFrame = 20;
	private float scaleXY = 1f;
	private bool isShow;
	
	void Start(){
		ShowTip ();
	}

	void Update () {
		if (isShow) {
			if (frame<=AllFrame) {
				frame ++;
				if(frame%10<5){
					scaleXY = 1f;
				}else{
					scaleXY = 1.1f;
				}
				SetScale (scaleXY);
			}
		}
	}

	public void ShowTip(){
		isShow = true;
		frame = 0;
		scaleXY = 1f;
		gameObject.SetActive (true);
	}
	
	public void StopTip(){
		isShow = false;
		frame = 0;
		scaleXY = 1f;
		gameObject.SetActive (false);
	}

	private void SetScale(float s){
		transform.localScale = new Vector3 (s,s,s);
	}
}
