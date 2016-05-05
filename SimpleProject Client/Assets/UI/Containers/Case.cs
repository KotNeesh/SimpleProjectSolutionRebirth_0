using UnityEngine;

namespace SimpleProject.Sce
{

    public class Case : MonoBehaviour
    {
        public GameObject MyObject;
        public WindowMenu Wnd;
       
        public void Open()
        {
            Wnd.Open();
            MyObject.SetActive(true);
        }
        public void Close()
        {
            MyObject.SetActive(false);
        }
    }
}

