using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour {
    public Animator _animator;


	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("COLLLIDER");
            _animator.SetBool("open", true);
        }
        
    }

    // Update is called once per frame
    void Update () {
		
	}


}
