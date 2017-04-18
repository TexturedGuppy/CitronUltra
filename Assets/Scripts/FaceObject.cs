using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// FaceObject script
/// Any object it attaches to will face another game object when in range
/// </summary>
public class FaceObject : MonoBehaviour
{
    public GameObject target; //Target Object
    public GameObject bullet; //Bullet object
    public float distance; //Threshhold distance for distance between target and original object
    public Transform barrelEnd; //Locatoin of end of barrel for shooting
    public float fireRate; //How fast it shoots
    public float speed;
    Rigidbody2D bulletRB; //Rigid body of bullet object
    private float angle; //angle for rotating
    // Use this for initialization
    void Start()
    {
        bulletRB = bullet.GetComponent<Rigidbody2D>();
            StartCoroutine("Shoot");
    }

    // Update is called once per frame
    void Update()
    {

        //Checks distance between target and object this is placed on
        if (Vector3.Distance(transform.position, target.transform.position) < distance)
        {
            //rotates to face target
            Vector3 delta = target.transform.position - transform.position;
            angle = Mathf.Atan2(delta.y, delta.x);
            transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * angle);
        }

    }

    /// <summary>
    /// Shooting CoRoutine for object it is attached to will shoot whatever bullet prefab is attached
    /// </summary>
    /// <returns></returns>
    public IEnumerator Shoot()
    {
        while (true)
        {
        yield return new WaitForSecondsRealtime(fireRate);
            if (Vector3.Distance(transform.position, target.transform.position) < distance)
            {
                Instantiate(bullet, barrelEnd.position, barrelEnd.rotation);
            }
            
        }
    }
}
                


    
            

        

            
