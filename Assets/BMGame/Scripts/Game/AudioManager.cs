using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class AudioManager : MonoBehaviour {

	public AudioClip[] bgMusics;

	[HideInInspector]
	public int attackTime = 1;
	[HideInInspector]
	public int AttackBeatTimer = -1;

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
		MTime.OffSetStartTime = 0.373f;
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
		AttackBeatTimer = -1;
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

	public bool isMusicAttack{
		get{
			return mAdudio.IsRateTime(GetRateTime());
		}
	}

	public bool isNextEnemyAttack{
		get{
			return mAdudio.IsRateTime(GetNextRateTime());
		}
	}

	public string GetMusicAttack(){
		float aType = GetAType ();
		if (aType == 1) {
			return "1b";	
		} else if (aType == 2) {
			return "1_2b";	
		}else if (aType == 4) {
			return "1_4b";	
		}
		return "idle";
	}

	public string GetEnemyHurt(){
		float aType = GetAType ();
		if (aType == 1) {
			return "h1b";	
		} else if (aType == 2) {
			return "h1_2b";	
		}else if (aType == 4) {
			return "h1_4b";	
		}
		return "idle";
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
		int t = AttackBeatTimer;// - 1
		if(t>=mAdudio.beatList.Length){
			t = mAdudio.beatList.Length-1;
		}
		if (t <= 0) {
			t = 0;
		}
		float aType = float.Parse(mAdudio.beatList[t]);
		return aType;
	}

	public float GetNextAType(){
		int t = GetNextAttackTime ()- 1;
		if (t <= 0) {
			t = 0;
		}
		if(t>=mAdudio.beatList.Length){
			t = mAdudio.beatList.Length-1;
		}
		float aType = float.Parse(mAdudio.beatList[t]);
		return aType;
	}

	public float GetNextRateTime(){
		float rateTime = 0;
		for(var i=0;i<GetNextAttackTime();i++){
			rateTime +=1/float.Parse(mAdudio.beatList[i]);
		}
		return (rateTime+1) / oneRateBeat;
	}

	public float GetRateTime(){
		float rateTime = 0;
		for(var i=0;i<AttackBeatTimer;i++){
			rateTime +=1/float.Parse(mAdudio.beatList[i]);
		}
		return (rateTime+1) / oneRateBeat;
	}

	private int oneRateBeat = 5;

	public int GetAttackTime(){
		if(attackTime>=mAdudio.beatList.Length){
			attackTime = mAdudio.beatList.Length-1;
		}
		if (attackTime <= 0) {
			attackTime = 0;
		}
		return attackTime;
	}

	public int GetNextAttackTime(){
		int t = attackTime + 1;
		if(t>=mAdudio.beatList.Length){
			t = mAdudio.beatList.Length;
		}
		if (t <= 0) {
			t = 1;
		}
		return t;
	}

	public bool isAttackBeat(){
		int lg = mAdudio.beatList.Length;
		float r = mAdudio.GetFourBRate();
		if (lg > 1) {
			for (int i =0; i<lg; i++) {
				float f = GetRateTime (i);
				if (r > f - 0.02f && r < f + 0.01f) {
					AttackBeatTimer = i;
					return true;
				}
			}
		} else {
			AttackBeatTimer=-1;
		}
		return false;
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
		return  Util.CF ((rateTime+1) / oneRateBeat, 3);
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
}
