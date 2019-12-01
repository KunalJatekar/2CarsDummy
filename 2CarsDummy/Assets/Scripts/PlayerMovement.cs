using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Transform[] playerPosition;
	float[] quickResponseOffset;
	bool state = true;
	int index;
	public float steps = 1f;
	GameManager gameManager;

	private void Start()
	{
		quickResponseOffset = new float[2];
		quickResponseOffset[0] = playerPosition[0].position.x + 0.5f;
		quickResponseOffset[1] = playerPosition[1].position.x - 0.5f;
		gameManager = FindObjectOfType<GameManager>();
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, playerPosition[index].position, steps * Time.deltaTime);
		if(Input.GetKeyDown(KeyCode.Escape)){
			//gameManager.pause();
		}
	}

	public void swapper()
	{
		if (transform.position.x < quickResponseOffset[0] || transform.position.x > quickResponseOffset[1])
		{
			state = !state;
			if (state)
			{
				index = 0;
			}
			else
			{
				index = 1;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "circle_object")
		{
			collision.gameObject.SetActive(false);
			gameManager.scoreBoard();
			//Debug.Log("circle_object");
		}

		if (collision.gameObject.tag == "square_object")
		{
			//Debug.Log("square_object");
			gameObject.SetActive(false);
			gameManager.showEndMenu();
		}


	}
}
