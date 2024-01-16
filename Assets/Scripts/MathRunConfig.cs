using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MathRun
{
    public class MathRunConfig
    {
        public const float TIME_END_GAME = 180f;

        public const int COUNT_WOOD_START = 100;

        public const int NUMBER_LIMIT_UPDATE_SPEED = 10;
        public const float SPEED_CHANGE_PERCENT = 5f;
        public const float SPEED = 8f;
        public const float HORIZONTAL_SPEED = 3f;
        public const float JUMP_FORCE = 5f;

        public const float TIME_DELAY_JUMP_DONE = 0.05f;
        public const float TIME_DELAY_SPAWN_WOOD = 0.5f;
        public const float TIME_DELAY_RUN_END = 1f;
        public const float TIME_DELAY_END_GAME = 1f;


        public const float LENGHT_PER_MAP = 55f;
        public const float DELTA_DISTANCE_MAP_PLAYER = 5f;
        public const float DELTA_DISTANCE_BACKGROUND_PLAYER = 10f;
        public const float DISTANCE_PER_BACKGROUND = 470f;

        public const float DISTANCE_PLAYER = 0.3f;
        public const float DISTANCE_PER_WOOD = 0.1f;
        public const float DISTANCE_HEIGHT_WOOD = 0.15f;
        public const float DISTANCE_END_GAME = 5f;

        public const float MAX_WOOD_APPEAR = 10f;

        public const float GRAVITY_DEAD = -2f;
        public const float GRAVITY_NORMAL = -50f;

        public const int POINT_BONUS = 1;
        public const int LAYER_DEAD = 6;
        public const int LAYER_WIN = 7;
        public const int LAYER_PLAYER = 8;
        //anim 

        public const string RUN = "Run";
        public const string IDLE = "Idle";
        public const string JUMPWATER = "JumpWater";
        public const string SWIMUP = "SwimUp";
        public const string WIN = "Win{0}";
        public const string CHEERING = "cheering{0}";
        public const string EFFECT_BONUS = "StartEffect";



    }
}
