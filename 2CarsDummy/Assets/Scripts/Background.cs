using UnityEngine;

public class Background : MonoBehaviour
{
    Rect leftRect;
    Rect rightRect;
    public PlayerMovement[] playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        leftRect = new Rect(0, 0, (Screen.width / 2), Screen.height);
        rightRect = new Rect((Screen.width / 2), 0, (Screen.width / 2), Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
#if  UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("Left side click");
            playerMovement[0].swapper();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("Right side click");
            playerMovement[1].swapper();
        }

#elif UNITY_ANDROID
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.touchCount > 0 && Input.touchCount <= 2)
            {
                if (leftRect.Contains(Input.GetTouch(i).position))
                {
                    Debug.Log("left : "+ Input.GetTouch(i).position);
                    playerMovement[0].swapper();
                }
                else
                {
                    Debug.Log("right : " + Input.GetTouch(i).position);
                    playerMovement[1].swapper();
                }
            }
        }
#endif
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("OnTriggerEnter2D in");
		Destroy(gameObject);
	}
}
