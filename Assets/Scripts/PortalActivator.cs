using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalActivator : MonoBehaviour {
    Portal parent;

    void Start()
    {
       parent = GetComponentInParent<Portal>();
    }

	void OnTriggerEnter2D(Collider2D collider)
    {
        parent.IsActive = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        parent.IsActive = false;
    }
}
