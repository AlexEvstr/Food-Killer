using UnityEngine;

public class BombFactory : MonoBehaviour
{
    private static BombFactory _instanse;
    public static BombFactory Instanse
    {
        get
        {
            return _instanse;
        }
    }

    public Entity prefabBombSmall;
    public Entity prefabBombNormal;
    public Entity prefabBombBig;

    private void Start()
    {
        if (_instanse != null)
        {
            return;
        }
        _instanse = this;
    }

    public Entity CreateBombSmall()
    {
        return Instantiate(prefabBombSmall);

    }
    public Entity CreateBombNormal()
    {
        return Instantiate(prefabBombNormal);
    }

    public Entity CreateBombBig()
    {
        return Instantiate(prefabBombBig);
    }
}
