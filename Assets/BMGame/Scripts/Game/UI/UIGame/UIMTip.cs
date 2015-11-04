using UnityEngine;
using System.Collections;

public class UIMTip : MonoBehaviour {

	private UMovie tMovie;
	private UMovie runMovie;
	private UMovie yesMovie;
	private UMovie noMovie;

	void Awake(){
		tMovie = transform.Find("TMovie").GetComponent<UMovie>();
		runMovie = transform.Find("RunMovie").GetComponent<UMovie>();
		yesMovie = transform.Find("YesMovie").GetComponent<UMovie>();
		noMovie= transform.Find("NoMovie").GetComponent<UMovie>();
	}

}
