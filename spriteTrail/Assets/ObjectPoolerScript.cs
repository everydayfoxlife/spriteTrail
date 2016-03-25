using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolerScript : MonoBehaviour {

	public static ObjectPoolerScript current;
	public GameObject pooledObject;
	public int pooledAmount;
	public bool willGrow;

	public GameObject sprite;

	private SpriteRenderer spriteRenderer;

	List<GameObject> pooledObjects;

	private const string layerName = "Default";
	private int sortingOrder = 0;

	void Awake(){
		current = this;
	}

	void Start(){
		pooledObjects = new List<GameObject> ();

		for(int i = 0; i < pooledAmount; i++){
			GameObject obj = (GameObject)Instantiate (pooledObject);

			spriteRenderer = obj.GetComponent<SpriteRenderer>();

			if (spriteRenderer)
			{
				spriteRenderer.sortingOrder = sortingOrder;
				spriteRenderer.sortingLayerName = layerName;

			}

			obj.transform.position = obj.transform.localPosition;

			obj.SetActive (false);
			pooledObjects.Add (obj);

		}

	}

	public GameObject GetPooledObject (){
		for(int i = 0; i < pooledObjects.Count; i++){
			if(!pooledObjects[i].activeInHierarchy){
				return pooledObjects[i];
			}
		}

		if(willGrow){
			GameObject obj = (GameObject)Instantiate (pooledObject);
			pooledObjects.Add (obj);
			return obj;
		}

		return null;
	}


}
