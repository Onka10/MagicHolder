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
        public GameObject prefabRock;

        public void InstantRock(){
            GameObject rock = Instantiate(prefabRock, Vector3.zero, Quaternion.identity);
            rock.transform.SetParent(this.gameObject.transform);
            //FIXMEハードコード5,5あと、00の時のバグ潰し出来てない
            
            rock.transform.localPosition = new Vector3((float)Random.Range(0,5), 1f, (float)Random.Range(0,5));
        }

    }
}

