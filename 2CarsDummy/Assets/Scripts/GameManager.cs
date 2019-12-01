using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static int gameScore;
	public Text scoreText;
	public Canvas pauseCanvas;
    public Canvas endCanvas;

    // Start is called before the first frame update
    void Start()
	{
		gameScore = 0;
	}

	public void restart(AudioSource audio)
	{
		Time.timeScale = 1;
        audio.Play();
        pauseCanvas.gameObject.SetActive(false);
        endCanvas.gameObject.SetActive(false);
		SceneManager.LoadScene(1);
	}

	public void scoreBoard()
	{
		gameScore = gameScore + 1;
		scoreText.text = "Score : " + gameScore.ToString();
	}

	public void play(AudioSource audio)
	{
		Time.timeScale = 1;
        audio.Play();
        pauseCanvas.gameObject.SetActive(false);
		SceneManager.LoadScene(1);
	}

	public void pause(AudioSource audio)
	{
		Time.timeScale = 0;
        audio.Play();
        pauseCanvas.gameObject.SetActive(true);
	}

	public void settings(AudioSource audio)
	{
        audio.Play();
        Debug.Log("In Settings");
	}

	public void exit()
	{
		Debug.Log("Quiting Application");
		Application.Quit();
	}

	public void home(AudioSource audio)
	{
        audio.Play();
		pauseCanvas.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
	}

    public void resume(AudioSource audio)
    {
        Time.timeScale = 1;
        audio.Play();
        pauseCanvas.gameObject.SetActive(false);
    }

    public void showEndMenu()
    {
        Time.timeScale = 0;
        endCanvas.gameObject.SetActive(true);
    }
}
