using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class DMoveX : MonoBehaviour {

	public AnimationCurve animationCurive;
	private Vector3 v3;
	private float time;

	void Start(){
		v3 = transform.position;
		time = Time.time;
	}
	
	void Update () {
		if (transform.gameObject.activeSelf) {
			transform.position = new Vector3(v3.x*animationCurive.Evaluate(Time.time-time), v3.y, 0);
		} else {
			transform.position = new Vector3(v3.x, v3.y, 0);
		}
	
	}
	void OnEnable(){
		time = Time.time;
	}
}
