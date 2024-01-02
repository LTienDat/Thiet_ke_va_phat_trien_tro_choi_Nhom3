using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FieldPerfabObject
{
    // Các trường để lưu trữ phiên bản hàng, cột và GameObject.
    private readonly int _row;
    private int _col;
    private GameObject _instance;

    // Hàm tạo để khởi tạo đối tượng bằng GameObject, hàng và cột.
    public FieldPerfabObject(GameObject instance, int row, int col)
    {
        _row = row;
        Col = col;
        _instance = instance;
    }
    // Thuộc tính lấy hàng (chỉ đọc).
    public int Row { get => _row; }
    // Thuộc tính lấy và thiết lập cột.
    public int Col { get => _col; set => _col = value; }
    // Phương thức thiết lập chế độ di chuột, thay đổi màu của thành phần Image liên quan.
    public void SetHoverMode()
    {
        _instance.GetComponent<Image>().color = new Color(0.71f, 0.95f, 0.97f, 1f);
    }
    // Phương pháp bỏ đặt chế độ di chuột, khôi phục màu gốc.
    public void UnSetHoverMode()
    {
        _instance.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
    }
    public void setnumber(int number){
        _instance.GetComponentInChildren<Text>().text = number.ToString();
    }
}