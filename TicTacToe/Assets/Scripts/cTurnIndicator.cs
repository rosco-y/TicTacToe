using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cTurnIndicator : MonoBehaviour
{

        private void OnMouseDown()
        {
                if (!cGameManager.GameOverFlag)
                {
                        return;
                }
                else
                {
                        cGameManager.Instance.NewGame();
                }
        }

}

