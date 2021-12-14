using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneration : MonoBehaviour
{

    public GameObject treeOne;
    public int maxOneTrees;

    public GameObject treeTwo;
    public int maxTwoTrees;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxOneTrees; i++)
        {
            var position = new Vector3(Random.Range(-60.0f, 60.0f), Random.Range(15f, 30.0f), 0);
            Instantiate(treeOne, position, Quaternion.identity);
        }

        for (int i = 0; i < maxTwoTrees; i++)
        {
            var position = new Vector3(Random.Range(-60.0f, 60.0f), Random.Range(15f, 30.0f), 0);
            Instantiate(treeTwo, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    // If collision with objects tagged "Obstacle," repeat Start function.
    //    if (collision.gameObject.CompareTag("tree"))
    //    {
    //        Debug.Log("move it");
    //        Start();
    //    }
    //}
}
