using UnityEngine;

public class GetTile
{
    public IResultRay RayCast(Vector3 nowPosition){
        Ray Ray = new Ray (nowPosition + new Vector3 (0, 0, 0), Vector3.down);
        RaycastHit hit;

        //デバッグ
        Debug.DrawRay(Ray.origin, Ray.direction * 10, Color.red,10f);

        if (Physics.Raycast(Ray,out hit)){
            //タイル入手
            return new ResultRay(hit.collider.gameObject);
        }else   return new ResultRay();

    }
}

public class ResultRay : IResultRay{
    private GameObject resultObject;
    private bool isCompleted;

    public ResultRay(GameObject res){
        isCompleted = true;
        resultObject = res;
    }

    public ResultRay(){
        isCompleted = false;
    }

    public bool Result(out GameObject ResultGameObject){
        ResultGameObject = resultObject;
        return isCompleted;
    }
}

public interface IResultRay{
    public bool Result(out GameObject ResultGameObject);
}


