using UnityEngine;
using System.Collections;

public class TowerSpawner : MonoBehaviour {

    Vector2 myLocation;
    Sprite mySprite;
    public GameObject rangedTower;

    bool towerSpawned = false;

	// Use this for initialization
	void Start () {

        myLocation = this.gameObject.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
	
    

	}

    void OnMouseDown()
    {
        if (!towerSpawned)
        {
            SpawnTower();
        }
    }

    void SpawnTower()
    {
        Instantiate(rangedTower, myLocation, Quaternion.identity);
        towerSpawned = true;
    }
}
