using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject pipe;

	public GUIText gameOverText;
	public GUIText scoreText;
	public GUIText highscoreText;

	public GUIText restartText;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;

	public GameObject cam1;
	public GameObject cam2;

	public int score;
	public static int highscore=0;

	bool restart;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());

		restart = false;
		Mover.speed = 0.1f;
		gameOverText.text = "";
		restartText.text = "";
		scoreText.text = "Score: 0";
		highscoreText.text = "HighScore: "+ highscore;
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetButtonDown("Switch1"))
		{
			cam1.SetActive(true);
			cam2.SetActive(false);
		}
		if (Input.GetButtonDown("Switch2"))
		{
			cam1.SetActive(false);
			cam2.SetActive(true);
		}*/
		if (restart)
		{
			if (Input.GetButton("Fire1"))
			{
				Application.LoadLevel (Application.loadedLevel);
			}

			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range (spawnValues.y-4.5f, spawnValues.y+2.5f), spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (pipe, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (spawnWait);

		}
	}


	public void GameOver()
	{
        if (score > highscore)
        {
			highscore = score;
			highscoreText.text = "HighScore: " + highscore.ToString();
		}
		Mover.speed = 0;
		gameOverText.text = "Dead!";
		restartText.text = "Press R to start again";
		restart = true;
	}

	public void AddScore()
	{
		score ++;
		scoreText.text = "Score: "+ score.ToString();
		Mover.speed += 0.1f;
	}
}
