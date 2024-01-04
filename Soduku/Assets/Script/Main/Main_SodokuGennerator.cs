using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_SodokuGennerator
{
public static sodokuObject CreateSodokuObject(){
        sodokuObject sodoku_object = new sodokuObject();
        CreateRandomGroups(sodoku_object);
        return sodoku_object;
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
        for (int row = 0; row < startRow + 3; row++)
        {
            for (int col = 0; col < startCol + 3; col++)
            {
                int index = Random.Range(0, values.Count);
                Sodoku_object.value[row, col] = values[index];
                values.RemoveAt(index);
            }
        }
    }
}
