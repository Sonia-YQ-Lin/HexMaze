using UnityEngine;
using System.Collections;

public class RotationDoor : MonoBehaviour {
    [SerializeField] float speed = 2f;
    [SerializeField] bool isPlayerTouching;
    LTDescr currentRotation;
    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
        //if (!isPlayerTouching) 
        if (transform.eulerAngles.z < 355f && transform.eulerAngles.z > 240f && GetComponent<Rigidbody2D>().angularVelocity!=0f) {
            if (currentRotation == null) {
                RotateToAngle(240f);
            }
        }
        if (transform.eulerAngles.z < 235f && transform.eulerAngles.z > 120f && GetComponent<Rigidbody2D>().angularVelocity!=0f) {
            if (currentRotation == null) {
                RotateToAngle(120f);
            }
        }
        if (transform.eulerAngles.z < 115f && transform.eulerAngles.z > 0f && GetComponent<Rigidbody2D>().angularVelocity!=0f) {
            if (currentRotation == null) {
                RotateToAngle(0f);
            }
        }

        
        

    }

    void RotateToAngle (float angle) {
        
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().angularVelocity=0f;
        currentRotation = LeanTween.rotateZ(gameObject, angle, 2f).setOnComplete(() => {
            Invoke("AllowDoorMovement", 0.5f);
            });
    }

    void AllowDoorMovement() {
        GetComponent<Rigidbody2D>().isKinematic = false;
        currentRotation = null;
    }
    
    public void InCollider (bool isColliding) {
        isPlayerTouching = isColliding;
    }
    
}
