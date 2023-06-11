using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] private UIBoardPage boardPageUI;

    public int boardSize = 8;


    private void Awake()
    {
        boardPageUI.InitializeBoardUI(boardSize);

        boardPageUI.Show();
    }
}
