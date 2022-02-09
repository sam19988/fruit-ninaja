using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;
    public int Value=0;

    public void createSlicedFruit()
    {
      GameObject inst=(GameObject)  Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

        Rigidbody [] rbsSliced = inst.transform.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody r in rbsSliced)
        {
            r.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(500f, 1000f), transform.position, 5f);
        }

        FindObjectOfType<gameManager>().increaseScore(Value);

        Destroy(inst, 4f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        blade b = collision.GetComponent<blade>();
        if (!b)
        {
            return;
        }
        createSlicedFruit();
    }
}
