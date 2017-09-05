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
	private int nGrass = 40;

	private SpriteRenderer grassBounds;
	private SpriteRenderer goatBounds;

	float verticalExtent;
	float horizontalExtent;
	float grassSizeX;
	float grassSizeY;

	void Start () {

		grassBounds = grass.GetComponentInChildren<SpriteRenderer>();
		goatBounds = this.gameObject.GetComponentInChildren<SpriteRenderer>();
		rigidBody = GetComponent<Rigidbody2D>();

		verticalExtent = Camera.main.orthographicSize;
		horizontalExtent = verticalExtent * Screen.width / Screen.height;

		grassSizeX = grassBounds.sprite.bounds.size.x;
		grassSizeY = grassBounds.sprite.bounds.size.y;

		for (int i = 0; i < nGrass; i++) {

			GameObject g = Instantiate(grass);
			float x = (1f - 2f * Random.value) * (horizontalExtent - grassSizeX / 2f);
			float y = (1f - 2f * Random.value) * (verticalExtent - grassSizeY / 2f);

			g.transform.Translate(new Vector3(x, y, 0));

		}

		float goatWidth = goatBounds.sprite.bounds.size.x;
		float goatHeight = goatBounds.sprite.bounds.size.y;
		
	}
		
	// Update is called once per frame

	void FixedUpdate () {
		
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
		rigidBody.AddForce(movement * speed);

	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.gameObject.CompareTag("grass")) {

			float x = (1f - 2f * Random.value) * (horizontalExtent - grassSizeX / 2f);
			float y = (1f - 2f * Random.value) * (verticalExtent - grassSizeY / 2f);
			other.transform.position = new Vector3(x, y, 0);
			grassCount++;
			countText.text = "You have eaten: " + grassCount.ToString() + " grass";

		}

	}

}
