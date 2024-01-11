using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UI;

namespace MathRun
{
    public class MathRunManager : MonoBehaviour
    {
        [SerializeField] private MathRunPlayer player;
        [SerializeField] private MathRunUI mathRunUI;
        [SerializeField] private MathRunMap map;

        [Header("UI 2D")]
        [SerializeField] private GameObject objStartGame;
        [SerializeField] GameObject popupTutorial;
        [SerializeField] GameObject popupSetting;
        [SerializeField] Button btnClosePopup;
        [SerializeField] Button btnClosePopupSetting;
        [SerializeField] private Button btnPlay;
        [SerializeField] private Button btnSetting;
        [SerializeField] private Button btnTutorial;

        [Header("End Game")]
        [SerializeField] GameObject popupEndGame;
        [SerializeField] Button btnReplay;
        [SerializeField] Button btnMenu;
        [SerializeField] TMP_Text txtEndGameScore;

        private bool _isGameStarted = false;

        public static MathRunManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        private void OnDisable()
        {
            Physics.gravity = new Vector3(0, -9.8f, 0);
        }
        void Start()
        {
            SoundManager.Instance.PlayBg(ESoundType.Bg_Game, true);
            player.SetState(PlayerState.IDLE);
            UpdateWood();
            ResetGame();
            btnPlay.onClick.AddListener(OnClickPlay);
            btnClosePopup.onClick.AddListener(OnClickCloseTutorial);
            btnClosePopupSetting.onClick.AddListener(OnClickCloseSetting);
            btnTutorial.onClick.AddListener(OnClickShowTutorial);
            btnSetting.onClick.AddListener(OnClickShowSetting);
            btnReplay.onClick.AddListener(OnClickReplay);
            btnMenu.onClick.AddListener(OnClickBackMenu);

        }

        void Update()
        {
            //if(player.GetState() == PlayerState.IDLE && (Input.GetKeyDown(KeyCode.P)))
            //{
            //    StartGame();
            //}
            if (!_isGameStarted || player.GetState() == PlayerState.DEAD || player.GetState() == PlayerState.WIN) return;
            player.Run();
            map.Init(player);
            UpdateDistanceMove(player);


        }

        private void OnClickCloseTutorial()
        {
            popupTutorial.SetActive(false);
        }

        private void OnClickCloseSetting()
        {
            popupSetting.SetActive(false);
        }

        private void OnClickShowTutorial()
        {
            popupTutorial.SetActive(true);
        }

        private void OnClickShowSetting()
        {
            popupSetting.SetActive(true);
        }
        private void OnClickPlay()
        {
            objStartGame.SetActive(false);
            if (player.GetState() == PlayerState.IDLE)
            {
                StartGame();
            }

        }

        private void OnClickReplay()
        {
            ResetGame();
            StartGame();
        }

        private void OnClickBackMenu()
        {
            ResetGame();
            _isGameStarted = false;
            objStartGame.SetActive(true);
            popupEndGame.SetActive(false);
        }





        private void StartGame()
        {
            _isGameStarted = true;
            player.SetAnimRun();
            player.SetState(PlayerState.RUN);
        }

        public void EndGame()
        {
            popupEndGame.SetActive(true);
            txtEndGameScore.text = MathRunData.Instance.DistanceMove.ToString();
        }

        public void UpdateWood()
        {
            mathRunUI.SetCountWood();
        }

        public void UpdateDistance()
        {
            mathRunUI.SetDistance();
        }

        private void UpdateDistanceMove(MathRunPlayer player)
        {
            var pos = player.transform.localPosition;
            MathRunData.Instance.AddDistance(pos.z);
        }

        public void ResetGame()
        {
            popupEndGame.SetActive(false);
            MathRunData.Instance.ResetData();
            map.ResetMap();
            player.ResetPlayer();
            _isGameStarted= false;
        }

        
    }
}
