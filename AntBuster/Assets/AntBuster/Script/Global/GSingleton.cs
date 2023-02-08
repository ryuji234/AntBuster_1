using UnityEngine;

public class GSingleton<T> : GComponent where T : GSingleton<T>
{
    private static T _instance = default; //_는 이 변수를 private 으로 만들고 절대 보여주지 않겠다는 의미
    public static T Instance
    {
        get
        {
            if (GSingleton<T>._instance == default || _instance == default)
            {
                GSingleton<T>._instance = GF.CreateObj<T>(typeof(T).ToString());
                DontDestroyOnLoad(_instance.gameObject);
            }       // if: 인스턴스가 비어 있을 때 새로 인스턴스화 한다.

            // 여기서 부터는 인스턴스가 절대 비어있지 않을듯?
            return _instance;
        }
    }

    public override void Awake()
    {
        base.Awake();

    }       //Awake()

    public void Create()
    {
        this.Init();
    }       //Create()

    protected virtual void Init()
    {
        /* Do something */
    }
}
