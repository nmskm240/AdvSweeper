using UnityEngine;
using Alchemy;

namespace UI.Viewers
{
    public class CharacteristicsViewer : Viewer<ViewerOrder>
    {
        public override void Show()
        {
            var factory = new CharacteristicsNodeFactory();
            foreach(var characteristics in _order.WhiteList)
            {
                var obj = factory.Create();
                var node = obj.GetComponent<CharacteristicsNode>();
                var data = Resources.Load("Datas/Characteristic/" + characteristics) as CharacteristicsData;
                obj.transform.SetParent(_contents);
                obj.transform.localScale = Vector3.one;
                node.Init(data);
            }
        }
    }
}