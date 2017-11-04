using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;


	private bool gameOver;
	private bool restart;
    private int score;

    void Start()
	{
		gameOver = false;
		restart= false;
		restartText.text = "";
		gameOverText.text = "";
        score = 0;
        UpdateScore();

        StartCoroutine(spawnWaves());
    }
	void  Update()
	{
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex); 
			}
		}
	}	
	IEnumerator spawnWaves(){
		yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
                Vector3 spawnPostion = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
				GameObject clone= Instantiate(hazard, spawnPostion, spawnRotation);
				ReverseDirection (clone);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
			if (gameOver) {
				restartText.text="Press 'R' for Restart";
				restart = true;
				break;
			}
        }
    }
	void ReverseDirection (GameObject clone)
	{
	//	clone.transform.rotation.y = 0;
	//	clone.GetComponent<Mover> ().speed = 5;
	}
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
     void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
	public void GameOver()
	{
		gameOverText.text="Game Over";

		gameOver = true;
	}
    
}
