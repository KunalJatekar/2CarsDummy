using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    //Rigidbody2D rb;
    float movingSpeed = 5f;
    AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1) * movingSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && gameObject.tag != "square_object")
        {
            Debug.Log("in");
            audio.Play();
        }
    }
}
