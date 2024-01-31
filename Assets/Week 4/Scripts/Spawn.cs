using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    float timer;
    public GameObject Plane;
    float timertarget = 5;
    public Transform Spawner;
    Vector3 position;
    Quaternion rotation;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        Plane = GetComponent<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
            if(timer > timertarget )
        {

            Vector2 position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
           Quaternion rotation = new Quaternion(Random.Range(0, 0), Random.Range(0,0), Random.Range(-180,180),Random.Range(-180,180));
            float speed = Random.Range(1, 3);
            Instantiate(Plane, position, rotation, );
            GetComponent<Plane>().SetSpeed(speed);
            timer = 0;
        }
    }
}
