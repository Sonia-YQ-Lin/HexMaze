using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {
	public float speed=2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var input=new Vector3 (Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
		GetComponent<Rigidbody2D>().MovePosition(transform.position+input * Time.deltaTime * speed);
	}
}
