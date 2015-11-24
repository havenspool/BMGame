using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/**
 * jski
 */
public class UIStart : MonoBehaviour {

	public Text text;

	void Start(){
		text.text = "";//Application.persistentDataPath;
	}

	public void OnStartClick(){
		Application.LoadLevel("BMGame");
	}

}
