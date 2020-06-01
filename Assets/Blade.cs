using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject bladeTrailPrefab;
    public float minCutVelocity = .0001f;
    bool isCutting = false;

    Vector2 previousPos;
    Rigidbody2D rb;
    Camera cam; 
    GameObject currentBladeTrail;
    CircleCollider2D circleCollider;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(0))
      {
          StartCutting();
      }  
      else if(Input.GetMouseButtonUp(0))
      {
          StopCutting();
      }
      if (isCutting)
      {
          UpdateCut();
      }      
    }

    void UpdateCut()
    {
        Vector2 newPos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPos;

        float velocity = (newPos - previousPos).magnitude / Time.deltaTime;
        if (velocity > minCutVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }
        previousPos = newPos;
    }

    void StartCutting()
    {
        isCutting = true;
        Debug.Log("Cutting");
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        previousPos = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = false;
    }

    void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 3f);
        circleCollider.enabled = false;
    }
}
