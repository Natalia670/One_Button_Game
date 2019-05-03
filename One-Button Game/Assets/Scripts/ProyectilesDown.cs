using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilesDown : MonoBehaviour
{
    public float ProyectilSpeed;
    private Rigidbody rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Vector3 movement = new Vector3(0f, 5f, 0f);
        rig.velocity = movement * ProyectilSpeed;
    }

    private void FixedUpdate()
    {

     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
