using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastScript : MonoBehaviour
{
    public GameObject Rayorigin;
    public float range = 10;
    public float impactForce = 10;


    public List<GameObject> destroyedObjectList;

    void Start()
    {
        destroyedObjectList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {


        Debug.DrawRay(Rayorigin.transform.position, Rayorigin.transform.forward * range, Color.green);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        else if (Input.GetButtonDown("Fire2"))
        {
            AddObject();
        }

    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Rayorigin.transform.position, Rayorigin.transform.forward, out hit, range))
        {
            Debug.DrawRay(Rayorigin.transform.position, Rayorigin.transform.forward * range, Color.red, 2);
            // Debug.Log(hit.transform.name);

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(hit.point * impactForce);
            }

            GameObject HitObject = hit.transform.gameObject;
            destroyedObjectList.Add(HitObject);
            HitObject.SetActive(false);

        }

    }
    void AddObject()
    {
        RaycastHit hit;
        Physics.Raycast(Rayorigin.transform.position, Rayorigin.transform.forward, out hit, 50);
        
            Debug.DrawRay(Rayorigin.transform.position, Rayorigin.transform.forward * range, Color.red, 2);
        // Debug.Log(hit.transform.name);


            for (int i = 0; i < destroyedObjectList.Count; i++)
            {
                Vector3 ClonePosition = new Vector3(Rayorigin.transform.localPosition.x, Rayorigin.transform.localPosition.y, Rayorigin.transform.localPosition.z);
                 
                 destroyedObjectList[i].transform.position = ClonePosition;
                destroyedObjectList[i].transform.rotation = Rayorigin.transform.rotation;
                destroyedObjectList[i].name = "NewObject" + i.ToString();
                destroyedObjectList[i].SetActive(true);
                 destroyedObjectList.Remove(destroyedObjectList[i]);

               // break;
                 
            }
       

    }
}
