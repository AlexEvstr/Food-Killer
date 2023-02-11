using UnityEngine;

public class FoodFactory: MonoBehaviour
{
    private static FoodFactory _instanse;
    public static FoodFactory Instanse
    {
        get
        {
            return _instanse;
        }
    }

    public Entity prefabSmall;
    public Entity prefabNormal;
    public Entity prefabBig;

    private void Start()
    {
        if (_instanse != null)
        {
            return;
        }
        _instanse = this;
    }

    public Entity CreateSmall()
    {
        return Instantiate(prefabSmall);
      
    }
    public Entity CreateNormal()
    {
        return Instantiate(prefabNormal);
    }

    public Entity CreateBig()
    {
        return Instantiate(prefabBig);
    }
}
