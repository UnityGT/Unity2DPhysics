using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    Rigidbody2D rBody;
    Vector2 initialTouch, finalTouch;

	void Start () {
        rBody = GetComponent<Rigidbody2D>();
	}

    void Throw(Vector2 direction, float distance)
    {
        Debug.Log(direction);
        rBody.gravityScale = 1;
        rBody.AddForce(direction * -1f * (10f * distance), ForceMode2D.Impulse);
        Invoke("Clear", 3f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            finalTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 directionNormalized = (finalTouch - initialTouch).normalized;
            float distance = Vector2.Distance(finalTouch, initialTouch);
            Throw(directionNormalized, distance);
        }
    }

    void Clear()
    {
        GameObject.FindObjectOfType<Manager>().CheckGameState();
        Destroy(this.gameObject);
    }
}
