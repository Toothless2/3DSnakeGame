using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class Snowing : MonoBehaviour
    {
        public GameObject snowStuff;

        void Awake()
        {
            if(Constants.snowing)
            {
                snowStuff.SetActive(true);
            }
        }
    }
}