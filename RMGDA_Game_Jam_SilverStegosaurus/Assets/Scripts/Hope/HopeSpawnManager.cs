using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopeSpawnManager : MonoBehaviour
{
   public GameObject hope;
   public GameObject[] spawnPoints;

   private int _randomSpawnIndex;

   // Start is called before the first frame update
   void Start()
   {
      _randomSpawnIndex = Random.Range(0, spawnPoints.Length);
      Instantiate(hope, spawnPoints[_randomSpawnIndex].transform.position, Quaternion.identity);
   }

   // Update is called once per frame
   void Update()
   {

   }
}
