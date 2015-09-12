using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {
	[SerializeField] GameObject character;
	bool birdView;
	// Use this for initialization
	void Start () {
		birdView=true;
	
	}
	
	// Update is called once per frame
	void Update () {
		

		if(Input.GetKeyDown(KeyCode.Space))
		{
			birdView=!birdView;
		}
		if(birdView)
		{
			transform.position=new Vector3(14.2f,12.1f,-10f);
			GetComponent<Camera>().orthographicSize=13f;
		}
		else{
			transform.position=new Vector3(character.transform.position.x,character.transform.position.y,character.transform.position.z-10f);
			GetComponent<Camera>().orthographicSize=6f;
		}
	}
}
