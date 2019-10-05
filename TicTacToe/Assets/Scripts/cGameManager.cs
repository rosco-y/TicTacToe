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
        public Material _white;
        #endregion

        #region PRIVATE
        //static cGameManager _instance;
        #endregion

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

        public cGameManager Instance
        {
                get { return this; }
        }

        public void NewGame()
        {
                cSuperGrid.Instance.Rotate = false;
                cSuperGrid.Instance.ColorSuperGridWinner(_white);
        }

}
