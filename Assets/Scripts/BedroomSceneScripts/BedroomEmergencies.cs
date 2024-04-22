using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomEmergencies : MonoBehaviour
{
    // FIRE RELATED
    [Header("Electrical fire related values")]
    public ParticleSystem sparksFlying;

    // Things to check for level complete
    public ParticleSystem bigSparks; // circuit breaker
    public GameObject plugFire; // yellow fire
    public GameObject smallTableFire; // green fire
    public GameObject comTableFire; // blue fire
    public float MinTime;
    public float MaxTime;
    public float Timer;
    public Light tableLight;
    private bool flickerLight = false;
    private bool bakingSodaParticlesActive;
    public bool isFireExtinguisher;
    public bool isCircuitBreaker;
    public bool isSturdyTable;
    [SerializeField] private GameObject bakingSoda;
    [SerializeField] private ParticleSystem bakingSodaParticles;
    [SerializeField] private AudioSource fuseBoxAudio;


    // EARTHQUAKE RELATED
    public static bool isEarthquakeLevelOver = false;
    [Header("Earthquake related values")]

    public float shakeMagnitude = 0.1f;
    public float shakeDuration = 10.0f;
    public float shakeForce = 5f;
    public GameObject[] objectsToShake;
    private Vector3[] originalObjectPositions;
    private Quaternion[] originalObjectRotations;

    public GameObject[] ceilingChunks; 
    public float collapseDelay = 10f; // time for ceiling to collapse once things start shakin
    public float collapseDuration = 60f; 
    public float delayBetweenChunks = 3f; 
    private List<GameObject> collapsedChunks = new List<GameObject>();
    public GameObject ceilingGameObject;
    public GameObject crumblingCeiling;
    public GameObject ceilingFanNoEarthquake;
    public GameObject sturdyTable;
    [SerializeField] private GameObject player;
    [SerializeField] BoxCollider sturdyTableAreaCollider;

    // Tooltip
    [Header("Tooltips")]
    [SerializeField] private GameObject tooltipForBigTable;
    [SerializeField] private GameObject tooltipForBakingSoda;
    [SerializeField] private GameObject tooltipForCircuitBreaker;
    [SerializeField] private GameObject tooltipForExtinguisher;

    // Sound Manager
    public SoundManager soundManager;

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
        if (GlobalState.GetLevel() == 5)
        {
            StartFireScene();
        }
        else if (GlobalState.GetLevel() == 6)
        {
            StartEarthquakeScene();
        }
        

        // originalObjectPositions = new Vector3[objectsToShake.Length];
        // for (int i = 0; i < objectsToShake.Length; i++)
        // {
        //     originalObjectPositions[i] = objectsToShake[i].transform.position;
        // }
   
    }

    // Update is called once per frame
    void Update()
    {
        if (flickerLight)
            LightFlickering();

        // Check if the object is tilted more than 90 degrees
        if (Vector3.Angle(bakingSoda.transform.up, Vector3.up) > 90f)
        {
            if (!bakingSodaParticlesActive)
            {
                // Start emitting particles
                bakingSodaParticles.Play();
                bakingSodaParticlesActive = true;
            }
        }
        else
        {
            if (bakingSodaParticlesActive)
            {
                // Stop emitting particles
                bakingSodaParticles.Stop();
                bakingSodaParticlesActive = false;
            }
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
    public void StartFireScene() {
        originalObjectPositions = new Vector3[objectsToShake.Length];
        originalObjectRotations = new Quaternion[objectsToShake.Length];
        for (int i = 0; i < objectsToShake.Length; i++)
        {
            originalObjectPositions[i] = objectsToShake[i].transform.position;
            originalObjectRotations[i] = objectsToShake[i].transform.rotation;
            Debug.Log("setting original pos");
        }
        sparksFlying.Play();
        Invoke("StartElectricityEffect", 10f);
        InvokeRepeating("StartPlugFireEffect", 5, 10);
        Invoke("LightFlickering", 20f);
        Invoke("StartSmallTableFireEffect", 35f);
        Invoke("StartComTableFireEffect", 45f);
    }

    void StartVoiceOver1() {
        soundManager.PlaySmellBurning();
    }

    void StartVoiceOver2() {
        soundManager.PlayFireOnAdaptor();
    }

    void StartElectricityEffect() {
        StartVoiceOver1();
        bigSparks.Play();
    }

    void StartPlugFireEffect() {
        if (bigSparks.isPlaying && !plugFire.activeSelf) {
            StartVoiceOver2();
            plugFire.SetActive(true);
            Transform childTransform = plugFire.transform.Find("Fire_Yellow");
            if (childTransform != null)
            {
                ParticleSystem fireParticles = childTransform.gameObject.GetComponent<ParticleSystem>();
                fireParticles.Play();
            }
        }
    }

    void StartSmallTableFireEffect() {
        smallTableFire.SetActive(true);
        BedroomSceneState.SetExtinguishGreenFlames(false);
        Transform childTransform = smallTableFire.transform.Find("Fire_Green");
        if (childTransform != null)
        {
            ParticleSystem fireParticles = childTransform.gameObject.GetComponent<ParticleSystem>();
            fireParticles.Play();
        }
    }

    void StartComTableFireEffect() {
        comTableFire.SetActive(true);
        BedroomSceneState.SetExtinguishBlueFlames(false);
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

    public void SelectFuseBox() {
        Debug.Log("fusebox selected");
        if (!plugFire.activeSelf) {
            BedroomSceneState.SetExtinguishYellowFlames(true);
            CancelInvoke("StartElectricityEffect");
            CancelInvoke("StartPlugFireEffect");
            CancelInvoke("LightFlickering");
            CancelInvoke("StartSmallTableFireEffect");
            CancelInvoke("StartComTableFireEffect");
            if (!comTableFire.activeSelf) {
            BedroomSceneState.SetExtinguishBlueFlames(true);
            }
            if (!smallTableFire.activeSelf) {
                BedroomSceneState.SetExtinguishGreenFlames(true);
            }
        }
        CancelInvoke("StartElectricityEffect");
        CancelInvoke("StartPlugFireEffect");
        // CancelInvoke("LightFlickering");
        // CancelInvoke("StartSmallTableFireEffect");
        // CancelInvoke("StartComTableFireEffect");

        BedroomSceneState.SetCircuitBreakerOff(true);
        fuseBoxAudio.Play();
        bigSparks.Stop();
    }

    public void StartEarthquakeScene()
    {
        // foreach (var obj in objectsToShake)
        // {
        //     if (obj == null) {
        //         Debug.LogError("An element in Objects To Shake is null.");
        //     }
        // }

        // for (int i = 0; i < objectsToShake.Length; i++)
        // {
        //     objectsToShake[i].transform.position = originalObjectPositions[i];
        //     objectsToShake[i].transform.rotation = originalObjectRotations[i];
        // }
        soundManager.PlayEarthquakeSound();
        InvokeRepeating("ShakeObjects", 0, 0.01f);
        Invoke("StartCollapse", collapseDelay);
        Invoke("StartVoiceOver3", 0.01f);
        Invoke("StartVoiceOver4", 8f);
        Invoke("StopEarthquake", 60);

    }

    void StartVoiceOver3() {
        soundManager.PlayRoomShaking();
        soundManager.PlayObjectFallSound();
    }

    void StartVoiceOver4() {
        soundManager.PlayFindASafeSpot();
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

    public void StopEarthquake() {
        CancelInvoke("ShakeObjects");
        CancelInvoke("StartCollapse");
        CancelInvoke("StartVoiceOver3");
        CancelInvoke("StartVoiceOver4");
    }

    void StartCollapse() {
        ceilingGameObject.SetActive(false);
        ceilingFanNoEarthquake.SetActive(false);
        crumblingCeiling.SetActive(true);
        StartCoroutine(CollapseChunks());
    }

    IEnumerator CollapseChunks()
    {
        float startTime = Time.time;

        // Collapse ceilingChunk(5) first
        GameObject chunk = GameObject.Find("ceilingtest (5)");
        if (chunk != null && !collapsedChunks.Contains(chunk))
        {
            Rigidbody rb = chunk.GetComponent<Rigidbody>();
            rb.isKinematic = false; // Disable kinematic property
            collapsedChunks.Add(chunk);
        }

        // Wait for a short delay before collapsing other chunks
        yield return new WaitForSeconds(delayBetweenChunks);

        // Collapse other chunks randomly
        while (Time.time - startTime < collapseDuration)
        {
            chunk = GetRandomChunk();
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
        List<GameObject> availableChunks = new List<GameObject>(ceilingChunks);
        availableChunks.Remove(GameObject.Find("ceilingtest (5)"));

        int randomIndex = Random.Range(0, availableChunks.Count);
        return availableChunks[randomIndex];
    }

    // public void hoverOnBigTableForToolTip()
    // {
    //     tooltipForBigTable.SetActive(true);
    // }
    // public void hoverOffBigTableForToolTip()
    // {
    //     tooltipForBigTable.SetActive(false);
    // }

    public void HoverOnBakingSodaToolTip() 
    {
        tooltipForBakingSoda.SetActive(true);
    }
    public void HoverOffBakingSodaToolTip() 
    {
        tooltipForBakingSoda.SetActive(false);
    }

    public void HoverOnCircuitBreakerToolTip() 
    {
        isCircuitBreaker = true;
        tooltipForCircuitBreaker.SetActive(true);
    }
    public void HoverOffCircuitBreakerToolTip() 
    {
        isCircuitBreaker = false;
        tooltipForCircuitBreaker.SetActive(false);
    }
    
    public void HoverOnExtinguisherToolTip() 
    {
        isFireExtinguisher = true;
        tooltipForExtinguisher.SetActive(true);
    }
    public void HoverOffExtinguisherToolTip() 
    {
        isFireExtinguisher = false;
        tooltipForExtinguisher.SetActive(false);
    }

}
