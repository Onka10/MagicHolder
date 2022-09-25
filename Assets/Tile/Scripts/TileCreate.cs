using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace u1w.Tiles
{
    public class TileCreate : MonoBehaviour
    {
        [SerializeField] static float xOffset = 1f;
        [SerializeField] static float zOffset = 1f;

        /// <Summary>
        /// Prefabからブロックとして使うオブジェクトを生成します。
        /// </Summary>
        public static TileID CreateBlockObject(GameObject obj,GameObject prefabObj){

            for (int j = 0; j < StageSetting.X; j++){
                for (int x = 0; x < StageSetting.Y; x++){
                    //0,0は生成済みだから無し
                    if(x==0 && j==0)    continue;

                    // ゲームオブジェクトを生成します。
                    //obj(x,y)で座標の位置
                    GameObject objPP = Instantiate(prefabObj, Vector3.zero, Quaternion.identity);
                    GameObject objPM = Instantiate(prefabObj, Vector3.zero, Quaternion.identity);
                    GameObject objMP = Instantiate(prefabObj, Vector3.zero, Quaternion.identity);
                    GameObject objMM = Instantiate(prefabObj, Vector3.zero, Quaternion.identity);

                    // ゲームオブジェクトの親オブジェクトを設定します。
                    objPP.transform.SetParent(obj.transform);
                    objPM.transform.SetParent(obj.transform);
                    objMP.transform.SetParent(obj.transform);
                    objMM.transform.SetParent(obj.transform);

                    // ゲームオブジェクトの位置を設定します。
                    float xPos = xOffset * x;
                    float zPos = zOffset * j;

                    objPP.transform.localPosition = new Vector3(xPos, 0f, zPos);
                    objPM.transform.localPosition = new Vector3(xPos, 0f, zPos * -1);
                    objMP.transform.localPosition = new Vector3(xPos * -1, 0f, zPos);
                    objMM.transform.localPosition = new Vector3(xPos * -1, 0f, zPos * -1);
                }
            }
            return new TileID();

        }
    }
}

