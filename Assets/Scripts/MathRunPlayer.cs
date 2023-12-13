using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MathRun
{
    public class MathRunPlayer : MonoBehaviour
    {
        [SerializeField] private MathRunWood wood;
        [SerializeField] private CinemachineVirtualCamera camera;

        public bool IsWin { get; set; } = false;

        private Animator _animator;
        private PlayerState _currentState;

        private float _speed = MathRunConfig.SPEED;
        private float _horizontalSpeed = MathRunConfig.HORIZONTAL_SPEED;
        private float _currenHorizontalSpeed = 0;
        private float _posZStart;
        private DateTime _timeEndSpawnWood = DateTime.UtcNow;
        private Vector2 _touchStart = Vector2.zero;

        void Start()
        {

        }

        void Update()
        {
            if(PauseManager.paused) return;
            Run();
        }

        public void Run()
        {
            var pos = transform.position;
            pos.z += _speed * Time.deltaTime;
            transform.position = pos;
        }

       
    }
    public enum PlayerState
    {
        IDLE = 0,
        RUN = 1,
        JUMP = 2,
        STACK_WOOD = 3,
        DEAD = 4,
        WIN = 5,
    }
}
