using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deliver : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (225, 225, 0, 225);
    [SerializeField] Color32 noPackageColor = new Color32 (225, 225, 225, 225);
    [SerializeField] float destroyDelay = 1f;

    bool hasPackage;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Got the package!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        } 
        if (other.tag == "Customer") 
        {
            if (hasPackage) {
                Debug.Log("Package delivered!");
                hasPackage = false;
                spriteRenderer.color = noPackageColor;
            }
            else {
                Debug.Log("Didn't you forget something?");
            } 
        } 
    }
}
