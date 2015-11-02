using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/**
 * jski
 */
public class FlyText : MonoBehaviour {

	private Text flyText;

	void Awake(){
		flyText = GetComponent<Text>();
		Destroy(this.gameObject,0.4f);
	}


	void Update(){
		flyText.transform.Translate(new Vector3(0,0.5f,0));
	}

	public void ShowText(string txt){
		flyText.text = txt;
	}
}
