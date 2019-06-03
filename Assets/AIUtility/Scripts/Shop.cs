using UnityEngine;

public class Shop : MonoBehaviour, IShop
{

}

public interface IShop
{
    Transform transform { get; }
}