using UnityEngine;
using System.Collections;

public class DoorCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionExit2D (Collision2D other) {
		
        if (other != null && other.gameObject.tag == "Player") {
        	//transform.root.GetComponentInChildren<RotationDoor>().InCollider(false);
        	//print("collide exit");
        }
    }
    void OnCollisionEnter2D (Collision2D other) {
        if (other != null && other.gameObject.tag == "Player") {
        	//transform.root.GetComponentInChildren<RotationDoor>().InCollider(true);
        	//print("collide enter");
        }
    }
}
