using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    Vector2 myLocation;
    Sprite mySprite;
    public GameObject enemy;

    bool enemySpawned = false;

    public GameObject[] waypoints;

    
    // Use this for initialization
    void Start () {

        mySprite = this.gameObject.GetComponent<Sprite>();
        myLocation = this.gameObject.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnWave()
    {
        GameObject temp;
        temp = Instantiate(enemy, myLocation, Quaternion.identity) as GameObject;
        enemySpawned = true;
        waypoints.CopyTo(temp.GetComponent<EnemyController>().waypoints, 0);
    }

    void OnMouseDown()
    {
        //if (!enemySpawned)
        {
            SpawnWave();
        }
    }
}
