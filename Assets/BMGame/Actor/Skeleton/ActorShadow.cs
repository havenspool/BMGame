using UnityEngine;
using System.Collections;

public class ActorShadow : MonoBehaviour {

	public Transform body;
	private Vector3 bodyInitPosition;
	private Vector3 initPosition;

	// Use this for initialization
	void Start () {
		bodyInitPosition = body.localPosition;
		initPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = initPosition + Vector3.right * (body.localPosition.x - bodyInitPosition.x)*40;
	}
}
