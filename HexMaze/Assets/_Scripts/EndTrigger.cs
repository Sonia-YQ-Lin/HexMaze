using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndTrigger : MonoBehaviour {
	[SerializeField] AudioClip enter;
	[SerializeField] AudioClip passLevel;
	int LevelsPassed;
	[SerializeField] Text levelUI;
	[SerializeField] Sprite steppedEnd; 
	[SerializeField] Sprite originalEnd; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		levelUI.text=LevelsPassed.ToString();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other!=null && other.gameObject.tag=="Player")
		{
			AudioSource.PlayClipAtPoint(enter, transform.position);
			GetComponent<SpriteRenderer>().sprite=steppedEnd;
		}
	}
	void OnTriggerStay2D(Collider2D other)
	{
		if(other!=null && other.gameObject.tag=="Player")
		{
			if(Input.GetKeyDown(KeyCode.N))
			{
				AudioSource.PlayClipAtPoint(passLevel, transform.position);
				LevelsPassed++;
				Events.g.Raise(new LevelEndEvent());
				GetComponent<SpriteRenderer>().sprite=originalEnd;
			}
		}
	}
}
