using UnityEngine;
using System.Collections;
using FMOD;
public class MAudio{

	private MTime mTime;
	private MXML mxml;

	public MAudio(){
		mTime = new MTime();
		mxml = CenterInfo.game.gameData.mxml;
	}

	public int beatListCount{
		get{
			return mxml.listCount;
		}
	}

	public void SetBeatId(int id){
		mxml.listI = id;
	}

	public string[] beatList{
		get{
			if(GetFBeatTime()<2){
				SetBeatId(-1);
			}
			return mxml.GetBeatList();

		}
	}

	public void ResetTime(){
		mTime.ResetTime ();
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
		if(Util.CF (GetBeenSeconds(),1) <= 0.2f){
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
	
	//true false
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

	//0-1
	public float GetFourBRate(){
		return Util.CF (GetFBeenSeconds () / mTime.fourBTime, 3);
	}
	
	private int GetFBeatTime(){
		return (int)(mTime.fixMusicTime/mTime.fourBTime);
	}

	public bool IsRateTime(float rateTime){
		if ((GetFBeenSeconds() > mTime.fourBTime * rateTime - 0.1f) && (GetFBeenSeconds() < mTime.fourBTime * rateTime + 0.1f)) {
			return true;
		}
		return false;
	}



}
