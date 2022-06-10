using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 0, 0, 1);
    [SerializeField] Color32 defaultColor = new Color32(1, 1, 1, 1);
    [SerializeField] bool hasPackage;
    [SerializeField] float timeToDestroy = 1f;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider)
        {
            Debug.Log("You hit Grandma!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("You picked up a package");
            hasPackage = true;
            ChangeCarColor();
            Destroy(collision.gameObject, timeToDestroy);
        }
        else if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("You Delivered the Package");
            hasPackage = false;
            ChangeCarColor();
            Destroy(collision.gameObject, timeToDestroy);
        }
    }

    private void ChangeCarColor()
    {
        if (hasPackage)
        {
            spriteRenderer.color = hasPackageColor;
        }
        else
        {
            spriteRenderer.color = defaultColor;
        }
    }
}
