using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NucleonSpawner : MonoBehaviour
{
    public Nucleon[] nucleonPrefabs;

    [SerializeField] private float timeBetweenSpawns = 0.05f;
    [SerializeField] private float spawnDistance = 15.0f;

    private Slider spawnTimeSlider;

    float timeSinceLastSpawn;

    void Start()
    {
        spawnTimeSlider = GameObject.FindGameObjectWithTag("SpawnTimeSlider").GetComponent<Slider>();
        SetSpawnTimeSliderValue();
    }

    void Update()
    {
        SetSpawnTimeSliderValue();
    }

    void FixedUpdate()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= timeBetweenSpawns)
        {
            timeSinceLastSpawn -= timeBetweenSpawns;
            SpawnNucleon();
        }
    }

    void SpawnNucleon()
    {
        Nucleon prefab = nucleonPrefabs[Random.Range(0, nucleonPrefabs.Length)];
        Nucleon spawn = Instantiate<Nucleon>(prefab);
        spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
    }

    void SetSpawnTimeSliderValue()
    {
        spawnTimeSlider.value = timeBetweenSpawns;
    }

    public void SetTimeBetweenSpawns(float value)
    {
        timeBetweenSpawns = value;
    }
}
