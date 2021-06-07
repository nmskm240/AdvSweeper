using UnityEngine;
using Alchemy;

namespace UI.Viewers
{
    public class CharacteristicsViewer : Viewer<ViewerOrder>
    {
        private IFactory<GameObject> _factory = new CharacteristicsNodeFactory();

        public override void Show()
        {
            foreach(var characteristics in _order.WhiteList)
            {
                var obj = _factory.Create();
                var node = obj.GetComponent<CharacteristicsNode>();
                var data = Resources.Load("Datas/Characteristic/" + characteristics) as CharacteristicsData;
                obj.transform.SetParent(_contents);
                obj.transform.localScale = Vector3.one;
                node.Init(data);
            }
        }
    }
}