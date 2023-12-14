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
            _animator = GetComponent<Animator>();
            _animator.SetTrigger(MathRunConfig.IDLE);
        }

        void Update()
        {

        }

        public void SetAnimRun()
        {
            _animator.SetTrigger(MathRunConfig.RUN);
        }

        public void SpawnWood()
        {
            var posPlayer = transform.position;
            if (posPlayer.z - _posZStart > MathRunConfig.DISTANCE_PLAYER)
            {
                var objWood = wood.Init(posPlayer);
                var posWood = objWood.transform.position;
                posPlayer.y = posWood.y + MathRunConfig.DISTANCE_HEIGHT_WOOD;
                posPlayer.z = posWood.z;
                _posZStart = posWood.z;
            }
        }

        public void Run()
        {
            var pos = transform.position;
            pos.z += _speed * Time.deltaTime;
            transform.position = pos;
            DetectInputWindow();
        }

        private void MoveLeft()
        {
            if (_currenHorizontalSpeed < -2.4) return;

            _currenHorizontalSpeed -= _horizontalSpeed * Time.deltaTime;

            var pos = transform.position;
            pos.x = _currenHorizontalSpeed;

            transform.position = pos;
        }

        private void MoveRight()
        {
            if (_currenHorizontalSpeed > 2.4) return;

            _currenHorizontalSpeed += _horizontalSpeed * Time.deltaTime;

            var pos = transform.position;
            pos.x = _currenHorizontalSpeed;

            transform.position = pos;
        }

        private void DetectInputWindow()
        {
            if (GetState() != PlayerState.STACK_WOOD)
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    MoveLeft();
                }

                if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    MoveRight();
                }
            }

            //if (CanSpawnWood())
            //{
            //    if (Input.GetKeyDown(KeyCode.Space))
            //    {
            //        SetState(PlayerState.STACK_WOOD);
            //        var pos = transform.position;
            //        _posZStart = pos.z;
            //        wood.SetCurrentItem(null);
            //    }

            if (Input.GetKey(KeyCode.Space))
            {
                SetState(PlayerState.STACK_WOOD);
                SpawnWood();
            }

            //    if (Input.GetKeyUp(KeyCode.Space))
            //    {
            //        SetState(PlayerState.RUN);
            //        wood.SetCurrentItem(null);
            //        _timeEndSpawnWood = DateTime.UtcNow;
            //    }
            //}
            //else
            //{
            //    if (MathRunDataManager.Instance.CountWood <= 0 && GetState() != PlayerState.RUN)
            //    {
            //        SetState(PlayerState.RUN);
            //    }
            //}


        }
        public void SetState(PlayerState state)
        {
            _currentState = state;
        }
        public PlayerState GetState()
        {
            return _currentState;
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
