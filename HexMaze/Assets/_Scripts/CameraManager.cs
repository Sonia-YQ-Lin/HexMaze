using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {
	[SerializeField] GameObject character;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position=new Vector3(character.transform.position.x,character.transform.position.y,character.transform.position.z-10f);
	}
}
