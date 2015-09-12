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
		if(Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.RightShift))
		{
			speed=3f;
		}
		else{
			speed=2f;
		}
	}
}
