using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class AudioManager : MonoBehaviour {

	public AudioClip[] bgMusics;

	private int oneRateBeat = 4;

	[HideInInspector]
	public int aBeatTimer = -1;

	private AudioSource audioSoure;
	private MAudio _mAdudio;
	private MSound _mSound;

	public MAudio mAdudio{
		get{
			if(null == _mAdudio){
				_mAdudio = new MAudio ();
			}
			return _mAdudio;
		}
	}
	public MSound mSound{
		get{
			if(null == _mSound){
				_mSound = new MSound ();
			}
			return _mSound;
		}
	}

	public void PlayBeatSound(){
		mSound.PlayABeatSound ();
	}
	public void PlaySound(string name){
		mSound.PlaySound (name);
	}

	void Awake(){
		CenterInfo.audioManager = this;
		MTime.OffSetStartTime = 0;//0.373f;
		audioSoure = GetComponent<AudioSource>();
	}

	private AudioClip bgMusic(){
		AudioClip ac = bgMusics[0];
		string name = CenterInfo.actorManager.enemyActor.actorName;
		if (name == "SlimeS") {
			ac = bgMusics[0];
		} else if (name == "SlimeM") {
			ac = bgMusics[1];
		} else if (name == "SlimeL") {
			ac = bgMusics[2];
		}
		return ac;
	}

	public void ResetBeat(int id){
		if (Random.value > mAdudio.getMBeatList().randomWait) {
			mAdudio.SetBeatId (id);
		} else {
			mAdudio.SetBeatId (-1);
		}
		aBeatTimer = -1;
	}

	public void AudioRePlay(){
		audioSoure.clip = bgMusic ();
		mAdudio.ResetTime ();
		AudioPlay ();
	}
	public void AudioPlay(){
		audioSoure.Play();
	}
	public void AudioStop(){
		audioSoure.Stop ();
	}

	public float GetScaleTime(){
		return mAdudio.GetScaleTime();
	}

	public bool isBeatNoLength{
		get{
			if(mAdudio.beatList.Length>1){
				return false;
			}else{
				return true;
			}
		}
	}

	public bool isMusicAttack{
		get{
			return mAdudio.IsRateTime(GetRateTime());
		}
	}

	public bool isMusicPerfet{
		get{
			return mAdudio.IsRatePerfetTime(GetRateTime());
		}
	}

	public bool isMusicAttackAfter{
		get{
			return mAdudio.IsRateAfterTime(GetRateTime());
		}
	}

	public string GetBeatSoundName(){
		float aType = GetAType ();
		if (aType == 1) {
			return "BEAT1";	
		} else if (aType == 2) {
			return "BEAT1_2";	
		}else if (aType == 4) {
			return "BEAT1_4";	
		}else if (aType == 4) {
			return "BEAT1_8";	
		}
		return "BEAT1";
	}

	public float GetAType(){
		float aType = 0;
		int t = aBeatTimer;
		if(t>=mAdudio.beatList.Length){
			t = mAdudio.beatList.Length-1;
		}
		if (t <= 0) {
			t = 0;
		}
		if (null != mAdudio.beatList [t]) {
			aType = float.Parse(mAdudio.beatList[t]);
		}
		return aType;
	}

	public float GetRateTime(){
		float rateTime = 0;
		for(var i=0;i<aBeatTimer;i++){
			rateTime +=1/float.Parse(mAdudio.beatList[i]);
		}
		return rateTime / oneRateBeat;
	}

	public int AddNextAttackTime(){
		aBeatTimer = aBeatTimer + 1;
		if(aBeatTimer>=mAdudio.beatList.Length){
			aBeatTimer = mAdudio.beatList.Length;
		}
		if (aBeatTimer <= 0) {
			aBeatTimer = 0;
		}
		return aBeatTimer;
	}

	private float GetRateTime(float t){
		float rateTime = 0;
		if (t < 0) {
			t = 0;
		}
		if (t > mAdudio.beatList.Length) {
			t = mAdudio.beatList.Length;
		}
		for(var i=0;i<t;i++){
			rateTime +=1/float.Parse(mAdudio.beatList[i]);
		}
		return  Util.CF (rateTime/ oneRateBeat, 3);
	}

	public bool isBeat{
		get{
			return mAdudio.isBeat;
		}
	}

	public float getBeatTime{
		get{
			return mAdudio.getBeatTime;
		}
	}

	public void Clear(){
		aBeatTimer = -1;
	}

}
