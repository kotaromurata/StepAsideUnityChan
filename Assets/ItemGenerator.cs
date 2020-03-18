using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    public GameObject unitychan;
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    public GameObject coin;
    public GameObject car;
    public GameObject cone;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //どのアイテムを出すのかをランダムに設定
        int num = Random.Range(1, 11);
        if (num <= 2)
        {
            if (cone.transform.position.z < unitychan.transform.position.z + 20)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitychan.transform.position.z + 50);
                }
            }
        }
        else
        {
            //レーンごとにアイテムを生成
            for (int j = -1; j <= 1; j++)
            {
                //アイテムの種類を決める
                int item = Random.Range(1, 11);
                //60%コイン配置:30%車配置:10%何もなし
                if (1 <= item && item <= 6)
                {
                    if (coin.transform.position.z < unitychan.transform.position.z + 20)
                    {
                        //コインを生成
                        coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unitychan.transform.position.z + Random.Range(40, 50));
                    }
                }
                else if (7 <= item && item <= 9)
                {
                    if (car.transform.position.z < unitychan.transform.position.z + 20)
                    {
                        //車を生成
                        car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, unitychan.transform.position.z + Random.Range(40, 50));
                    }
                }
            }
        }
    }
}