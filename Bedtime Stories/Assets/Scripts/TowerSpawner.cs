using UnityEngine;
using System.Collections;

public class TowerSpawner : MonoBehaviour {

    Vector2 myLocation;
    SpriteRenderer mySprite;
    public GameObject gumballTower;
    public GameObject teddyBearTower;
    public GameObject blockoTower;
    public GameObject laserTower;

    public GameObject selectionWheel;

    public bool towerSpawned = false;

	// Use this for initialization
	void Start () {

        myLocation = this.gameObject.transform.position;
        mySprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
    

	}

    void OnMouseDown()
    {
        if (!towerSpawned)
        {
            TowerSelection();
        }
    }

    void TowerSelection()
    {
        selectionWheel.SetActive(true);
    }

    public void SpawnTower(int towerSelection)
    {
        if(towerSelection == 1)
        {
            Instantiate(gumballTower, myLocation, Quaternion.identity);
            selectionWheel.SetActive(false);
            towerSpawned = true;
            mySprite.enabled = false;
        }
        if (towerSelection == 2)
        {
            Instantiate(teddyBearTower, myLocation, Quaternion.identity);
            selectionWheel.SetActive(false);
            towerSpawned = true;
            mySprite.enabled = false;
        }
        if (towerSelection == 3)
        {
            Instantiate(blockoTower, myLocation, Quaternion.identity);
            selectionWheel.SetActive(false);
            towerSpawned = true;
            mySprite.enabled = false;
        }
        if (towerSelection == 4)
        {
            Instantiate(laserTower, myLocation, Quaternion.identity);
            selectionWheel.SetActive(false);
            towerSpawned = true;
            mySprite.enabled = false;
        }
        if (towerSelection == 5)
        {
            selectionWheel.SetActive(false);
        }
    }
}
