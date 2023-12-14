using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

namespace MathRun
{
    public class MathRunManager : MonoBehaviour
    {
        [SerializeField] private MathRunPlayer player;

        private bool _isGameStarted = false;
        void Start()
        {
            player.SetState(PlayerState.IDLE);
        }

        
        void Update()
        {
            if(player.GetState() == PlayerState.IDLE && (Input.anyKeyDown))
            {
                StartGame();
            }
            if (!_isGameStarted || player.GetState() == PlayerState.DEAD || player.GetState() == PlayerState.WIN) return;
            player.Run();
            
            
        }

        private void StartGame()
        {
            _isGameStarted = true;
            player.SetAnimRun();
            player.SetState(PlayerState.RUN);
        }
    }
}
