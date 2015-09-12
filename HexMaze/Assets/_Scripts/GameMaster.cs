using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
    Vector2[] EndLocs;
    [SerializeField] Transform End;
    int length;
    int current;
    [SerializeField] GameObject button;
    // Use this for initialization
    void Start () {
        GameObject[] EndLocObjects = GameObject.FindGameObjectsWithTag("EndLoc");
        length = EndLocObjects.Length;
        EndLocs = new Vector2[length];
        for (int i = 0; i < length; i++) {
            EndLocs[i] = EndLocObjects[i].transform.position;
            Vector2 pos = End.position;
            if(EndLocs[i]==pos)
            {
            	current=i;
            }
        }
    }
	
    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    void OnEnable () {
        Events.g.AddListener<LevelEndEvent>(LevelEnd);
    }
    void OnDisable () {
        Events.g.RemoveListener<LevelEndEvent>(LevelEnd);
    }

    void LevelEnd (LevelEndEvent e) {
    	LocateEnd();
    }
    public void RollTheDice(){
        LocateEnd();
        button.SetActive(false);
    }
    void LocateEnd(){
        int rand = (int)(Random.value*length);
        while(rand==current)
        {
            rand= (int)(Random.value*length);
        }
        End.position=EndLocs[rand];
        current=rand;
    }
}
