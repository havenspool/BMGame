using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class AudioManager : MonoBehaviour {

	private float normalBPM = 120;//40-180
	private float bpm = 128;  
	private float bpmSe;// = 60f/128f;

	private float offsetStartTime = 0.373f;

	private AudioSource audioSoure;
	private FMOD.Studio.EventInstance engine;

//	FMOD_StudioEventEmitter emitter;
//	private FMOD.Studio.ParameterInstance enginRPM;

	private int position;

	void Awake(){
		CenterInfo.audioManager = this;
	}
	
	void Start () {
		audioSoure = GetComponent<AudioSource>();
		audioSoure.Play();
//		emitter = GetComponent<FMOD_StudioEventEmitter>();
//		engine = FMOD_StudioSystem.instance.GetEvent("event:/add");
//		engine.start();
//		engine.getParameter("Timeline", out enginRPM);
//		engine.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
//		FMOD_StudioSystem.instance.PlayOneShot("event:/add",transform.position);
	}
//	void FixedUpdate(){
//		if(engine != null){
//			engine.getTimelinePosition(out position);
//		}
//		engineRPM.setValue(rpm);
//		enginRPM.setValue(1.0f);
//	}
//	void OnDisable()
//	{
//		engine.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
//		engine.release();
//	}
//	public bool isActionBeat{
//		get{
//			bool bo = isBeatFrist();
//			if(!bo){
//				bo = isBeatEnd();
//			}
//			return bo;
//		}
//	}

	public bool isBeat{
		get{
			return isBeatFrist();
		}
	}

	public bool isBeatFrist(){
		bool bo = false;
		float leftSe =getLeftSeconds();
		if(float.Parse(leftSe.ToString("f1")) < 0.2f){
			bo = true;
		}
		return bo;
	}
	
	public bool isBeatCenter(){
		bool bo = false;
		float leftSe =getLeftSeconds();
		if(leftSe.ToString("f1") == (bpmSe/2).ToString("f1")){
			bo = true;
		}
		return bo;
	}

	public bool isBeatEnd(){
		bool bo = false;
		float leftSe =getLeftSeconds();
		float dd = bpmSe-0.2f;
		if(float.Parse(leftSe.ToString("f1")) > float.Parse(dd.ToString("f1"))){
			bo = true;
		}
		return bo;
	}

	public float getLeftSeconds(){
		float ff = float.Parse(audioSoure.time.ToString("f3"))-offsetStartTime;//position.ToString("f3"))-offsetStartTime;//
		float leftSe = ff%getBeatTime;
		return leftSe;
	}

	public float getScaleTime(){
		float st = bpm/normalBPM;
		return st;
	}

	public float getBeatTime{
		get{
			bpmSe = 60f/bpm;
			return bpmSe;
		}
	}
}
