using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class AudioManager : MonoBehaviour {

	private AudioSource audioSoure;
	public int attackTime = 1;
	private MAudio _mAudio;

	public MAudio mAdudio{
		get{
			return _mAudio;
		}
	}

	void Awake(){
		CenterInfo.audioManager = this;
		MTime.OffSetStartTime = 0.373f;
		audioSoure = GetComponent<AudioSource>();
		_mAudio = new MAudio ();
		_mAudio.ResetTime ();
		audioSoure.Play();
	}

	public float GetScaleTime(){
		return _mAudio.GetScaleTime();
	}

	public bool isEnemyAttack{
		get{
			return _mAudio.IsRateTime(GetRateTime());
		}
	}

	public bool isNextEnemyAttack{
		get{
			return _mAudio.IsRateTime(GetNextRateTime());
		}
	}

	public string GetEnemyAttack(){
		float aType = GetAType ();
		if (aType == 1) {
			return "attack_1";	
		} else if (aType == 2) {
			return "attack_1-2";	
		}else if (aType == 4) {
			return "attack_1-4";	
		}else if (aType == 8) {
			return "attack_1-8";	
		}
		return "idle";
	}

	public string GetEnemyHurt(){
		float aType = GetAType ();
		if (aType == 1) {
			return "hurt_1";	
		} else if (aType == 2) {
			return "hurt_1-2";	
		}else if (aType == 4) {
			return "hurt_1-4";	
		}else if (aType == 8) {
			return "hurt_1-4";	
		}
		return "idle";
	}

	public float GetAType(){
		int t = GetAttackTime () - 1;
		if (t <= 0) {
			t = 0;
		}
		if(t>=_mAudio.beatList.Length){
			t = _mAudio.beatList.Length-1;
		}
		float aType = float.Parse(_mAudio.beatList[t]);
		return aType;
	}

	public float GetNextAType(){
		int t = GetNextAttackTime ()- 1;
		if (t <= 0) {
			t = 0;
		}
		if(t>=_mAudio.beatList.Length){
			t = _mAudio.beatList.Length-1;
		}
		float aType = float.Parse(_mAudio.beatList[t]);
		return aType;
	}

	public float GetNextRateTime(){
		float rateTime = 0;
		for(var i=0;i<GetNextAttackTime();i++){
			rateTime +=1/float.Parse(_mAudio.beatList[i]);
		}
		return rateTime / 4;
	}

	public float GetRateTime(){
		float rateTime = 0;
		for(var i=0;i<GetAttackTime();i++){
			rateTime +=1/float.Parse(_mAudio.beatList[i]);
		}
		return rateTime / 4;
	}

	public int GetAttackTime(){
		if(attackTime>=_mAudio.beatList.Length){
			attackTime = _mAudio.beatList.Length-1;
		}
		if (attackTime <= 0) {
			attackTime = 0;
		}
		return attackTime;
	}

	public int GetNextAttackTime(){
		int t = attackTime + 1;
		if(t>=_mAudio.beatList.Length){
			t = _mAudio.beatList.Length;
		}
		if (t <= 0) {
			t = 1;
		}
		return t;
	}

	public bool isBeat{
		get{
			return _mAudio.isBeat;
		}
	}

	public float getBeatTime{
		get{
			return _mAudio.getBeatTime;
		}
	}
}
