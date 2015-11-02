using UnityEngine;
using System.Collections;


public class FPS : MonoBehaviour {
	
	private int count = 0;
	private float lt = 0;
	private int fcount = 0;
	private float flt = 0;
	
	private int fps = 0;
	private int fixedFps = 0;
	
	// Use this for initialization
	void Start () {
		lt = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		count++;
		if(count >= 60){
			count = 0;
			float dt = Time.realtimeSinceStartup - lt;
			fps = (int)Mathf.Round(60/dt);
			lt = Time.realtimeSinceStartup;
			UpdateText();
		}
	}
	
	void UpdateText(){
		this.GetComponent<GUIText>().text = "FPS:" + fps + " | " + fixedFps;
	}
	
	void FixedUpdate(){
		fcount++;
		if(fcount >= 60){
			fcount = 0;
			float dt = Time.realtimeSinceStartup - flt;
			fixedFps = (int)Mathf.Round(60/dt);
			flt = Time.realtimeSinceStartup;
			UpdateText();
		}
	}
}
