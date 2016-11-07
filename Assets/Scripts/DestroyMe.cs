using UnityEngine;
using System.Collections;

public class DestroyMe : MonoBehaviour {

    public float lifetime;

	// Use this for initialization
	void Awake () {
        Destroy(gameObject, lifetime);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
