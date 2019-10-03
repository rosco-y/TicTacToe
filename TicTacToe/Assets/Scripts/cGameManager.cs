using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cGameManager : MonoBehaviour
{
        #region PUBLIC CONST
        public const int REDVALUE = 3;
        public const int GREENVALUE = 5;
        public const int GRIDSIZE = 3;
        #endregion

        #region PUBLIC STATIC
        public static bool REDTURN = true;
        public static bool GameOverFlag { set; get; } = false;
        #endregion

        private void Start()
        {
                cSpotlight.Instance.SetSpotWidth(true);
        }

        public static void GameOver()
        {
                GameOverFlag = true;
                cSpotlight.Instance.SetSpotWidth(true);
        }
}
