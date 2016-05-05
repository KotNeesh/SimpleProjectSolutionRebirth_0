using UnityEngine;


public class GameManager : MonoBehaviour
{
    public Texture2D[] t1, t2;
    private MyButton myBut1, myBut2;
    // Use this for initialization
    void Start()
    {
        myBut1 = new MyButton(new Vector2(0, 0), new Vector2(464, 203), t1[0], t1[1], t1[2]);
        myBut2 = new MyButton(new Vector2(0, 0), new Vector2(464, 203), t2[0], t2[1], t2[2]);
    }
    // Update is called once per frame
    void Update()
    {
        if (myBut1 != null && myBut2 != null)
        {
            if (myBut1.Update(Input.mousePosition, Input.GetMouseButton(0)))
            {
                //Log("myBut1 click");
            }
            if (myBut2.Update(Input.mousePosition, Input.GetMouseButton(0)))
            {
                //Log("myBut2 click");
            }
        }
    }
    void OnGUI()
    {
        if (myBut1 != null && myBut2 != null)
        {
            myBut1.Draw();
            myBut2.Draw();
        }
    }
}