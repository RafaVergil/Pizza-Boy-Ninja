using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

	public float delay = 4f;

	IEnumerator Start () {
		yield return new WaitForSeconds (delay);
		Destroy (this.gameObject);
	}

}
