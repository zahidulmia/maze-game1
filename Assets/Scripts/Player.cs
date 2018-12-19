using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public UI ui;
	public GameObject EnemySpawnLocations;
	public GameObject EnemiesParent;

    // members or variables
    public float health = 3.0f;
    public float moveSpeed = 7.0f;
    public float score = 0.0f;

    public GameObject bulletSpawner;
    public GameObject bullet;
	public GameObject initialPosition;
    public GameObject textLife;
    public GameObject textScore;

    private Vector3 position;

    // methods or functions
    void Start()
    {
        position = gameObject.transform.position; 
		resetGameScore ();
    }
    // Update is called once per frame
    void Update () {
		// Player movement
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.W))
                transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
            //transform.GetChild(0).LookAt()
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.A))
                transform.GetChild(0).rotation = Quaternion.Euler(0, -90, 0);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.S))
                transform.GetChild(0).rotation = Quaternion.Euler(0, 180, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.D))
                transform.GetChild(0).rotation = Quaternion.Euler(0, 90, 0);
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
            health -= 1.0f;
            transform.position = position;
            /*transform.Translate(position, Space.World);*/
			if (health < 0) {
				//When Player Dies Restart Scene
				OnPlayerDeath ();
				print ("Player died!");
				// Destroy(this.gameObject);
			} else {
				textLife.GetComponent<Text>().text = "Lives : " +health.ToString();			
			}
        }
    }
    void Shoot(){
        Instantiate(bullet.transform, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
    }

	public void Reposition()
	{
		Debug.Log ("Reposition PLayer");
		gameObject.transform.position = initialPosition.transform.position;
	}

	public void AddScore(float points)
	{
		score += points;
		textScore.GetComponent<Text>().text = "Score :" + score.ToString();
	}

	void OnPlayerDeath()
	{
		ui.OnGameOver (score);
		ResetEnemies ();
		
	}
	void ResetEnemies()
	{
		int count = 0;
		foreach (Transform x in EnemiesParent.transform) {
			x.position = EnemySpawnLocations.transform.GetChild (count).position;
			count++;
		}
	}

	public void resetGameScore()
	{
		health = 3.0f;
		score = 0;

		ui.resetScoreLives (health, score);
	}

}
