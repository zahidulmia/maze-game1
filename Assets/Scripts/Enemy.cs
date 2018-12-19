using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 1.0f;
    public float pointsGiven = 1.0f;
    public float moveSpeed = 2.0f;

    private float passedTime = 0.0f;
    private GameObject player;

    private Vector3 position;

	public GameObject SpawnLocations;
    // Use this for initialization
    void Start ()
    {
		player = GameObject.Find("PlayerHolder");
        position = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(player.transform);
        passedTime += 1 * Time.deltaTime;
        if(passedTime >= 1)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
		if(health <= 0)
        {
            Die();
        }
	}

    void Die()
    {
		//old
//        player.GetComponent<Player>().score += pointsGiven;
		player.GetComponent<Player>().AddScore(pointsGiven);
//        Destroy(this.gameObject);
		Respawn();
    }

	void Respawn()
	{
		health = 1.0f;
		passedTime = 0f;
		SpawnRandomly ();
//		gameObject.transform.position = position;
	}

	void SpawnRandomly()
	{
		gameObject.transform.position = SpawnLocations.transform.GetChild (Random.Range (0, 4)).transform.position;
	}
}
