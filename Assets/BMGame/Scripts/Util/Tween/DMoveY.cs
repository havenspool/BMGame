using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class DMoveY : MonoBehaviour {

	public AnimationCurve animationCurive;
	private Vector3 v3;
	private float time;

	void Start(){
		v3 = transform.position;
		time = Time.time;
	}

	void Update () {
		if (transform.gameObject.activeInHierarchy) {
			transform.position = new Vector3(v3.x, v3.y*animationCurive.Evaluate(Time.time-time), 0);
		} else {
			transform.position = new Vector3(v3.x, v3.y, 0);
		}
	}

	void OnEnable(){
		time = Time.time;
	}
}
