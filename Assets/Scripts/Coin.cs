using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip _clickClip;
    private int count=0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            count++;
            AudioSource.PlayClipAtPoint(_clickClip,collision.transform.position);
            Destroy(collision.gameObject);
        }
    }
}
