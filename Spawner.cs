using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject [] objectsToSpwan;
    public GameObject bomb;
    public float minwait = 0.3f;
    public float maxWait = 1.0f;
    public Transform[] spawnPlaces;
    public float minforce = 12f ;
    public float maxForce = 17f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnFruit());
    }

   private IEnumerator spawnFruit()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minwait, maxWait));
            
            Transform temp = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            GameObject objct = null;
            float percentage = Random.Range(0, 100);
            if (percentage < 20) // generate a bomb
                objct = bomb;
            else   // generate a fruit
                objct = objectsToSpwan[Random.Range(0, objectsToSpwan.Length)];

            GameObject fruit = Instantiate(objct, temp.position, temp.rotation);

            fruit.GetComponent<Rigidbody2D>().AddForce(temp.transform.up * Random.Range(minforce,maxForce), ForceMode2D.Impulse);

            Destroy(fruit, 4f);
        }
    }
}
