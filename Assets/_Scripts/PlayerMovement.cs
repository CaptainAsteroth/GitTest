using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D Player;
	public Vector3 StartingPos;
    private Vector3 mouse;
    private Vector3 objPos;
    private float angle;
    public float rSpeed;
    private Quaternion rotateTo;
    public float mainSpeed, sideSpeed, downSpeed;

	public bool death;
    void Start()
    {
       Player = GetComponent<Rigidbody2D>();
	   Player.position = StartingPos;
	   death = false;
    }

    // Update is called once per frame
    void Update()
    {
		Rotate();
		Move();
    }

	void OnCollisionEnter (Collision col) {
		if(col.gameObject.name == "Enemy") {
			//Death sound
			//Death animation
			death = true;
		}
		if(col.gameObject.name == "Terrain") {
			mainSpeed = 0;
			//Boop sound
		}
	}

    void Rotate() {
		mouse = Input.mousePosition;
		mouse.z = 5.23f;
		objPos = Camera.main.WorldToScreenPoint(gameObject.transform.position); //Adjusts position value to as if it was at the same depth as the screen (same as mouse)
		mouse.x = mouse.x - objPos.x;
		mouse.y = mouse.y - objPos.y;
		angle = Mathf.Atan2 (mouse.y, mouse.x) * Mathf.Rad2Deg; //simple trig to calculate the angle needed
		rotateTo = Quaternion.Euler(0,0,angle-90); //calculation for needed angle to match mouse
		transform.rotation = Quaternion.Slerp(transform.rotation, rotateTo, Time.deltaTime * rSpeed); //command to rotate towards arg1 from arg2 but no more than arg3 every frame
	}

    void Move() {
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {

			if(Input.GetKey(KeyCode.W)) {
				Player.AddRelativeForce (Vector2.up * mainSpeed);
			}
			if(Input.GetKey(KeyCode.A)) {
				Player.AddRelativeForce (Vector2.left * mainSpeed);
			}
			if(Input.GetKey(KeyCode.D)) {
				Player.AddRelativeForce (Vector2.right * mainSpeed);
			}
			if(Input.GetKey(KeyCode.S)) {
				Player.AddRelativeForce (Vector2.down * mainSpeed);
			}
		}
	}
}
