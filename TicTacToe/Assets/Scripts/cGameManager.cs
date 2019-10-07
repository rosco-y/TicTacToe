using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cGameManager : MonoBehaviour
{
        #region PUBLIC CONST
        public const int REDVALUE = 3;
        public const int GREENVALUE = 5;
        public const int GRIDSIZE = 3;
        public const int CATSGAME = 7;  // cat's grid.
        #endregion

        #region PUBLIC STATIC
        public static bool REDTURN = true;
        public static bool GameOverFlag { set; get; } = false;
        #endregion

        #region PUBLIC
        
        #endregion

        #region PRIVATE
        static cGameManager _instance;
        
        #endregion

        private void Awake()
        {
                _instance = this;
        }

        void Start()
        {
                cSpotlight.Instance.SetSpotWidth(true);
                //_instance = this;
        }

        public static void GameOver()
        {
                GameOverFlag = true;
                cSpotlight.Instance.SetSpotWidth(true);
                cSuperGrid.Instance.Rotate = true;
        }

        public static cGameManager Instance
        {
                get
                { 
                        if (_instance == null)
                        {
                                GameObject go = new GameObject("cGameManager");
                                go.AddComponent<cGameManager>();
                        }
                        return _instance;
                }
        }

        public void NewGame()
        {
                cSuperGrid.Instance.Rotate = false;
                cSuperGrid.Instance.ColorSuperGridWinner(cCell.White);
                GameOverFlag = false;
                cSuperGrid.Instance.NewGameSettings();
        }

}
