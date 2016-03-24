using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spriteTrailDos : MonoBehaviour {

	List<GameObject> trailParts = new List<GameObject>();

	public float repeatRate;
	public float lifeTime;
	public float alphaColor;

	void Start()
	{
		InvokeRepeating("SpawnTrailPart", 0, repeatRate);
	}

	void SpawnTrailPart()
	{
		GameObject trailPart = new GameObject();
		SpriteRenderer trailPartRenderer = trailPart.AddComponent<SpriteRenderer>();
		trailPartRenderer.sprite = GetComponent<SpriteRenderer>().sprite;
		trailPart.transform.position = transform.position;

		trailParts.Add(trailPart);

		StartCoroutine(FadeTrailPart(trailPartRenderer));
		Destroy(trailPart, lifeTime); 
	}

	IEnumerator FadeTrailPart(SpriteRenderer trailPartRenderer)
	{
		Color color = trailPartRenderer.color;
		color.a -= alphaColor; 
		trailPartRenderer.color = color;

		yield return new WaitForEndOfFrame();
	}

	void FixedUpdate(){

	}

}

///// temp
/// void FixedUpdate(){
//var currPos = transform.localPosition;
//var currXPos = transform.localPosition.x;
//var currYPos = transform.localPosition.y;
//
//if(currPos.x > -2 && currPos.y < 4){
//	currXPos--;
//} else if (currPos.x <= -2 && currPos.y < 4){
//	currYPos++;
//} else if (currPos.x <= 2 && currPos.y >= 4){
//	currXPos++;
//} else if (currPos.x >= 2 && currPos.y >= 4){
//	currYPos--;
//}
//
//transform.position = new Vector3(currXPos / 2, currYPos / 2, 0);
//}