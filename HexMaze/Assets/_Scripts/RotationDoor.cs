using UnityEngine;
using System.Collections;

public class RotationDoor : MonoBehaviour {
    [SerializeField] float speed = 2f;
    [SerializeField] bool isPlayerTouching;
    LTDescr currentRotation;
    float deltaAngle = 3f;
    float deltaAngleReverse = 90f;
    bool isMoved;
    bool enableMoving = true;
    [SerializeField] AudioClip doorRotate;
    int levelsPassed;
    int movedInLevel;
    int turnsBeforeFree=4;
    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
        if (enableMoving) {
            
            if (transform.eulerAngles.z < 360f - deltaAngle && transform.eulerAngles.z > 240f && GetComponent<Rigidbody2D>().angularVelocity != 0f) {
                if (currentRotation == null) {
                    RotateToAngle(240f);
                    print("rotate");
                    if (transform.eulerAngles.z > 240f + deltaAngleReverse) {
                        AudioSource.PlayClipAtPoint(doorRotate, transform.position);
                        isMoved = true;
                        movedInLevel = levelsPassed;
                        ChangeColor(Color.yellow);
                        print("record");
                    }
                }
            }
            if (transform.eulerAngles.z < 240f - deltaAngle && transform.eulerAngles.z > 120f && GetComponent<Rigidbody2D>().angularVelocity != 0f) {
                if (currentRotation == null) {
                    RotateToAngle(120f);
                    print("rotate");
                    if (transform.eulerAngles.z > 120f + deltaAngleReverse) {
                        AudioSource.PlayClipAtPoint(doorRotate, transform.position);
                        isMoved = true;
                        movedInLevel = levelsPassed;
                        ChangeColor(Color.yellow);
                        print("record");
                    }
                }
            }
            if (transform.eulerAngles.z < 120f - deltaAngle && transform.eulerAngles.z > 0f && GetComponent<Rigidbody2D>().angularVelocity != 0f) {
                if (currentRotation == null) {
                    RotateToAngle(0f);
                    print("rotate");
                    if (transform.eulerAngles.z > 0f + deltaAngleReverse) {
                        AudioSource.PlayClipAtPoint(doorRotate, transform.position);
                        isMoved = true;
                        movedInLevel = levelsPassed;
                        ChangeColor(Color.yellow);
                        print("record");
                    }
                }
            }
        } else {
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
        
    }

    void OnEnable () {
        Events.g.AddListener<LevelEndEvent>(LevelEnd);
    }
    void OnDisable () {
        Events.g.RemoveListener<LevelEndEvent>(LevelEnd);
    }
    void LevelEnd (LevelEndEvent e) {
        levelsPassed++;

        NextLevelCheck();
    }
    void ChangeColor (Color color) {
        SpriteRenderer[] rendererList = new SpriteRenderer[99];
        rendererList = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer r in rendererList) {
            r.color = color;
        }
    }
    void NextLevelCheck () {
        if (isMoved) {
            if (levelsPassed == movedInLevel + turnsBeforeFree) {
                ChangeColor(Color.blue);

            } else if(levelsPassed > movedInLevel + turnsBeforeFree){
                enableMoving=true;
                GetComponent<Rigidbody2D>().isKinematic = false;
                ChangeColor(Color.green);
            }
            else{
                ChangeColor(Color.red);
                enableMoving = false;
            }

        }

    }
    void RotateToAngle (float angle) {
        
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().angularVelocity = 0f;
        currentRotation = LeanTween.rotateZ(gameObject, angle, 2f).setOnComplete(() => {
                Invoke("AllowDoorMovement", 0.5f);
            });
    }

    void AllowDoorMovement () {
        GetComponent<Rigidbody2D>().isKinematic = false;
        currentRotation = null;
    }
    
    public void InCollider (bool isColliding) {
        isPlayerTouching = isColliding;
    }
    
}
