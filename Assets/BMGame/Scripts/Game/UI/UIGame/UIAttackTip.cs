using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIAttackTip : MonoBehaviour {

	private int frame;
	private int AllFrame = 20;
	private float scaleXY = 1f;
	private bool isShow;

	void Start(){
		ShowTip ();
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

	private void SetScale(float s){
		transform.localScale = new Vector3 (s,s,s);
	}
}
