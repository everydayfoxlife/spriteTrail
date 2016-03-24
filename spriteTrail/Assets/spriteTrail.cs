using UnityEngine;
using System.Collections;

public class spriteTrail : MonoBehaviour {
	
	public float repeatRate;

	public Transform startMarker;
	public Transform endMarker;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;

	private SpriteRenderer spriteRenderer;
	public float alphaColor;

	void Start()
	{
		InvokeRepeating ("SpawnTrailPart", 0, repeatRate);

		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

	}

	void SpawnTrailPart()
	{
		GameObject obj = ObjectPoolerScript.current.GetPooledObject();

		if (obj == null) {
			return;
		}

		obj.transform.position = transform.position;

		obj.SetActive (true);
		StartCoroutine(FadeTrailPart(obj));

	}

	IEnumerator FadeTrailPart(GameObject obj)
	{
		spriteRenderer = obj.GetComponent<SpriteRenderer>();

		yield return new WaitForSeconds(0.2f);

		Color color = spriteRenderer.color;
		color.a = alphaColor;
		spriteRenderer.color = color;
		yield return new WaitForEndOfFrame();

		obj.SetActive (false);
	}
		
	void FixedUpdate(){
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
		if(transform.position == endMarker.position){
			CancelInvoke ();
		}

	}

}
