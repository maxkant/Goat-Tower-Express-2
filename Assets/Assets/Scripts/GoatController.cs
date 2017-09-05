using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoatController : MonoBehaviour {

	// Use this for initialization
	public GameObject grass;
	public Text countText;
	private Rigidbody2D rigidBody;
	public float speed;
	private int grassCount = 0;

	private SpriteRenderer grassBounds;
	private SpriteRenderer goatBounds;
	private GoatPenManager goatPenManager; 

	float verticalExtent;
	float horizontalExtent;
	float grassSizeX;
	float grassSizeY;

	void Start () {

		grassBounds = grass.GetComponentInChildren<SpriteRenderer>();
		goatBounds = GetComponentInChildren<SpriteRenderer>();
		rigidBody = GetComponent<Rigidbody2D>();
		goatPenManager = GameObject.Find("dirt").GetComponentInChildren<GoatPenManager>();
		grassSizeX = grassBounds.sprite.bounds.size.x;
		grassSizeY = grassBounds.sprite.bounds.size.y;
	}
		
	// Update is called once per frame

	void FixedUpdate () {
		
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		if (moveHorizontal > 0) { goatBounds.flipX = false;}
		else if (moveHorizontal < 0) {goatBounds.flipX = true;}
		Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
		rigidBody.AddForce(movement * speed);

	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.gameObject.CompareTag("grass")) {

			float x = goatPenManager.insideLeft + grassSizeX/2f + Random.value * (goatPenManager.insideRight - goatPenManager.insideLeft - grassSizeX);
			float y = goatPenManager.insideBottom + grassSizeY/2f +  Random.value * (goatPenManager.insideTop - goatPenManager.insideBottom - grassSizeY);
			other.transform.position = new Vector3(x, y, 0);
			grassCount++;
			countText.text = "You have eaten: " + grassCount.ToString() + " grass";

		}

	}

}
