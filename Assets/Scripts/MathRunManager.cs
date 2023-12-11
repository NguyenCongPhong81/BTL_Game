using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MathRun
{
    public class MathRunManager : MonoBehaviour
    {
        [SerializeField] private MathRunPlayer player;
        void Start()
        {

        }

        
        void Update()
        {
            player.Run();
        }
    }
}
