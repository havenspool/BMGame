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
			if(attackTime<=0){
				attackTime = 1;
			}
			float rateTime = float.Parse(_mAudio.beatList[attackTime])/4;
			Debug.Log(rateTime);
			return _mAudio.IsRateTime(rateTime);
		}

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
