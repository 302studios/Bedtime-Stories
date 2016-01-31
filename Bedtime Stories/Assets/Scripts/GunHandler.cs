using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunHandler : MonoBehaviour {

    public GameObject bullet;
    public float fireRate = .5f;
    public float turnSpeed = 3f;
    public float fireSpeed = 30f;
    [SerializeField]
    GameObject currentTarget;
    List<GameObject> targetQueue = new List<GameObject>();
    bool canFire = true;

	// Use this for initialization
	void Start () {

       

    }
	
	// Update is called once per frame
	void Update () {

        

        if(currentTarget != null)
        {
            Vector3 lookDirection = currentTarget.transform.position - transform.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime*20f);

            if (canFire)
            {
                Fire();
            }
        }


    }

    IEnumerator FireCooldown()
    {
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

    void Fire()
    {
        GameObject temp;
        
        temp = Instantiate(bullet, this.transform.position, Quaternion.identity) as GameObject;
        temp.GetComponent<Rigidbody2D>().AddForce(transform.right * fireSpeed, ForceMode2D.Impulse);
        StartCoroutine(FireCooldown());
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            //Debug.Log("Hello!");

            if (currentTarget == null)
            {
                currentTarget = col.gameObject;
            }
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {

            if (currentTarget == col.gameObject)
            {
                currentTarget = null;
            }
        }

    }

}
