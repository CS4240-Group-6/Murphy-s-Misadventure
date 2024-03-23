using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomEmergencies : MonoBehaviour
{
    // FIRE RELATED
    public ParticleSystem sparksFlying;
    public ParticleSystem bigSparks;
    public GameObject plugFire;
    public GameObject smallTableFire;
    public GameObject comTableFire;
    public float MinTime;
    public float MaxTime;
    public float Timer;
    public Light tableLight;
    private bool flickerLight = false;

    // EARTHQUAKE RELATED
    public static bool isEarthquakeLevelOver = false;
    public float shakeMagnitude = 0.1f;
    public float shakeDuration = 10.0f;
    public float shakeForce = 5f;
    public GameObject[] objectsToShake;
    private Vector3[] originalObjectPositions;
    public GameObject[] ceilingChunks; 
    public float collapseDelay = 15f; // time for ceiling to collapse once things start shakin
    public float collapseDuration = 60f; 
    public float delayBetweenChunks = 3f; 
    private List<GameObject> collapsedChunks = new List<GameObject>();
    public GameObject ceilingGameObject;
    public GameObject crumblingCeiling;
    public GameObject ceilingFanNoEarthquake;
    public GameObject sturdyTable;
    [SerializeField] private GameObject player;
    [SerializeField] BoxCollider sturdyTableAreaCollider;


    /*
        To start the fire scene, use StartFireScene();
        To start the earthquake scene, use StartEarthquakeScene();
    */
    void Start()
    {
        plugFire.SetActive(false);
        smallTableFire.SetActive(false);
        comTableFire.SetActive(false);
        Timer = Random.Range(MinTime, MaxTime);
        // StartFireScene();

        originalObjectPositions = new Vector3[objectsToShake.Length];
        for (int i = 0; i < objectsToShake.Length; i++)
        {
            originalObjectPositions[i] = objectsToShake[i].transform.position;
        }
        StartEarthquakeScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (flickerLight)
            LightFlickering();

        // for earthquake level
        if (!isEarthquakeLevelOver) {
            CheckPlayerUnderSturdyTable();
        }
    }

    /*
        Scene starts with sparks flying first.
        Player dialogue: what was that?
        10 secs later -> Big electrical ParticleSystem plays
                     -> Lights start flickering
        20s later -> Fire starts
        every 10s -> Something catches fire
        60s limit -> YOU DIED
    */
    void StartFireScene() {
        sparksFlying.Play();
        Invoke("StartElectricityEffect", 10f);
        Invoke("StartPlugFireEffect", 15f);
        Invoke("LightFlickering", 15f);
        Invoke("StartSmallTableFireEffect", 18f);
        Invoke("StartComTableFireEffect", 21f);
    }

    void StartElectricityEffect() {
        bigSparks.Play();
    }

    void StartPlugFireEffect() {
        plugFire.SetActive(true);
        Transform childTransform = plugFire.transform.Find("Fire_Yellow");
        if (childTransform != null)
        {
            ParticleSystem fireParticles = childTransform.gameObject.GetComponent<ParticleSystem>();
            fireParticles.Play();
        }
    }

    void StartSmallTableFireEffect() {
        smallTableFire.SetActive(true);
        Transform childTransform = smallTableFire.transform.Find("Fire_Green");
        if (childTransform != null)
        {
            ParticleSystem fireParticles = childTransform.gameObject.GetComponent<ParticleSystem>();
            fireParticles.Play();
        }
    }

    void StartComTableFireEffect() {
        comTableFire.SetActive(true);
        Transform childTransform = comTableFire.transform.Find("Fire_Blue");
        if (childTransform != null)
        {
            ParticleSystem fireParticles = childTransform.gameObject.GetComponent<ParticleSystem>();
            fireParticles.Play();
        }
    }

    void LightFlickering() {
        flickerLight = true;
        if (Timer > 0) {
            Timer -= Time.deltaTime;
        }
        if (Timer <= 0) {
            tableLight.enabled = !tableLight.enabled;
            Timer = Random.Range(MinTime, MaxTime);
        }
    }

    public void StartEarthquakeScene()
    {
        InvokeRepeating("ShakeObjects", 0, 0.01f);
        Invoke("StartCollapse", collapseDelay);
        // Invoke("TestEndEarthquakeLevel", 30f);
        Invoke("StopEarthquake", 60);

    }

    void ShakeObjects() {
        foreach (var obj in objectsToShake)
        {
            Vector3 randomForce = new Vector3(Random.Range(-shakeForce, shakeForce), 
                                            0, 
                                            Random.Range(-shakeForce, shakeForce));
            obj.GetComponent<Rigidbody>().AddForce(randomForce, ForceMode.Impulse);

            obj.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void StopEarthquake() {
        CancelInvoke("ShakeObjects");
        // for (int i = 0; i < objectsToShake.Length; i++)
        // {
        //     objectsToShake[i].transform.position = originalObjectPositions[i];
        // }
        if (BedroomSceneState.IsPlayerUnderCorrectTable()) {
            EndGame(true);
        } else {
            EndGame(false);
        }
        
    }

    void StartCollapse() {
        ceilingGameObject.SetActive(false);
        ceilingFanNoEarthquake.SetActive(false);
        crumblingCeiling.SetActive(true);
        StartCoroutine(CollapseChunks());
    }

    IEnumerator CollapseChunks() {
        float startTime = Time.time;
        while (Time.time - startTime < collapseDuration)
        {
            GameObject chunk = GetRandomChunk();
            if (chunk != null && !collapsedChunks.Contains(chunk))
            {
                Rigidbody rb = chunk.GetComponent<Rigidbody>();
                rb.isKinematic = false; // Disable kinematic property
                collapsedChunks.Add(chunk);
            }
            yield return new WaitForSeconds(delayBetweenChunks);
        }
    }

    GameObject GetRandomChunk() {
        if (ceilingChunks.Length == 0)
            return null;
        int randomIndex = Random.Range(0, ceilingChunks.Length);
        return ceilingChunks[randomIndex];
    }


    private void CheckPlayerUnderSturdyTable()
    {
        if (IsPlayerBelowTable(player, sturdyTable))
        {
            // Player is under the sturdy table
            BedroomSceneState.SetUnderCorrectTable(true);
        } else {
            BedroomSceneState.SetUnderCorrectTable(false);
        }
    }

    // This function checks if player is below the sturdy table and is also within the boundaries of the sturdy table
    private bool IsPlayerBelowTable(GameObject player, GameObject table)
    {
        if (table == null)
            return false;

        // Check if the player is below the specified table based on their positions
        return player.transform.position.y < table.transform.position.y && (sturdyTableAreaCollider.bounds.Contains(player.transform.position));
    }

    private void EndGame(bool isWinner)
    {
        isEarthquakeLevelOver = true;
        if (isWinner)
        {
            Debug.Log("Congratulations! You win!");
        }
        else
        {
            Debug.Log("You lost! Try again.");
        }
    }

}
