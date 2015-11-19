using UnityEngine;
using System.Collections;

public class ActorShadow : MonoBehaviour {

	public Transform body;
	private Vector3 bodyInitPosition;
	private Vector3 initPosition;

	// Use this for initialization
	void Start () {
		bodyInitPosition = body.position;
		initPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = initPosition + Vector3.right * (body.position.x - bodyInitPosition.x);
	}
}
