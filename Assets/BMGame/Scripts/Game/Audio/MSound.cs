using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class MSound{

	private EventInstance abeatSound;
	public void PlayABeatSound(){
		if (null == abeatSound) {
			abeatSound = FMOD_StudioSystem.instance.GetEvent("event:/"+SoudName.A_BEAT);
		}
		abeatSound.start ();
	}

	private EventInstance aTipSound;
	public void PlayTipSound(){
		if (null == aTipSound) {
			aTipSound = FMOD_StudioSystem.instance.GetEvent("event:/"+SoudName.A_TIP);
		}
		aTipSound.start ();
	}

	private EventInstance beatSound1;
	public void PlayBeatSound1(){
		if (null == beatSound1) {
			beatSound1 = FMOD_StudioSystem.instance.GetEvent("event:/"+SoudName.BEAT1);
		}
		beatSound1.start ();
	}

	private EventInstance beatSound12;
	public void PlayBeatSound12(){
		if (null == beatSound12) {
			beatSound12 = FMOD_StudioSystem.instance.GetEvent("event:/"+SoudName.BEAT1_2);
		}
		beatSound12.start ();
	}

	private EventInstance beatSound14;
	public void PlayBeatSound14(){
		if (null == beatSound14) {
			beatSound14 = FMOD_StudioSystem.instance.GetEvent("event:/"+SoudName.BEAT1_4);
		}
		beatSound14.start ();
	}

	private EventInstance beatSound18;
	public void PlayBeatSound18(){
		if (null == beatSound18) {
			beatSound18 = FMOD_StudioSystem.instance.GetEvent("event:/"+SoudName.BEAT1_8);
		}
		beatSound18.start ();
	}

	private EventInstance touchSound;
	public void PlayTouchSound(){
		if (null == touchSound) {
			touchSound = FMOD_StudioSystem.instance.GetEvent("event:/"+SoudName.TOUCH);
		}
		touchSound.start ();
	}


	public void PlaySound(string name){
		if (name == SoudName.BEAT1) {
			PlayBeatSound1 ();
		} else if (name == SoudName.BEAT1_2) {
			PlayBeatSound12();
		}else if (name == SoudName.BEAT1_4) {
			PlayBeatSound14();
		}else if (name == SoudName.BEAT1_8) {
			PlayBeatSound18();
		}else if (name == SoudName.A_BEAT) {
			PlayABeatSound();
		}else if (name == SoudName.TOUCH) {
			PlayTouchSound();
		}
	}
}

class SoudName{

	public static string A_BEAT = "A_BEAT";

	public static string A_TIP = "A_TIP";

	public static string BEAT1 = "BEAT1";

	public static string BEAT1_2 = "BEAT1_2";

	public static string BEAT1_4 = "BEAT1_4";

	public static string BEAT1_8 = "BEAT1_8";

	public static string TOUCH = "TOUCH";
}

