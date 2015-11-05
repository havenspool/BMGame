using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class AudioManager : MonoBehaviour {

	private MTime mTime;
	private AudioSource audioSoure;

	void Awake(){
		CenterInfo.audioManager = this;
		MTime.OffSetStartTime = 0.373f;
		audioSoure = GetComponent<AudioSource>();
		mTime = new MTime ();
		mTime.resetTime ();
		audioSoure.Play();
	}

	public bool isBeat{
		get{
			return IsBeatFrist();
		}
	}
	public float getBeatTime{
		get{
			return mTime.beatTime;
		}
	}
	
	public float GetScaleTime(){
		return mTime.beatScale;
	}

	public float GetFBeenSeconds(){
		return mTime.fixMusicTime % mTime.fourBTime;
	}
	
	public float GetBeenSeconds(){
		return mTime.fixMusicTime%mTime.beatTime;
	}

	public bool IsBeatFrist(){
		if(Util.CF (GetBeenSeconds(),1) <= 0.1f){
			return true;
		}
		return false;
	}
	
	public bool IsBeatCenter(){
		float beenBTime =GetBeenSeconds();
		if(Util.CF (beenBTime,1)== Util.CF (mTime.beatTime/2,1)){
			return true;
		}
		return true;
	}

	public bool IsBeatEnd(){
		if(Util.CF(GetBeenSeconds(),1) >= Util.CF(mTime.beatTime-0.2f,1)){
			return true;
		}
		return true;
	}

	public bool IsFourBFirst(){
		if(Util.CF (GetFBeenSeconds(),1) <= 0.2f){
			return true;
		}
		return true;
	}

	public bool IsFourBEnd(){
		if(Util.CF (GetFBeenSeconds(),1) >= Util.CF(mTime.fourBTime-0.2f,1)){
			return true;
		}
		return false;
	}

	//0-1
	public bool IsFourBRate(float rate){
		if (Mathf.Abs (GetFourBRate()-rate) < 0.1f) {
			return true;
		}
		return false;
	}

	public bool IsFourSingle(){
		if (GetFBeatTime() % 2 == 1) {
			return false;
		}
		return true;
	}

	public float GetFourBRate(){
		return Util.CF (GetFBeenSeconds () / mTime.fourBTime, 3);
	}

	public int GetFBeatTime(){
		return (int)(mTime.fixMusicTime/mTime.fourBTime);
	}
}
