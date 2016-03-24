using UnityEngine;
using System.Collections;

public class cloneDestroy : MonoBehaviour {

	void Enable(){
		Invoke ("Destroy", 2f);
	}

	void Destroy(){
		gameObject.SetActive (false);
	}

	void OnDisable(){
		CancelInvoke ();
	}
}
