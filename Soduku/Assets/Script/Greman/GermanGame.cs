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
    public Button ButtonNote;

    // Start is called before the first frame update
    void Start()
    {
        CreateFrefabs();
        CreateControll();
        CreateSodoku();
    }
    private void CreateSodoku(){
        sodokuObject sodokuobject = SodokuGennerator.CreateSodokuObject();
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                var currentValue = sodokuobject.value[row,col];
                if(currentValue != 0){
                var field_object = FieldPerfabObjectDic[new Tuple<int, int>(row,col)];
                field_object.setnumber(currentValue);
                field_object.IsChangeAble = false;
                }
            }
        }
    }

    private bool IsButtonNoteActive = false;
    public void ClickOn_ButtonNote(){
        Debug.Log($"Click on ButtonNote");
        if(IsButtonNoteActive){
            IsButtonNoteActive = false;
            ButtonNote.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }else{
            IsButtonNoteActive = true;
            ButtonNote.GetComponent<Image>().color = new Color(0.71f, 0.95f, 0.97f, 1f);
        }
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
            }
    }
    // Theo dõi FieldPerfabObject hiện đang được di chuột.
    private FieldPerfabObject currentHoverObject;

    private void ClickOn_ControllPrefab(controllprefabObject controllprefab){
        Debug.Log($"Click on controllPrefab number: {controllprefab.number}");
         
         if(currentHoverObject != null){
            if(IsButtonNoteActive){
                currentHoverObject.SetnoteNumber(controllprefab.number);
            }else{
                currentHoverObject.setnumber(controllprefab.number);
            }
        }
    }
    // Phương thức được gọi khi một phiên bản FieldPrefabs được nhấp vào.
    private void ClickOnFikedFrefab(FieldPerfabObject fieldPerfabObject){
        Debug.Log($"Click on Prefab Row: {fieldPerfabObject.Row}, Clo: {fieldPerfabObject.Col}");
        // Bỏ đặt chế độ click chuột trên đối tượng được di chuột trước đó (nếu có).
        if(fieldPerfabObject.IsChangeAble){
            if(currentHoverObject != null){
                currentHoverObject.UnSetHoverMode();
            }
            // Đặt chế độ click chuột trên đối tượng được nhấp chuột.
            currentHoverObject = fieldPerfabObject;
            fieldPerfabObject.SetHoverMode();

            }
        }
}
 