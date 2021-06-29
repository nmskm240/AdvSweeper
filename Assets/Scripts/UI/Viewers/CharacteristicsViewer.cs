using UnityEngine;
using Alchemy;
using UI.Orders;

namespace UI.Viewers
{
    public class CharacteristicsViewer : Viewer<ViewerOrder>
    {
        public override void Show()
        {
            var factory = new CharacteristicsNodeFactory();
            foreach(var characteristics in _order.WhiteList)
            {
                var data = Resources.Load("Datas/Characteristic/" + characteristics) as CharacteristicsData;
                if(data == null)
                {
                    Debug.LogError("特性名：" + characteristics + "は存在しません。");
                    continue;
                }
                var obj = factory.Create();
                var node = obj.GetComponent<CharacteristicsNode>();
                obj.transform.SetParent(_contents);
                obj.transform.localScale = Vector3.one;
                node.Init(data);
            }
        }
    }
}