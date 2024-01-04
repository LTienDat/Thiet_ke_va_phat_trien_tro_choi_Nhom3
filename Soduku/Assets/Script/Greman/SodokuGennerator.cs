using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using Unity.VisualScripting;
using UnityEngine;

public class SodokuGennerator
{
    public static sodokuObject CreateSodokuObject(){
        finalsodokuObject = null;
        sodokuObject sodoku_object = new sodokuObject();
        CreateRandomGroups(sodoku_object);
        if(TryToSolve(sodoku_object)){
            sodoku_object = finalsodokuObject;
        }
        else{
            throw new System.Exception("something went wrong");
        }
        return sodoku_object;
    }
    private static sodokuObject finalsodokuObject;
    private static bool TryToSolve(sodokuObject Sodoku_object){
        // find empty fields which can be filled
        if(HasEmptyFieldsToFill( Sodoku_object, out int row, out int col)){
            List<int> posssibleValues = GetPossibleValues(Sodoku_object, row, col);
            foreach(var possibleValue in posssibleValues){
                sodokuObject nextsodokuObject = new sodokuObject();
                nextsodokuObject.value = (int[,]) Sodoku_object.value.Clone();
                nextsodokuObject.value[row, col] = possibleValue;
                if(TryToSolve(nextsodokuObject)){
                    return true;
                }
            }
        }
        // has sodokuobject empty fields
        if(HasEmptyFields(Sodoku_object)){
            return false;
        }
        finalsodokuObject = Sodoku_object;
        return true;
        //finish
    }

    private static bool HasEmptyFields(sodokuObject Sodoku_object)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (Sodoku_object.value[i, j] == 0)
                {
                    return true;
                }
            }
        }
        return false;
    }
    private static List<int> GetPossibleValues(sodokuObject sodoku_object, int row, int col){
        List<int> possibleValues = new List<int>();
        for (int value = 1; value < 10; value++)
        {
            if(sodoku_object.IsPossibleNumberInCPosition(value, row, col)){
                possibleValues.Add(value);
            }
        }
        return possibleValues;
    }
    private static bool HasEmptyFieldsToFill(sodokuObject sodoku_object, out int row, out int col)
    {
    row = 0;
    col = 0;
    int amountOfPossibleValues = 10;
    for (int i = 0; i < 9; i++)
    {
        for (int j = 0; j < 9; j++)
        {
            if (sodoku_object.value[i, j] == 0)
            {
                int currentAmount = GetPossibleAmountofValues(sodoku_object, i, j);
                if (currentAmount != 0)
                {
                    if (currentAmount < amountOfPossibleValues)
                    {
                        amountOfPossibleValues = currentAmount;
                        row = i;
                        col = j;
                    }
                }
            }
        }
    }
    if (amountOfPossibleValues == 10)
    {
        return false;
    }
    return true;
    }
    private static int GetPossibleAmountofValues(sodokuObject sodoku_object, int row, int col){
        int amount = 0;
        for (int k = 1; k < 10; k++)
        {
            if(sodoku_object.IsPossibleNumberInCPosition(k, row, col)){
                amount++;
            }
            
        }
        return amount;
    }
    public static void CreateRandomGroups(sodokuObject sodoku_object){
        List<int> values = new List<int>(){0,1,2};
        int index = Random.Range(0, values.Count);
        InsertRandomGroup(sodoku_object, 1 + values[index]);
        values.RemoveAt(index);

        index = Random.Range(0, values.Count);
        InsertRandomGroup(sodoku_object, 4 + values[index]);
        values.RemoveAt(index);

        index = Random.Range(0, values.Count);
        InsertRandomGroup(sodoku_object, 7 + values[index]);
        values.RemoveAt(index);

    }
    public static void InsertRandomGroup(sodokuObject Sodoku_object, int group){
        Sodoku_object.GetGroupIndex(group, out int startRow, out int startCol);
        List<int> values = new List<int>(){1,2,3,4,5,6,7,8,9};
        for (int row = startRow; row < startRow + 3; row++)
        {
            for (int col = startCol; col < startCol + 3; col++)
            {
                int index = Random.Range(0, values.Count);
                Sodoku_object.value[row, col] = values[index];
                values.RemoveAt(index);
            }
        }
    }
}
