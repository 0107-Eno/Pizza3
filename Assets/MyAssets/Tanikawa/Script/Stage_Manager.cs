using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Stage_Manager : MonoBehaviour
{
    //ステージを時間経過で落とす

    [SerializeField] GameObject[] _pizzaPrefabs; // 生成するプレファブの配列
    private float _time; //時間を入れる変数
    public float speed = 0.5f; //速度を変数として扱う

    // Start is called before the first frame update
    void Start()
    {
        //初期時間を決める
        _time = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //時間を進める
        //時間を計る
        _time -= Time.deltaTime; // タイマーを減少させる

        //一定時間が経ったら
        //レオ君帰ってきちぇ
        /*if (_time <= 0)
        {
            //for文で回して落とす
            for (int i = 0; i < _pizzaPrefabs.Length; i++)
            {
                //自分自身のTransformを取得
                Transform myTransform = _pizzaPrefabs[i].transform;
                //i番目のピザを-Y軸に移動
                //先ほど取得した情報Transformの情報から座標の情報を取得
                Vector3 pos = myTransform.position;
                pos.y -= speed;
                //自分の座標を先ほど加算した値に変更
                myTransform.position = pos;
                _time = 1;
            }
        }*/
        if (_time < 0 )
        {
            for(int i = 0; i < _pizzaPrefabs.Length; i++)
            {
                StageDown(i);
            }
        }
       
        
    }
    //時間経過したらstage1をy軸方向に落とす関数を作る
    private void StageDown(int i)
    {
        //自分自身のTransformを取得
        Transform myTransform = _pizzaPrefabs[i].transform;
        //i番目のピザを-Y軸に移動
        //先ほど取得した情報Transformの情報から座標の情報を取得
        Vector3 pos = myTransform.position;
        pos.y -= speed;
        //自分の座標を先ほど加算した値に変更
        myTransform.position = pos;
        //一定落ちたらdelete
        if (pos.y < -5)
        {
            Destroy(_pizzaPrefabs[i]);
        }
        //時間を再定義
        _time = 15;
    }
}
//時間を決める
//時間を進める
//時間経過したらstage1をy軸方向に落とす
//一定落ちたらdelete
//時間を再定義
//以下ループ