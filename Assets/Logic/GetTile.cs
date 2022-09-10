using UnityEngine;

public class GetTile
{
    private GameObject resultObject;
    private bool isCompleted;


    public bool GetTileObject(Vector3 nowPosition ,out GameObject ResultGameObject){
        Ray Ray = new Ray (nowPosition + new Vector3 (0, 0, 0), Vector3.down);
        RaycastHit hit;

        //デバッグ
        Debug.DrawRay(Ray.origin, Ray.direction * 10, Color.red,10f);

        if (Physics.Raycast(Ray,out hit)){
            //タイル入手
            isCompleted = true;
            resultObject = hit.collider.gameObject;
        }else{
            isCompleted = false;

        }

        ResultGameObject = resultObject;

        return isCompleted;
    }
}