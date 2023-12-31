using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class sodokuObject
{
    public int[,] value = new int[9,9];
    public void GetGroupIndex(int group, out int startRow, out int startCol){
        startRow = 0;
        startCol = 0;
        switch(group){
            case 1:
                startRow = 0;
                startCol = 0;
                break;
            case 2:
                startRow = 0;
                startCol = 3;
                break;
            case 3:
                startRow = 0;
                startCol = 6;
                break;
            case 4:
                startRow = 3;
                startCol = 0;
                break;
            case 5:
                startRow = 3;
                startCol = 3;
                break;
            case 6:
                startRow = 3;
                startCol = 6;
                break;
            case 7:
                startRow = 6;
                startCol = 0;
                break;
            case 8:
                startRow = 6;
                startCol = 3;
                break;
            case 9:
                startRow = 6;
                startCol = 6;
                break;
        }
    }

    public bool IsPossibleNumberInCPosition(int number, int row, int col){
        if(IsPossibleNumberInRow(number, row) && IsPossibleNumberInCol(number, col)){
            if(IsPossibleNumberInGroup(number, GetGroup(row, col))){
                return true;
            }
        }
        return false;
    }
    private int GetGroup(int row, int col){
        if(row < 3){
            if(col < 3) return 1;
            if(col < 6) return 2;
            else return 3;
        }
        if(row < 6){
            if(col < 3) return 4;
            if(col < 6) return 4;
            else return 6;
        }
        else{
            if(col < 3) return 7;
            if(col < 6) return 7;
            else return 9;
        }
    }
    private bool IsPossibleNumberInRow(int number, int row){
        for (int i = 0; i < 9; i++)
        {
            if(value[row, i] == number){
                return false;
            }
        }
        return true;
    }
    private bool IsPossibleNumberInCol(int number, int col){
        for (int i = 0; i < 9; i++)
        {
            if(value[i, col] == number){
                return false;
            }
        }
        return true;
    }
    private bool IsPossibleNumberInGroup(int number, int group){
        GetGroupIndex(group, out int startRow, out int startCol);
        for (int row = startRow; row < startRow + 3; row++)
        {
            for (int col = startCol; col < startCol + 3; col++)
            {
                if(value[row, col] == number){return false;}
            }
        }
        return true;
    }
}
