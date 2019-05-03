using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Header("Objetos")]
    public GameObject rampage;
    public GameObject rampagedown;
    public GameObject laser;
    public GameObject bomb;
    public GameObject misile;


    public Vector3 spawnValuesDown;
    public Vector3 spawnValues;


    public float spawnRampageWait = 1.5f;
    public float spawnRampageWaitD = 1.5f;

    public Text timeText;
    public Text winText;
    public float time = 100f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnProyectiles());
        StartCoroutine(SpawnDownProyectiles());
        //StartCoroutine(SpawnLasers());
        InvokeRepeating("SpeedSpawn", 1, 1);
        InvokeRepeating("LaunchLasers", 50, 5);
        InvokeRepeating("LaunchBombs", 5, 1);
        winText.gameObject.SetActive(false);
    }

    IEnumerator SpawnProyectiles()
    {
        while (true)
        {

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Instantiate(rampage, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnRampageWait);
        }

    }

    IEnumerator SpawnLasers()
    {
        while (true)
        {
            yield return new WaitForSeconds(50);
            Vector3 spawnPosition = new Vector3(Random.Range(-20, 5), spawnValues.y, spawnValues.z);
            Instantiate(laser, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(5);
        }

    }

    IEnumerator SpawnDownProyectiles(){

        while (true)
        {

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValuesDown.x, spawnValuesDown.x), spawnValuesDown.y, spawnValuesDown.z);
            Instantiate(rampagedown, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnRampageWaitD);

        }

      
    }


    // Update is called once per frame
    void Update()
    {

        time -= Time.deltaTime;
        timeText.text = "Time Left: " + time.ToString("f0");
        if (timeText.text == "Time Left: 115")
        {
           
            
        }
        if( timeText.text == "Time Left: 110")
        {
          
        }
        if(timeText.text == "Time Left: 0")
        {
            winText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void SpeedSpawn()
    {
        spawnRampageWait = spawnRampageWait - 0.009f;
        spawnRampageWaitD = spawnRampageWaitD - 0.009f;
    }

    void LaunchBombs()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValuesDown.x, spawnValuesDown.x), spawnValuesDown.y, spawnValuesDown.z);
        Instantiate(bomb, spawnPosition, Quaternion.identity);
    }

    void LaunchLasers()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-5, 5), 6.5f, spawnValuesDown.z);
        Instantiate(laser, spawnPosition, Quaternion.identity);
    }

    void LaunchMissiles()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Instantiate(misile, spawnPosition, Quaternion.identity);

    }
  
    
}
