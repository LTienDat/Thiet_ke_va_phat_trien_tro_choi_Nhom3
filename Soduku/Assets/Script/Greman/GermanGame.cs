using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class GremanGame : MonoBehaviour
{
    public GameObject MainPenal;
    public GameObject SodukuFiledPenal;
    public GameObject FieldPrefabs;
    public GameObject ControllPanal;
    public GameObject ControllPrefab;

    // Start is called before the first frame update
    void Start()
    {
        CreateFrefabs();
        CreateControll();
    }
    // Từ điển để lưu trữ các phiên bản FieldPerfabObject dựa trên hàng và cột của chúng.
    private Dictionary<Tuple<int, int>, FieldPerfabObject> FieldPerfabObjectDic = 
        new Dictionary<Tuple<int, int>, FieldPerfabObject>();
    // Phương thức tạo phiên bản FieldPrefabs và khởi tạo lưới trò chơi.
     public void CreateFrefabs(){
         for(int row = 0; row < 9; row++){
            for(int col = 0; col < 9; col++){
                GameObject instance = GameObject.Instantiate(FieldPrefabs, SodukuFiledPenal.transform);
                // Tạo một FieldPerfabObject và thêm nó vào từ điển.
                FieldPerfabObject fieldPerfabObject = new FieldPerfabObject(instance, row, col);
                FieldPerfabObjectDic.Add(new Tuple<int, int>(row, col), fieldPerfabObject);
                // Thêm trình xử lý sự kiện nhấp chuột vào thành phần Nút trong phiên bản.
                instance.GetComponent<Button>().onClick.AddListener( () => ClickOnFikedFrefab(fieldPerfabObject));
            }
        }
    }
         public void CreateControll(){
            for(int i = 1; i <= 9; i++){
                GameObject instance = GameObject.Instantiate(ControllPrefab, ControllPanal.transform);
                instance.GetComponentInChildren<Text>().text = i.ToString();
                controllprefabObject controllprefab = new controllprefabObject();
                controllprefab.number = i;

                // Thêm trình xử lý sự kiện nhấp chuột vào thành phần Nút trong phiên bản.
                instance.GetComponent<Button>().onClick.AddListener( () => ClickOn_ControllPrefab(controllprefab));
            // if (instance != null)
            // {
            //     Text textComponent = instance.GetComponentInChildren<Text>();
            //     if (textComponent != null)
            //     {
                   
            //     }          
            // }
            }
    }
    // Theo dõi FieldPerfabObject hiện đang được di chuột.
    private FieldPerfabObject currentHoverObject;

    private void ClickOn_ControllPrefab(controllprefabObject controllprefab){
        Debug.Log($"Click on controllPrefab number: {controllprefab.number}");
         if(currentHoverObject != null){
            currentHoverObject.setnumber(controllprefab.number);
        }
    }
    // Phương thức được gọi khi một phiên bản FieldPrefabs được nhấp vào.
    private void ClickOnFikedFrefab(FieldPerfabObject fieldPerfabObject){
        Debug.Log($"Click on Prefab Row: {fieldPerfabObject.Row}, Clo: {fieldPerfabObject.Col}");
        // Bỏ đặt chế độ click chuột trên đối tượng được di chuột trước đó (nếu có).
        if(currentHoverObject != null){
            currentHoverObject.UnSetHoverMode();
        }
        // Đặt chế độ click chuột trên đối tượng được nhấp chuột.
        currentHoverObject = fieldPerfabObject;
        fieldPerfabObject.SetHoverMode();

    }
}
 