namespace ISO_Robinson.Game
{
    class PlayerA : Player
    {
        public PlayerA(int n)
        {
            ResultSet = new int[n];
            StrategicSet = new int[n];
        }

        public override void ChangeStrategy()
        {
            int maxEl = ResultSet[0];
            SupposedStrategy = 1;
            for (int i = 1; i < ResultSet.Length; i++)
            {
                if (maxEl <= ResultSet[i])
                {
                    SupposedStrategy = (uint)i + 1;
                    maxEl = ResultSet[i];
                }
            }   
        }
    }
}
