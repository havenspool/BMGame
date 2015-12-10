using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class MSound{

	public static string BEATHit = "BeatHit";
	public static string ATTACK = "Attack";
	public static string TIPS = "Tips";
	public static string HURT = "Hurt";
	public static string HERODIE = "HeroDie";
	public static string DIE = "Die";
	public static string MISS = "Miss";
	
	private EventInstance aNormalSound;
	public void PlayANormalSound(){
		if (null == aNormalSound) {
			aNormalSound = FMOD_StudioSystem.instance.GetEvent("event:/"+ATTACK);
		}
		aNormalSound.start ();
	}

	private EventInstance abeatSound;
	public void PlayABeatSound(){
		if (null == abeatSound) {
			abeatSound = FMOD_StudioSystem.instance.GetEvent("event:/"+BEATHit);
		}
		abeatSound.start ();
	}

	private EventInstance aTipSound;
	public void PlayTipSound(){
		if (null == aTipSound) {
			aTipSound = FMOD_StudioSystem.instance.GetEvent("event:/"+TIPS);
		}
		aTipSound.start ();
	}

	private EventInstance hurtSound;
	public void PlayHurtSound(){
		if (null == hurtSound) {
			hurtSound = FMOD_StudioSystem.instance.GetEvent("event:/"+HURT);
		}
		hurtSound.start ();
	}

	private EventInstance heroDieSound;
	public void PlayHeroDieSound(){
		if (null == heroDieSound) {
			heroDieSound = FMOD_StudioSystem.instance.GetEvent("event:/"+HERODIE);
		}
		heroDieSound.start ();
	}

	private EventInstance dieSound;
	public void PlayDieSound(){
		if (null == dieSound) {
			dieSound = FMOD_StudioSystem.instance.GetEvent("event:/"+DIE);
		}
		dieSound.start ();
	}

	private EventInstance missSound;
	public void PlayMissSound(){
		if (null == missSound) {
			missSound = FMOD_StudioSystem.instance.GetEvent("event:/"+MISS);
		}
		missSound.start ();
	}

	public void PlaySound(string name){
		if (name == ATTACK) {
			PlayANormalSound ();
		} else if (name == HURT) {
			PlayHurtSound ();
		} else if (name == HERODIE) {
			PlayHeroDieSound();
		}else if (name == DIE) {
			PlayDieSound();
		}else if (name == MISS) {
			PlayMissSound();
		}else if (name == BEATHit) {
			PlayABeatSound();
		}else if (name == TIPS) {
			PlayTipSound();
		}
	}
}

