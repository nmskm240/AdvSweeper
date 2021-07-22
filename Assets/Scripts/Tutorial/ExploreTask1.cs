namespace Tutorial
{
    public class ExploreTask1 : ITask
    {
        public string Title { get { return "基本操作　探索(1/)"; } }
        public string Detail { get { return "画面中央のタイルをクリックすることで探索を行うことができます。"; } }

        public bool CheckTaskComplete()
        {
            return true;
        }

        public void OnTaskStart()
        {

        }

        public void OnTaskComplete()
        {

        }
    }
}