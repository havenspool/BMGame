using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class MTime{
	
	public static float OffSetStartTime = 0;//0.373f;
	private float normalBPM = 120;//40-180
	private float bpm = 128;  //60;//

	private float startTime;
	private float tTime;
	private float fTime;

	public void ResetTime(){
		startTime = GetThisTime();
	}

	public float beatScale{
		get{
			return bpm/normalBPM;
		}
	}

	public float fourBTime{
		get{
			return beatTime*5;
		}
	}

	public float beatTime{//= 60f/128f;
		get{
			return 60/bpm;
		}
	}
	
	public float fixMusicTime{
		get{
			float fix = thisTime - startTime - OffSetStartTime;
			if(fix<0)fix = 0;
			return Util.CF(fix,3);
		}
	}

	public float thisTime{
		get{
			return GetThisTime();
		}
	}
	private float GetThisTime(){
		tTime = Time.fixedTime/Time.timeScale;
		tTime = Util.CF (tTime,3);
		return tTime;
	}


}
