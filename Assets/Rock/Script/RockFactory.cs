using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

namespace u1w.Rock
{
    public class RockFactory : MonoBehaviour
    {
        // オブジェクトを生成する元となるPrefabへの参照を保持します。
        public GameObject FlameRock;
        public GameObject WindRock;
        public GameObject WaterRock;

        public void InstantRock(){
            GameObject obj = WaterRock;
            int rand = UnityEngine.Random.Range(0,3);

            if(rand == 0)      obj = FlameRock;
            else if(rand == 1) obj = WindRock;

            GameObject rock = Instantiate(obj, Vector3.zero, Quaternion.identity);
            rock.transform.SetParent(this.gameObject.transform);
            //FIXMEハードコード5,5あと、00の時のバグ潰し出来てない
            
            rock.transform.localPosition = new Vector3((float)Random.Range(0,5), 1f, (float)Random.Range(0,5));
        }

    }
}

