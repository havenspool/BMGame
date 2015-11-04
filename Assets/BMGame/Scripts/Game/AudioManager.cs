using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class AudioManager : MonoBehaviour {

	private MTime musicTime;
	private AudioSource audioSoure;

	void Awake(){
		CenterInfo.audioManager = this;
		MTime.OffSetStartTime = 0.373f;
		audioSoure = GetComponent<AudioSource>();
		musicTime = new MTime ();
		musicTime.resetTime ();
		audioSoure.Play();
	}

	public bool isBeat{
		get{
			return isBeatFrist();
		}
	}

	public bool isBeatFrist(){
		bool bo = false;
		float leftSe =getLeftSeconds();
		if(Util.CF (leftSe,1) < 0.2f){
			bo = true;
		}
		return bo;
	}
	
	public bool isBeatCenter(){
		bool bo = false;
		float leftSe =getLeftSeconds();
		if(Util.CF (leftSe,1)== Util.CF (musicTime.beatTime/2,1)){
			bo = true;
		}
		return bo;
	}

	public bool isBeatEnd(){
		bool bo = false;
		float leftSe =getLeftSeconds();
		float dd = musicTime.beatTime-0.2f;
		if(Util.CF(leftSe,1) > Util.CF(dd,1)){
			bo = true;
		}
		return bo;
	}

	public float getLeftSeconds(){
		float ff = Util.CF(audioSoure.time,3)-MTime.OffSetStartTime;
		float leftSe = ff%musicTime.beatTime;
		return leftSe;
	}

	public float getBeatTime{
		get{
			return musicTime.beatTime;
		}
	}

	public float getScaleTime(){
		return musicTime.beatScale;
	}
}
