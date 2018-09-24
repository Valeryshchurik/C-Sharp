namespace ISO_Robinson.Game
{
    class PlayerB : Player
    {
        public PlayerB(int m)
        {
            ResultSet = new int[m];
            StrategicSet = new int[m];
        }

        public override void ChangeStrategy()
        {
            int minEl = ResultSet[0];
            SupposedStrategy = 1;
            for (int i = 1; i < ResultSet.Length; i++)
            {
                if (minEl >= ResultSet[i])
                {
                    SupposedStrategy = (uint)i + 1;
                    minEl = ResultSet[i];
                }
            }
        }
    }
}
