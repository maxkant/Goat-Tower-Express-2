using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatPenManager : MonoBehaviour {

	public GameObject horizontalFence;
	public GameObject verticalFence;
	public int nHorizontal;
	public int nVertical;
	public float left;
	public float top;
	private SpriteRenderer verticalFenceBounds;
	private SpriteRenderer horizontalFenceBounds;


	// Use this for initialization
	void Start () {

		horizontalFenceBounds = horizontalFence.GetComponentInChildren<SpriteRenderer>();
		verticalFenceBounds = verticalFence.GetComponentInChildren<SpriteRenderer>();

		float hFenceWidth = horizontalFenceBounds.sprite.bounds.size.x;
		float hFenceHeight = horizontalFenceBounds.sprite.bounds.size.y;

		float vFenceWidth = verticalFenceBounds.sprite.bounds.size.x;
		float vFenceHeight = verticalFenceBounds.sprite.bounds.size.y;


		// Top and bottom fences

		for (int i = 0; i < nHorizontal; i++){

			GameObject hfTop = Instantiate(horizontalFence);
			GameObject hfBottom = Instantiate(horizontalFence);

			float x = i * hFenceWidth;

			hfTop.transform.Translate(new Vector3(left, top, 0));
			hfTop.transform.Translate(new Vector3(x, 0, 0));

			hfBottom.transform.Translate(new Vector3(left, top, 0));
			hfBottom.transform.Translate(new Vector3(x, -nVertical * vFenceHeight - hFenceHeight, 0));

		}

		// Left and right fences
		for (int i = 0; i < nVertical; i++){

			GameObject vfLeft = Instantiate(verticalFence);
			GameObject vfRight = Instantiate(verticalFence);

			float y =  - i * vFenceHeight - hFenceHeight;

			vfLeft.transform.Translate(new Vector3(left, top, 0));
			vfLeft.transform.Translate(new Vector3(0, y, 0));

			vfRight.transform.Translate(new Vector3(left, top, 0));
			vfRight.transform.Translate(new Vector3(nHorizontal * hFenceWidth - vFenceWidth, y, 0));
				

		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
