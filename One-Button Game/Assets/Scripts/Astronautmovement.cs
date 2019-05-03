using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Astronautmovement : MonoBehaviour
{

    public Text gameOver;
    private int life = 8;
    public Text lives;
    public float speed = 6;
    private Rigidbody rig;
    SpriteRenderer m_SpriteRenderer;
    public float xMin, xMax;
    Vector3 movement = new Vector3(6f, 0f, 0f);
    


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        movement = new Vector3(6f, 0f, 0f);
        rig.velocity = movement * speed;
        gameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rig.velocity = rig.velocity*-1;

        }
    }


    private void FixedUpdate()
    {

        rig.position = new Vector3(Mathf.Clamp(rig.position.x, xMin, xMax), 0f, 0f);

    }

    private void OnTriggerEnter(Collider other)
    {
        
        life = life - 1;
        lives.text = "HP: " + life.ToString();
        StartCoroutine(ChangeColor());
        if (life <= 0)
        {
            Destroy(gameObject);
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

    }

    IEnumerator ChangeColor()
    {

        m_SpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        m_SpriteRenderer.color = Color.white;
    }

}
