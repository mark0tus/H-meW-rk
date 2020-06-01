using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{

    public GameObject slicedPrefab; 
    public float startForce = 13f;
    Rigidbody2D rb;


    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

   void OnTriggerEnter2D (Collider2D col)
   {
       if (col.tag == "Blade")
        {
            Vector3 direction = (col.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            GameObject slicedVirus = Instantiate(slicedPrefab, transform.position, rotation);
            Debug.Log("HIT");
            Destroy(slicedVirus, 5f);
            Destroy (gameObject);
        }
   }
}
