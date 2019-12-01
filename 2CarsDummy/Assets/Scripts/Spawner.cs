using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float delay = 1.5f;
    public Transform[] spawnPoints;
    public GameObject[] spawnee;
    public ObjectPooler pooler;

    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(spawnable());
    }


    IEnumerator spawnable()
    {
        while (true)
        {
            int randomPoint = Random.Range(0, spawnPoints.Length);
            int randomShape = Random.Range(0, spawnee.Length);
            //Debug.Log(spawnee[randomShape].name);
            GameObject gObj = pooler.GetObject(spawnee[randomShape].name);
            gObj.transform.position = spawnPoints[randomPoint].position;
            gObj.transform.rotation = spawnPoints[randomPoint].rotation;
            gObj.SetActive(true);

            yield return new WaitForSeconds(delay);
        }

    }
}
